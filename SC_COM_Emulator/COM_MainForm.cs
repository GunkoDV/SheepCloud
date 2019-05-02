using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace SC_COM_Emulator
{
    public partial class COM_MainForm : Form
    {
        const string COMSettFileName = "\\COMSetting.xml";
        const string FileNotFoundMess = "Не найден файл настроек COMSetting.xml";
        const string SaveSettOKMess = "Настройки сохранены";
        const string ErrorMessCaption = "Ошибка!";
        const string MessCaption = "Сообщение";
        const string PortClose = "Порт закрыт";
        const string PortOpen = "Порт открыт";
        const string PortConnect = "Открыть порт";
        const string PortDisconnect = "Закрыть порт";

        private int[] bdRates_arr = new int[] { 9600, 14400, 19200 };
        private int[] DataBits_arr = new int[] { 6, 7, 8 };
        private SettingsCOM COMsett;
        static SerialPort COMport;
        static bool fPortOpenState = false;
        private Thread TransferThread;
        static int SleepTimer = 50;
        static uint RequestCounter = 0;
        static uint ResponseCounter = 0;

        public delegate void ShowCounter();
        public ShowCounter ShRqCntr;
        public ShowCounter ShRpCntr;
        public void ShowRequestCounterMetod()
        {
            Request_lbl.Text = RequestCounter.ToString();
        }
        public void ShowResponseCounterMetod()
        {
            Response_label.Text = ResponseCounter.ToString();
        }

        public COM_MainForm()
        {
            InitializeComponent();
            ShRqCntr = new ShowCounter(ShowRequestCounterMetod);
            ShRpCntr = new ShowCounter(ShowResponseCounterMetod);
        }

        private void UpdatePortsList()
        {
            string[] ports = SerialPort.GetPortNames();
            Ports_CB.Items.Clear();
            foreach (string port in ports)
            {
                Ports_CB.Items.Add(port);
            }
            Ports_CB.Sorted = true;
            Ports_CB.SelectedIndex = 0;
        }

        private string GetCOMSettingsFile()
        {
            DirectoryInfo di = new DirectoryInfo(Environment.CurrentDirectory.ToString());
            do
            {
                string FileName = di.ToString() + COMSettFileName;      //КОСТЫЛЬ!!! Поиск файла настроек вверх по дереву папок 
                if (File.Exists(FileName))                              //Git не отслеживает папку с exe-шником
                {                                                       //Поэтому файл настроек лежит в папке с проектом
                    return FileName;    
                }
                di = Directory.GetParent(di.ToString());
            } while (di != null);

            return "";                     
        }

        private void LoadCOMSettings()
        {
            string FileName = GetCOMSettingsFile();
            if (FileName != "")
            {
                COMsett = new SettingsCOM(FileName);
            }
            else
            {
                MessageBox.Show(FileNotFoundMess, ErrorMessCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            COMsett.ReadXml();
            Ports_CB.SelectedIndex = Ports_CB.Items.IndexOf(COMsett.Fields.PortName);
            bdRate_CB.SelectedIndex = bdRate_CB.Items.IndexOf(COMsett.Fields.BaudRate.ToString());
            Databits_CB.SelectedIndex = Databits_CB.Items.IndexOf(COMsett.Fields.DataBits.ToString());
            if (COMsett.Fields.pr == Parity.Odd)
            {
                ParityOdd_RB.Checked = true;
            }
            if (COMsett.Fields.pr == Parity.Even)
            {
                ParityEven_RB.Checked = true;
            }
            if (COMsett.Fields.sb == StopBits.OnePointFive)
            {
                OneHalfSB_RB.Checked = true;
            }
            if (COMsett.Fields.sb == StopBits.Two)
            {
                TwoSB_RB.Checked = true;
            }
        }
        private void LoadElements()
        {
            foreach (int bdR in bdRates_arr)
            {
                bdRate_CB.Items.Add(bdR.ToString());
            }
            foreach (int db in DataBits_arr)
            {
                Databits_CB.Items.Add(db.ToString());
            }
            ParityNone_RB.Checked = true;
            OneSB_RB.Checked = true;
        }
        private void COM_MainForm_Load(object sender, EventArgs e)
        {
            UpdatePortsList();
            LoadElements();
            LoadCOMSettings();
            PortOffline();
        }

        private void SaveSett_btn_Click(object sender, EventArgs e)
        {
            COMsett.Fields.PortName = Ports_CB.Text;
            COMsett.Fields.BaudRate = Int32.Parse(bdRate_CB.Text);           
            COMsett.Fields.pr = Parity.None;
            if (ParityOdd_RB.Checked)
            {
                COMsett.Fields.pr = Parity.Odd;
            }
            if (ParityEven_RB.Checked)
            {
                COMsett.Fields.pr = Parity.Even;
            }
            COMsett.Fields.DataBits = Int32.Parse(Databits_CB.Text);
            COMsett.Fields.sb = StopBits.One;
            if (OneHalfSB_RB.Checked)
            {
                COMsett.Fields.sb = StopBits.OnePointFive;
            }
            if (TwoSB_RB.Checked)
            {
                COMsett.Fields.sb = StopBits.Two;
            }
            COMsett.WriteXml();
            LoadCOMSettings();
            MessageBox.Show(SaveSettOKMess, MessCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateCOMList_lbl_Click(object sender, EventArgs e)
        {
            UpdatePortsList();
        }

        private byte [] ReadFromPort(out int bytesRead)
        {
            int bytesCount = 0;
            bytesRead = 0;
            byte[] buff = new byte[2];
            try
            {           
                bytesCount = COMport.BytesToRead;
            }
            catch (InvalidOperationException)
            {
                bytesRead = 0;
            }
            if (bytesCount > 1)
            {
                COMport.Read(buff, 0, 2);
                COMport.DiscardInBuffer();
                bytesRead = 2;
                RequestCounter++;
                Request_lbl.Invoke(ShRqCntr);
            }
            return buff;
        }
        private void SendToPort(byte [] InArr)
        {
            byte id = InArr[0];
            byte CountNumbers = InArr[1];
            byte[] buff = new byte[CountNumbers+1];
            buff[0] = id;
            Random rand = new Random();
            for (int i=1; i<CountNumbers+1;i++)
            {
                buff[i] = (byte)rand.Next();
            }                     
            COMport.Write(buff, 0, buff.Length);
            ResponseCounter = ResponseCounter + CountNumbers + 1;
            Response_label.Invoke(ShRpCntr);           
        }

        private void PortDataExchange()
        {            
            while (fPortOpenState)
            {
                byte[] buffIn = ReadFromPort(out int BR);
                if (BR != 0)
                {
                    SendToPort(buffIn);
                }
                Thread.Sleep(SleepTimer);
            }            
        }

        private void OpenPort()
        {            
            COMport = new SerialPort(
                COMsett.Fields.PortName,
                COMsett.Fields.BaudRate,
                COMsett.Fields.pr,
                COMsett.Fields.DataBits,
                COMsett.Fields.sb);
            COMport.Open();
        }
        private void PortOnline()
        {
            Port_btn.Text = PortDisconnect;
            PortState_lbl.Text = PortOpen;            
        }
        private void PortOffline()
        {
            Port_btn.Text = PortConnect;
            PortState_lbl.Text = PortClose;            
        }
        private void Port_btn_Click(object sender, EventArgs e)
        {
            if (!fPortOpenState)
            {
                try
                {
                    OpenPort();
                    fPortOpenState = true;
                    PortOnline();
                    TransferThread = new Thread(PortDataExchange);
                    TransferThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ErrorMessCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    COMport.Close();
                    fPortOpenState = false;
                    PortOffline();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ErrorMessCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void COM_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TransferThread.IsAlive)
            {
                TransferThread.Abort();
            }            
        }
    }

}
