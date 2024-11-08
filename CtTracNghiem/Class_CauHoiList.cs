using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CtTracNghiem
{
    public delegate bool KiemTraDieuKien(string MaCH);
    public class Class_CauHoiList : ICauHoiList
    {
        private List<string> danhSachCauHoi;
        public List<string> DanhSachCauHoi { get => danhSachCauHoi; set => danhSachCauHoi = value; }
        public Class_CauHoiList(string MaDT)
        {
            danhSachCauHoi = new List<string>();
            List<Class_DeThi> danhSachDeThi = ThaoTacFile.ReadJsonFromFile<Class_DeThi>("DeThi.json");
            foreach (Class_DeThi dethi in danhSachDeThi)
            {
                if (dethi.MaDT == MaDT)
                {
                    danhSachCauHoi.AddRange(dethi.DanhSachCauHoi.Select(ch => ch.MaCH));
                    break;
                }
            }
        }
        //thêm câu hỏi vào list
        public static Class_CauHoiList operator +(Class_CauHoiList lhs, string MaCH)
        {
            lhs.DanhSachCauHoi.Add(MaCH);
            return lhs;
        }
        
        //xóa câu hỏi dựa trên điều kiện
        public void XoaCauHoi(KiemTraDieuKien dieuKien)
        {
            for (int i = danhSachCauHoi.Count - 1; i >= 0; i--)
            {
                if (dieuKien(danhSachCauHoi[i]))
                {
                    danhSachCauHoi.RemoveAt(i);
                }
            }
        }
    }
}
