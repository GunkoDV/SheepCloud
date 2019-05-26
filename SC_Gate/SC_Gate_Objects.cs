using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace SC_Gate
{
    class PLCDataPack
    {
        public byte ConnectionState = 1;
        public uint CounterPack = 0;
        public byte CurrValue = 0;
        public void CopyFrom(PLCDataPack plcdp)
        {
            ConnectionState = plcdp.ConnectionState;
            CounterPack = plcdp.CounterPack;
            CurrValue = plcdp.CurrValue;
        }
    }

    [DataContract]
    public class DataPoint
    {
        [DataMember]
        public int PointNo;
        [DataMember]
        public byte Value;

        public DataPoint(int pN, byte val)
        {
            PointNo = pN;
            Value = val;
        }        
    }

    public class Report
    {
        public DateTime BeginDT;
        public DateTime EndDT;
        public int PackCount;
        public string FileName;
    }

    public class ProgramSettingsFeilds
    {
        public string HostName = "10.0.6.10";
        public int Port = 502;
        public int NHist = 64;
        public int RepInterval = 30;
    }
    public class ProgramSettings
    {
        public string XMLFileName;
        public ProgramSettingsFeilds ProgSettFlds;

        public ProgramSettings()
        {            
            ProgSettFlds = new ProgramSettingsFeilds();
        }
        public void WriteFields()
        {
            XmlSerializer ser = new XmlSerializer(typeof(ProgramSettingsFeilds));

            TextWriter writer = new StreamWriter(XMLFileName);
            ser.Serialize(writer, ProgSettFlds);
            writer.Close();
        }
        public void ReadFields()
        {
            if (File.Exists(XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ProgramSettingsFeilds));
                TextReader reader = new StreamReader(XMLFileName);
                ProgSettFlds = ser.Deserialize(reader) as ProgramSettingsFeilds;
                reader.Close();
            }
        }           
    }
    public static class StrNMess
    {
        public const string ScktDiscntMess = "Нет подключения";
        public const string ScktCntMess = "Подключение создано";
        public const string ScktClsngMess = "Закрытие подключения";
        public const string ConnectScktBtnText = "Подключиться";
        public const string DisconnectScktBtnText = "Отключиться";
        public const string COMDevConnectOK = "OK";
        public const string COMDevConnectErr = "Error";
        public const string ErrorMessCaption = "Ошибка";
        public const string IncorrectPortMess = "Некорректный номер порта";
    }
}
