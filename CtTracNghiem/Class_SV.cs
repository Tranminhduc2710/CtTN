using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;  

namespace CtTracNghiem
{
    [Serializable]
    public class Class_SV : Class_User, ISerializable
    {
        private List<string> malop;

        public List<string> MaLop { get => malop; set => malop = value; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ma", Ma);
            info.AddValue("Ten", Ten);
            info.AddValue("Email", Email);
            info.AddValue("MatKhau", MatKhau);
            info.AddValue("MaLop", JsonConvert.SerializeObject(MaLop));
        }
        public Class_SV() { }
        public Class_SV(SerializationInfo info, StreamingContext content)
        {
            Ma = info.GetString("Ma");
            Ten = info.GetString("Ten");
            Email = info.GetString("Email");
            MatKhau = info.GetString("MatKhau");
            MaLop =
            JsonConvert.DeserializeObject<List<string>>(info.GetString("MaLop"));
        }
    }
}
