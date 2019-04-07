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

namespace SC_COM_Emulator
{
    public partial class COM_MainForm : Form
    {
        const string COMSettFileName = "\\COMSetting.xml";
        const string FileNotFoundMess = "Не найден файл настроек COMSetting.xml";
        const string ErrorMessCaption = "Ошибка";
        private SettingsCOM sCOM;
        public COM_MainForm()
        {
            InitializeComponent();
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

        private void COM_MainForm_Load(object sender, EventArgs e)
        {
            string FileName = GetCOMSettingsFile();
            if (FileName != "")
            {
                sCOM = new SettingsCOM(Environment.CurrentDirectory.ToString() + "\\COMSetting.xml");
            }
            else
            {
                MessageBox.Show(FileNotFoundMess, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
            sCOM.ReadXml();
            label1.Text = sCOM.Fields.PortName.ToString();
        }
    }

}
