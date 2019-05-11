using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SC_Gate
{   

    public partial class Gate_MainForm : Form
    {
        const string ScktDiscntMess = "Нет подключения";
        const string ScktCntMess = "Подключение создано";
        const string ScktClsngMess = "Закрытие подключения";
        const string ConnectScktBtnText = "Подключиться";
        const string DisconnectScktBtnText = "Отключиться";
        const string COMDevConnectOK = "OK";
        const string COMDevConnectErr = "Error";
        const string ErrorMessCaption = "Ошибка";
        const string IncorrectPortMess = "Некорректный номер порта";
        const int ModbusFuncCode = 3;       // Код функции Modbus (чтение регистров)

        private bool fPLCConnected = false;
        private byte StopCounter = 0;
        TcpClient PLCSckt;
        private Thread ScktThread;

        private static List<PLCDataPack> PLCPackBuff;

        private double[] X_arr;
        private int[] Summ_arr;
        private int NHist;
        private DateTime ReportDateTime;

        public delegate void ShowData();
        public ShowData showPLCPack;
        public ShowData showDisconnect;

        private void ShowScktDisconnect()
        {
            Sckt_State_lbl.Text = ScktDiscntMess;
            ConnectSckt_btn.Text = ConnectScktBtnText;
        }

        private void ShowScktConnect()
        {
            Sckt_State_lbl.Text = ScktCntMess;
            ConnectSckt_btn.Text = DisconnectScktBtnText;
        }
        private void ShowScktClosing()
        {
            StringBuilder sb = new StringBuilder(ScktClsngMess);
            for (byte i=0; i< StopCounter; i++)
            {
                sb.Append(".");
            }
            Sckt_State_lbl.Text = sb.ToString();
        }


        public void ShowPLCPack()
        {
            PLCDataPack plcdp = PLCPackBuff.Last();
            switch (plcdp.ConnectionState)
            {
                case 0:
                    COM_connect_stat_lbl.Text = COMDevConnectOK;
                    break;
                default:
                    COM_connect_stat_lbl.Text = COMDevConnectErr;
                    break;
            }
            COM_pack_counter_lbl.Text = plcdp.CounterPack.ToString();
            Current_val_lbl.Text = plcdp.CurrValue.ToString();
            if (plcdp.CurrValue != 0)
            {
                PrintHistogram(plcdp);
            }
            TimeSpan RepInterval = DateTime.Now - ReportDateTime;
            if (RepInterval.TotalMinutes>1)
            {              
                GetReport();
                ReportDateTime = DateTime.Now;
            }
        }

        private void GetReport()
        {
            int PackCount = PLCPackBuff.Count;
            DataPoint[] dataPoints = new DataPoint[PackCount];
            int i = 0;
            foreach (PLCDataPack plcdp in PLCPackBuff)
            {
                i++;
                DataPoint dp = new DataPoint(i, plcdp.CurrValue);
                dataPoints[i - 1] = dp;
            }
            DateTime DTRep = DateTime.Now;

            string FileName = Environment.CurrentDirectory.ToString() + "\\Reports\\" + DTRep.Year.ToString() + "_" +
                DTRep.Month.ToString() + "_" + DTRep.Day.ToString() + "_"+ DTRep.Hour.ToString() + "_" + DTRep.Minute.ToString();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(DataPoint[]));
            using (FileStream fs = new FileStream(FileName+ ".json", FileMode.OpenOrCreate)) 
            {
                jsonFormatter.WriteObject(fs, dataPoints);
            }

            Report Rep = new Report();
            Rep.BeginDT = ReportDateTime;
            Rep.EndDT = DateTime.Now;
            Rep.PackCount = PackCount;
            Rep.FileName = FileName + ".json";
            XmlSerializer ser = new XmlSerializer(typeof(Report));
            TextWriter writer = new StreamWriter(FileName+".xml");
            ser.Serialize(writer, Rep);
            writer.Close();

            Monitor.Enter(PLCPackBuff);
            PLCPackBuff.Clear();
            Monitor.Exit(PLCPackBuff);

            for (int j =0; j < NHist; j++)
            {
                Summ_arr[j] = 0;
            }
        }

        private void PrintHistogram(PLCDataPack plcdp)
        {                                                
            for (int i = 0; i < NHist; i++)
                {
                    if ((plcdp.CurrValue >= X_arr[i]) && (plcdp.CurrValue < X_arr[i + 1]))
                    {
                        Summ_arr[i]++;
                    }
                }
            PLC_chart.Series["Series1"].Points.Clear();
            int ValueCount = PLCPackBuff.Count;
            for (int i = 0; i < NHist; i++)
            {                
                PLC_chart.Series["Series1"].Points.AddXY(X_arr[i]+4, (Summ_arr[i]+0.0)/ValueCount);
            }            
        }



        private bool ConnectToPLC()
        {
            ShowScktDisconnect();
            bool fPortCorect = Int32.TryParse(Port_TB.Text, out int port);
            fPortCorect = fPortCorect && (port >= IPEndPoint.MinPort) && (port <= IPEndPoint.MaxPort);
            if (!fPortCorect)
            {
                MessageBox.Show(IncorrectPortMess, ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                PLCSckt = new TcpClient(Address_TB.Text, port);
                ShowScktConnect();
                return true;
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message, ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }           
        }

        private byte [] GetRequest()        // Команда-запрос по протоколу ModbusTCP на чтение регистров ПЛК
        {
            byte[] command = new byte[12];
            command[0] = 0;                 // ID 
            command[1] = 1;                 // ID пакета (в проекте не используется)
            command[2] = 0;                 // ID  
            command[3] = 0;                 // ID протокола
            command[4] = 0;                 // Длинна
            command[5] = 6;                 // Длинна пакета            
            command[6] = 1;                 // ID узла (настраивается на ПЛК)
            command[7] = ModbusFuncCode;    // Код функции Modbus (чтение регистров)             
            command[8] = 0;                 // Начальный  
            command[9] = 0;                 // адрес регистров
            command[10] = 0;                // Кол-во
            command[11] = 2;                // регистров для чтения    
            return command;
        }

        private bool SendRequest()
        {
            byte[] command = GetRequest();        
            try
            {
                NetworkStream tcpstream = PLCSckt.GetStream();
                tcpstream.Write(command, 0, command.Length);
                return true;
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.Message, ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(showDisconnect);
                return false;
            }
        }

        private byte[] ReceiveData()
        {           
            byte[] buff = new byte[1024];
            int bytes;
            try
            {
                NetworkStream tcpstream = PLCSckt.GetStream();
                do
                {
                    bytes = tcpstream.Read(buff, 0, buff.Length);

                } while (tcpstream.DataAvailable);
            }
            catch (Exception ex)
            {
                fPLCConnected = false;
                MessageBox.Show(ex.Message, ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Invoke(showDisconnect);
            }        
            return buff;         
        }       

        private void RequestForPLC()
        {
            PLCDataPack dataPack = new PLCDataPack();
            while (fPLCConnected)
            {
                byte[] buff = new byte[1024];
                if (SendRequest())
                {
                    Thread.Sleep(1);
                    buff = ReceiveData();
                }
                bool fPackOK = false;
                if (buff[7] == ModbusFuncCode)      // Если ответ Modbus корректен парсим
                {
                    uint PackCount = (uint)(buff[9] * 256) + buff[10];
                    byte Devstate = buff[12];
                    if ((PackCount != dataPack.CounterPack) || (Devstate != dataPack.ConnectionState))  // Если данные регистров изменились, то новый пакет
                    {
                        dataPack.CounterPack = PackCount;
                        dataPack.ConnectionState = Devstate;
                        dataPack.CurrValue = buff[11];
                        fPackOK = true;
                    }
                }
                if (fPackOK)
                {
                    PLCDataPack NewPLCdp = new PLCDataPack();
                    NewPLCdp.CopyFrom(dataPack);
                    Monitor.Enter(PLCPackBuff);
                    PLCPackBuff.Add(NewPLCdp);
                    Monitor.Exit(PLCPackBuff);
                    Invoke(showPLCPack);
                }                            
            }
        }
        
        public Gate_MainForm()
        {
            InitializeComponent();
        }   

        private void Gate_MainForm_Load(object sender, EventArgs e)
        {
            PLCPackBuff = new List<PLCDataPack>();
            ShowScktDisconnect();                        
            showPLCPack = new ShowData(ShowPLCPack);
            showDisconnect = new ShowData(ShowScktDisconnect);

            ReportDateTime = DateTime.Now;
            NHist = 64;
            X_arr = new double[NHist + 1];
            Summ_arr = new int[NHist];
            for (int i = 0; i < NHist+1; i++)
            {
                X_arr[i] = i * (256/NHist);
            }

            PLC_chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            PLC_chart.ChartAreas["ChartArea1"].AxisX.Maximum = 255;
            PLC_chart.ChartAreas["ChartArea1"].AxisX.Interval = 50;
        }

        private void ConnectSckt_btn_Click(object sender, EventArgs e)
        {
            if (! fPLCConnected)
            {
                fPLCConnected = ConnectToPLC();
                if (fPLCConnected)
                {
                    ScktThread = new Thread(RequestForPLC);
                    ScktThread.Start();
                }
            }
            else
            {
                ConnectSckt_btn.Enabled = false;
                fPLCConnected = false;
                Stoptimer.Enabled = true;
            }             
        }      

        private void Gate_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fPLCConnected)
            {
                fPLCConnected = false;
                Stoptimer.Enabled = true;
            }
        }

        private void Stoptimer_Tick(object sender, EventArgs e)
        {
            StopCounter += 1;
            ShowScktClosing();
            if (StopCounter == 4)
            {
                StopCounter = 0;
                Stoptimer.Enabled = false;
                PLCSckt.Close();
                ShowScktDisconnect();
                ConnectSckt_btn.Enabled = true;
                ConnectSckt_btn.Select();
            }
        }
    }
}
