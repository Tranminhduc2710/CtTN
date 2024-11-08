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
    public class Class_BaiLam : ISerializable
    {
        private Class_CauHoi cauhoi;
        private string traloi;

        public Class_CauHoi CauHoi { get => cauhoi; set => cauhoi = value; }
        public string TraLoi { get => traloi; set => traloi = value; }

        public Class_BaiLam() { }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("CauHoi", JsonConvert.SerializeObject(cauhoi));
            info.AddValue("TraLoi", traloi);
        }
        public Class_BaiLam(SerializationInfo info, StreamingContext context)
        {
            cauhoi = (Class_CauHoi)info.GetValue("CauHoi", typeof(Class_CauHoi));
            traloi = info.GetString("TraLoi");
        }
        public float TinhDiemBaiLam()
        {
            if (traloi != null)
            {
                if (traloi.Equals(cauhoi.DapAn,
                StringComparison.OrdinalIgnoreCase)) return 1.0f;
                else return 0.0f;
            }
            else return 0.0f;
        }
    }
}
