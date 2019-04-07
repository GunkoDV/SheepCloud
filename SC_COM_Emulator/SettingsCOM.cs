using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.IO.Ports;

namespace SC_COM_Emulator
{
    public class SettingsFields
    {
        public string PortName = "COM3";
        public int BaudRate = 9600;
        public Parity pr = Parity.None;
        public int DataBits = 1;
        public StopBits sb = StopBits.One;
    }

    class SettingsCOM
    {
        private readonly string XMLFileName;
        public SettingsFields Fields;

        public SettingsCOM(string FileName)
        {
            XMLFileName = FileName;
            Fields = new SettingsFields();
        }

        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(SettingsFields));

            TextWriter writer = new StreamWriter(XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        //Чтение насроек из файла
        public void ReadXml()
        {
            if (File.Exists(XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(SettingsFields));
                TextReader reader = new StreamReader(XMLFileName);
                Fields = ser.Deserialize(reader) as SettingsFields;
                reader.Close();
            }
        }
    }

}

