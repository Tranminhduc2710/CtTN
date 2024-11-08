using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CtTracNghiem
{
    [Serializable]

    public class Class_DeThi : ISerializable
    {
        public string MaDT { get; set; }
        public string TenMH { get; set; }
        public string ThoiGianLamBai { get; set; }
        public int SoLuongCauHoi { get; set; }
        public int ThoiGianThi { get; set; }
        public List<Class_CauHoi> DanhSachCauHoi { get; set; }
        public List<Class_KetQua> DanhSachKetQua { get; set; }

        public Class_DeThi()
        {
            DanhSachCauHoi = new List<Class_CauHoi>();
        }


        public Class_DeThi(string maDeThi, string tenMonHoc, int soCau, int thoiGianThi, string thoiGianLamBai)
        {
            MaDT = maDeThi;
            TenMH = tenMonHoc;
            SoLuongCauHoi = soCau;
            ThoiGianThi = thoiGianThi;
            ThoiGianLamBai = thoiGianLamBai;
            DanhSachCauHoi = new List<Class_CauHoi>();
            DanhSachKetQua = new List<Class_KetQua>();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MaDT", MaDT);
            info.AddValue("TenMH", TenMH);
            info.AddValue("ThoiGianLamBai", ThoiGianLamBai);
            info.AddValue("SoLuongCauHoi", SoLuongCauHoi);
            info.AddValue("ThoiGianThi", ThoiGianThi);
            info.AddValue("DanhSachCauHoi", JsonConvert.SerializeObject(DanhSachCauHoi));
            info.AddValue("DanhSachKetQua", JsonConvert.SerializeObject(DanhSachKetQua));
        }

        public Class_DeThi(SerializationInfo info, StreamingContext context)
        {

            MaDT = info.GetString("MaDT");
            TenMH = info.GetString("TenMH");
            ThoiGianLamBai = info.GetString("ThoiGianLamBai");
            SoLuongCauHoi = info.GetInt32("SoLuongCauHoi");
            ThoiGianThi = info.GetInt32("ThoiGianThi");
           
            var danhSachCauHoiString = info.GetString("DanhSachCauHoi");
            try
            {
                DanhSachCauHoi = JsonConvert.DeserializeObject<List<Class_CauHoi>>(danhSachCauHoiString);
            }
            catch
            {
                // Nếu không thể deserialize thành List<Class_CauHoi>, thử deserialize thành List<string>
                var danhSachChuoi = JsonConvert.DeserializeObject<List<string>>(danhSachCauHoiString);
                DanhSachCauHoi = danhSachChuoi.Select(s => new Class_CauHoi { NoiDung = s }).ToList();
            }
            DanhSachKetQua = JsonConvert.DeserializeObject<List<Class_KetQua>>(info.GetString("DanhSachKetQua"));
        }

        // Phương thức để thêm câu hỏi vào đề thi
        public void ThemCauHoi(Class_CauHoi cauHoi)
        {
            DanhSachCauHoi.Add(cauHoi);
            SoLuongCauHoi = DanhSachCauHoi.Count;
        }

        // Phương thức để xóa câu hỏi khỏi đề thi
        public void XoaCauHoi(string maCH)
        {
            DanhSachCauHoi.RemoveAll(ch => ch.MaCH == maCH);
            SoLuongCauHoi = DanhSachCauHoi.Count;
        }
    }
}