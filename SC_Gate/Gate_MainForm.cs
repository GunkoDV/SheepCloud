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
        public const int ModbusFuncCode = 3;       // Код функции Modbus (чтение регистров)

        private bool fPLCConnected = false;        
        private DataStorage DataBuff;

        private double[] X_arr;
        private int[] Summ_arr;
        private DateTime ReportDateTime;

        public ProgramSettings ProgSett = new ProgramSettings();

        private SettingsForm SettForm = new SettingsForm();      


        private PLCSocket SheepSocket;
       

        private void ShowScktDisconnect()
        {
            Sckt_State_lbl.Text = StrNMess.ScktDiscntMess;
            ConnectSckt_btn.Text = StrNMess.ConnectScktBtnText;
            Settings_btn.Enabled = true;
            fPLCConnected = false;
        }
        private void ShowScktConnect()
        {
            Sckt_State_lbl.Text = StrNMess.ScktCntMess;
            ConnectSckt_btn.Text = StrNMess.DisconnectScktBtnText;
            Settings_btn.Enabled = false;
            fPLCConnected = true;
        }       

        public void ShowPLCPack()
        {
            PLCDataPack plcdp = DataBuff.PLCPackBuff.Last();
            switch (plcdp.ConnectionState)
            {
                case 0:
                    COM_connect_stat_lbl.Text = StrNMess.COMDevConnectOK;
                    break;
                default:
                    COM_connect_stat_lbl.Text = StrNMess.COMDevConnectErr;
                    break;
            }
            COM_pack_counter_lbl.Text = plcdp.CounterPack.ToString();
            Current_val_lbl.Text = plcdp.CurrValue.ToString();
            if (plcdp.CurrValue != 0)
            {
                PrintHistogram(plcdp);
            }
            TimeSpan RepInterval = DateTime.Now - ReportDateTime;
            if (RepInterval.TotalMinutes >= ProgSett.ProgSettFlds.RepInterval)
            {
                DataBuff.GetReport(ReportDateTime);
                ReportDateTime = DateTime.Now;
                for (int j = 0; j < Summ_arr.Max(); j++)
                {
                    Summ_arr[j] = 0;
                }
            }
        }

        private void PrintHistogram(PLCDataPack plcdp)
        {                                                
            for (int i = 0; i < ProgSett.ProgSettFlds.NHist; i++)
                {
                    if ((plcdp.CurrValue >= X_arr[i]) && (plcdp.CurrValue < X_arr[i + 1]))
                    {
                        Summ_arr[i]++;
                    }
                }
            PLC_chart.Series["Series1"].Points.Clear();
            int ValueCount = DataBuff.PLCPackBuff.Count;
            for (int i = 0; i < ProgSett.ProgSettFlds.NHist; i++)
            {                
                PLC_chart.Series["Series1"].Points.AddXY(X_arr[i], (Summ_arr[i]+0.0)/ValueCount);
            }            
        }       
        
        private void NewData(PLCDataPack dataPack)
        {
            DataBuff.PLCPackBuff.Add(dataPack);
            ShowPLCPack();
        }

        public Gate_MainForm()
        {
            InitializeComponent();
        }   

        private void HistSetting()
        {
            X_arr = new double[ProgSett.ProgSettFlds.NHist + 1];
            Summ_arr = new int[ProgSett.ProgSettFlds.NHist];
            for (int i = 0; i < ProgSett.ProgSettFlds.NHist + 1; i++)
            {
                X_arr[i] = i * (256 / ProgSett.ProgSettFlds.NHist);
            }
            PLC_chart.ChartAreas["ChartArea1"].AxisX.Minimum = 0;
            PLC_chart.ChartAreas["ChartArea1"].AxisX.Maximum = X_arr[ProgSett.ProgSettFlds.NHist];
            PLC_chart.ChartAreas["ChartArea1"].AxisX.Interval = 16;
        }

        private void Gate_MainForm_Load(object sender, EventArgs e)
        {
            DataBuff = new DataStorage
            {
                PLCPackBuff = new List<PLCDataPack>()
            };
            ShowScktDisconnect();                        
            ReportDateTime = DateTime.Now;
            ProgSett.XMLFileName = Environment.CurrentDirectory + "\\Settings.xml";
            ProgSett.ReadFields();
            HistSetting();
            SettForm.Owner = this;           
        }
        private void TryConnect()
        {
            if (SheepSocket == null)
            {
                SheepSocket = new PLCSocket(ProgSett.ProgSettFlds)
                {
                    ShowConnect = new DisplayData(ShowScktConnect),
                    ShowDisconnect = new DisplayData(ShowScktDisconnect),
                    ExportData = new AddData(NewData)
                };
                SheepSocket.Start(this);
            }
            else
            {
                SheepSocket.FTryConnect = true;
            }
        }

        private void ConnectSckt_btn_Click(object sender, EventArgs e)
        {
            if (! fPLCConnected)
            {
                TryConnect();
            }
            else
            {
                SheepSocket.FDisconnect = true;
            }             
        }
        private void Gate_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fPLCConnected)
            {
                SheepSocket.FDisconnect = true;         //Закрыть подключение
                Sckt_State_lbl.Text = StrNMess.ScktClsngMess;
                Stoptimer.Enabled = true;
                e.Cancel = true;                        //Подождать завершения потока                                              
            }
        }
        private void Settings_btn_Click(object sender, EventArgs e)
        {
            SettForm.ShowDialog();
            HistSetting();
        }
        private void Stoptimer_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
