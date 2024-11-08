using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CtTracNghiem
{
    [Serializable]
    public class Class_CauHoi : ISerializable
    {
        private string maCH;
        private string noiDung;
        private string dapAn;

        public string MaCH { get => maCH; set => maCH = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public string DapAn { get => dapAn; set => dapAn = value; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaCH", MaCH);
            info.AddValue("NoiDung", NoiDung);
            info.AddValue("DapAn", DapAn);
        }
        public Class_CauHoi() { }
        public Class_CauHoi(SerializationInfo info, StreamingContext context)
        {
            MaCH = info.GetString("MaCH");
            NoiDung = info.GetString("NoiDung");
            DapAn = info.GetString("DapAn");
        }
        public Class_CauHoi(string _maCH, string _noiDung, string _dapAn)
        {
            maCH = _maCH;
            noiDung = _noiDung;
            dapAn = _dapAn;
        }
    }
}
