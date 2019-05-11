using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Runtime.Serialization;


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
}
