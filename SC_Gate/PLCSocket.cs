using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SC_Gate
{
    public delegate void DisplayData();
    public delegate void AddData (PLCDataPack pLCDataPack);
    
    class PLCSocket
    {
        public DisplayData ShowConnect;
        public DisplayData ShowDisconnect;
        public AddData ExportData;
        public bool FRun;
        public bool FTryConnect;
        public bool FConnected;
        public bool FDisconnect;

        private TcpClient PLCSckt;
        private Thread ScktThread;
        private Gate_MainForm GMF;
        private readonly ProgramSettingsFeilds PSF;
        private PLCDataPack CurrentDP = new PLCDataPack();
        private int WaitTimeOut = 10;           //Задержка чтения ответа контроллера после запроса

        public PLCSocket(ProgramSettingsFeilds aPSF)
        {
            PSF = aPSF;
            FTryConnect = true;
            FConnected = false;
            FDisconnect = false;
        }

        public void Start(Gate_MainForm aGMF)
        {
            GMF = aGMF;
            ScktThread = new Thread(Execute)
            {
                IsBackground = true
            };
            ScktThread.Start();
            FRun = true;
        }

        private void Execute()
        {
            byte[] buff = new byte[1024];
            while (FRun)
            {                
                if (FTryConnect)
                {
                    FConnected = Connect();
                }
                while (FConnected)
                {
                    if (SendRequest())
                    {
                        Thread.Sleep(WaitTimeOut);
                        buff = ReceiveData();
                        if (buff[7] == Gate_MainForm.ModbusFuncCode)      // Если ответ Modbus корректен парсим
                        {
                            ParsData(buff);
                        }
                    }
                    if (FDisconnect)
                    {
                        FDisconnect = false;
                        FConnected = false;
                        Disconnect();
                    }
                    
                }
                Thread.Sleep(10);
            }            
        }

        private bool Connect()
        {            
            try
            {
                PLCSckt = new TcpClient(PSF.HostName, PSF.Port);
                GMF.Invoke(ShowConnect);
                FTryConnect = false;
                return true;
            }
            catch (SocketException e)
            {
                MessageBox.Show(e.Message, StrNMess.ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Disconnect()
        {
            if (PLCSckt != null)
            {
                PLCSckt.Close();
            }
            GMF.Invoke(ShowDisconnect);
        }

        private byte[] GetRequest()        // Команда-запрос по протоколу ModbusTCP на чтение регистров ПЛК
        {
            byte[] command = new byte[12];
            command[0] = 0;                 // ID 
            command[1] = 1;                 // ID пакета (в проекте не используется)
            command[2] = 0;                 // ID  
            command[3] = 0;                 // ID протокола
            command[4] = 0;                 // Длинна
            command[5] = 6;                 // Длинна пакета            
            command[6] = 1;                 // ID узла (настраивается на ПЛК)
            command[7] = Gate_MainForm.ModbusFuncCode;    // Код функции Modbus (чтение регистров)             
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
                MessageBox.Show(ex.Message, StrNMess.ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Disconnect();
                FConnected = false;
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
                FConnected = false;
                MessageBox.Show(ex.Message, StrNMess.ErrorMessCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Disconnect();
                FConnected = false;
            }
            return buff;
        }

        private void ParsData(byte[] buff)
        {
            uint PackCount = (uint)(buff[9] * 256) + buff[10];
            byte Devstate = buff[12];
            if ((PackCount != CurrentDP.CounterPack) || (Devstate != CurrentDP.ConnectionState))  // Если данные регистров изменились, то новый пакет
            {
                CurrentDP.CounterPack = PackCount;
                CurrentDP.ConnectionState = Devstate;
                CurrentDP.CurrValue = buff[11];
                PLCDataPack NewPLCdp = new PLCDataPack();
                NewPLCdp.CopyFrom(CurrentDP);
                GMF.Invoke(ExportData, new Object[] {NewPLCdp});
            }            
                        
        }


    }
}
