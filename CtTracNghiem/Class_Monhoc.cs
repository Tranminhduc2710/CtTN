using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CtTracNghiem
{
    [Serializable]
    public class Class_Monhoc
    {
        private string maMH;
        private string tenMH;
        private List<Class_CauHoi> nganHangCauHoi;

        public string MaMH { get => maMH; set => maMH = value; }
        public string TenMH { get => tenMH; set => tenMH = value; }
        public List<Class_CauHoi> NganHangCauHoi { get => nganHangCauHoi; set => nganHangCauHoi = value; }
        public Class_Monhoc()
        {
            NganHangCauHoi = new List<Class_CauHoi>();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaMH", MaMH);
            info.AddValue("TenMH", TenMH);
            info.AddValue("NganHangCauHoi", JsonConvert.SerializeObject(NganHangCauHoi));
        }
        public Class_Monhoc (SerializationInfo info, StreamingContext context)
        {
            MaMH = info.GetString("MaMH");
            TenMH = info.GetString("TenMH");
            NganHangCauHoi = JsonConvert.DeserializeObject<List<Class_CauHoi>>(info.GetString("NganHangCauHoi"));
        }
        public Class_Monhoc LayMonHocTheoMa (List<Class_Monhoc> danhSachMonHoc, string maMH)
        {
            foreach (Class_Monhoc monHoc in danhSachMonHoc )
            {
                if (monHoc.MaMH == maMH)
                    return monHoc;
            }
            return null;
        }
    }
}
