using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SC_Gate
{
    public partial class SettingsForm : Form
    {
        public Gate_MainForm Main;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void SaveSettings()
        {
            if (this.Owner is Gate_MainForm Main)
            {
                Main.ProgSett.ProgSettFlds.HostName = Address_TB.Text;
                Int32.TryParse(Port_TB.Text, out Main.ProgSett.ProgSettFlds.Port);
                Int32.TryParse(NHist_TB.Text, out Main.ProgSett.ProgSettFlds.NHist);
                Int32.TryParse(Interval_TB.Text, out Main.ProgSett.ProgSettFlds.RepInterval);
                Main.ProgSett.WriteFields();
                Main.ProgSett.ReadFields();
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            bool fSave = true;
            
            if (!(Int32.TryParse(Port_TB.Text, out int port)))
            {
                fSave = false;
                MessageBox.Show(StrNMess.IncorrectPortMess, StrNMess.ErrorMessCaption,
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (fSave)
            {
                SaveSettings();
                this.Close();
            }            
        }

        private void LoadSettings()
        {
            if (this.Owner is Gate_MainForm Main)
            {
                Address_TB.Text = Main.ProgSett.ProgSettFlds.HostName;
                Port_TB.Text = Main.ProgSett.ProgSettFlds.Port.ToString();
                NHist_TB.Text = Main.ProgSett.ProgSettFlds.NHist.ToString();
                Interval_TB.Text = Main.ProgSett.ProgSettFlds.RepInterval.ToString();
            }
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }
    }
}
