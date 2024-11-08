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
    public class Class_KetQua : ISerializable
    {
        private int MAKQ;
        private string MASV;
        private Class_BaiLam[] ketqua;
        private float Diem;
        private string ThoiGianNopBai;

        public int MaKQ { get => MAKQ; set => MAKQ = value; }
        public string MaSV { get => MASV; set => MASV = value; }
        public Class_BaiLam[] Ketqua { get => ketqua; set => ketqua = value; }
        public float diem { get => Diem; set => Diem = value; }
        public string ThoiGianNop { get => ThoiGianNopBai; set => ThoiGianNopBai = value; }
        public Class_KetQua() { }
        public Class_KetQua (string MaSV, int count)
        {
            MAKQ = SinhMaKQ();
            MASV = MaSV;
            ketqua = new Class_BaiLam[count];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaKQ", MAKQ);
            info.AddValue("MaSV", MASV);
            info.AddValue("KetQua", JsonConvert.SerializeObject(ketqua));
            info.AddValue("Diem", Diem); 
            info.AddValue("ThoiGianNopBai", ThoiGianNopBai);
        }
        public Class_KetQua(SerializationInfo info, StreamingContext context)
        {
            MAKQ = info.GetInt32("MaKQ");
            MASV = info.GetString("MaSV");
            ketqua = (Class_BaiLam[])info.GetValue("KetQua", typeof(Class_BaiLam[]));
            Diem = info.GetSingle("Diem");
            ThoiGianNopBai = info.GetString("ThoiGianNopBai");
        }
        int SinhMaKQ()
        {
            List<Class_KetQua> tongKQ = ThaoTacFile.ReadJsonFromFile<Class_KetQua>("KetQua.json");
            if (tongKQ != null) return tongKQ.Count + 1;
            return 1;
        }
        public void TinhDiem()
        {
            if (ketqua != null && ketqua.Length > 0)
            {
                float tongDiem = 0;
                foreach (Class_BaiLam bailam in ketqua)
                {
                    if (bailam != null)
                        tongDiem += bailam.TinhDiemBaiLam();
                }
                diem = tongDiem / ketqua.Length * 10;
            }
            else { diem = 0; }
        }
    }
}
