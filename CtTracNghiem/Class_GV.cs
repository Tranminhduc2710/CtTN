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
    public class Class_GV : Class_User, ISerializable
    {
        private Class_Khoa khoa;

        public Class_Khoa Khoa { get => khoa; set => khoa = value; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Ma", Ma);
            info.AddValue("Ten", Ten);
            info.AddValue("Email", Email);
            info.AddValue("MatKhau", MatKhau);
            info.AddValue("Khoa", khoa);
        }
        public Class_GV() { }
        public Class_GV(SerializationInfo info, StreamingContext context)
        {
            Ma = info.GetString("Ma");
            Ten = info.GetString("Ten");
            Email = info.GetString("Email");
            MatKhau = info.GetString("MatKhau");
            Khoa = (Class_Khoa)info.GetValue("Khoa", typeof(Class_Khoa));
        }
        
    }
}
