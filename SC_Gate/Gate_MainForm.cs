using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC_Gate
{
    public partial class Gate_MainForm : Form
    {
        const string ScktDiscntMess = "Нет подключения";
        const string ScktCntMess = "Подключение создано";
        const string ConnectScktBtnText = "Подключиться";
        const string DisconnectScktBtnText = "Отключиться";
        const string COMDevConnectOK = "OK";
        const string COMDevConnectErr = "Error";
        const string ErrorMessCaption = "Ошибка";
        const string IncorrectPortMess = "Некорректный номер порта";

        static uint RequestCounter = 0;

        static byte COMDevStat = 1;
        static uint COMDevPackCount = 0;
        static byte COMDevValue = 0;

        private bool fPLCConnected = false;
        private bool fSendRequest = true;
        TcpClient PLCSckt;      

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

        public void ShowRequestCounter()
        {
            Request_Counter_lbl.Text = RequestCounter.ToString();
        }

        public void ShowCOMDevData()
        {
            switch (COMDevStat)
            {
                case 0:
                    COM_connect_stat_lbl.Text = COMDevConnectOK;
                    break;
                default:
                    COM_connect_stat_lbl.Text = COMDevConnectErr;
                    break;
            }
            COM_pack_counter_lbl.Text = COMDevPackCount.ToString();
            Current_val_lbl.Text = COMDevValue.ToString();
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

        private byte [] LoadRequest()
        {
            byte[] command = new byte[12];
            command[0] = 0;
            command[1] = 1;
            command[2] = 0;
            command[3] = 0;
            command[4] = 0;
            command[5] = 6;
            command[6] = 1;
            command[7] = 3;
            command[8] = 0;
            command[9] = 0;
            command[10] = 0;
            command[11] = 2;
            return command;
        }

        private bool SendRequest()
        {
            byte[] command = LoadRequest();
            NetworkStream tcpstream = PLCSckt.GetStream();

            try
            {
                tcpstream.Write(command, 0, command.Length);
                return true;
            }
            catch (IOException ex)
            {              
                MessageBox.Show(ex.Message, ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private byte[] ReceiveData()
        {
            NetworkStream tcpstream = PLCSckt.GetStream();
            byte[] buff = new byte[1024];
            int bytes;
            if (tcpstream.DataAvailable)
            {
                bytes = tcpstream.Read(buff, 0, buff.Length);
            }
            return buff;

        }

        private void PrintData(byte [] buff)
        {
            uint PackCount = (uint)(buff[9]*256)+buff[10];
            byte Devstate = buff[12];
            if ((PackCount != COMDevPackCount) || (Devstate != COMDevStat))
            {
                COMDevPackCount = PackCount;
                COMDevStat = buff[12];
                COMDevValue = buff[11];
                ShowCOMDevData();
            }
        }

        public Gate_MainForm()
        {
            InitializeComponent();
        }   

        private void Gate_MainForm_Load(object sender, EventArgs e)
        {
            ShowScktDisconnect();
            ShowRequestCounter();
            ShowCOMDevData();
        }

        private void ConnectSckt_btn_Click(object sender, EventArgs e)
        {
            if (! fPLCConnected)
            {
                fPLCConnected = ConnectToPLC();
                Test_timer.Enabled = true;
            }
            else
            {
                Test_timer.Enabled = false;
                PLCSckt.Close();
                ShowScktDisconnect();
                fPLCConnected = false;                
            }             
        }

        private void Test_timer_Tick(object sender, EventArgs e)
        {
            if (fSendRequest)
            {
                SendRequest();
                fSendRequest = false;
            }
            else
            {
                byte[] buff = ReceiveData();
                PrintData(buff);
                RequestCounter += 1;
                ShowRequestCounter();
                fSendRequest = true;
            }
        }
    }
}
