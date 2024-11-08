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
    public class Class_Khoa : ISerializable
    {
        private string makhoa;
        private string tenkhoa;
        public string MaKhoa { get => makhoa; set => makhoa = value; }
        public string TenKhoa { get => tenkhoa; set => tenkhoa = value; }
        public Class_Khoa() { }
        public Class_Khoa(SerializationInfo info, StreamingContext context)
        {
            MaKhoa = info.GetString("MaKhoa");
            TenKhoa = info.GetString("TenKhoa");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaKhoa", MaKhoa);
            info.AddValue("TenKhoa", TenKhoa);
        }
        /*[JsonProperty("MaKhoa")]
        public string MaKhoa { get; set; }

        [JsonProperty("TenKhoa")]
        public string TenKhoa { get; set; }*/
    }
}
