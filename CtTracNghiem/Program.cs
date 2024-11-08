using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtTracNghiem
{
    /*public static class danhsach*/
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormKtraGVSV());

            // Tạo danh sách lớp học
            List<Class_Lop> danhSachLop = new List<Class_Lop>
            {
                new Class_Lop
                {
                    MaLop = "L001",
                    TenLop = "Lớp 1",
                    MaGV = "GV001",
                    DanhSachSinhVien = new List<string> { "SV001", "SV002", "SV003" },
                    DanhSachDeThi = new List<string> { "DT001", "DT002" }
                },
                new Class_Lop
                {
                    MaLop = "L002",
                    TenLop = "Lớp 2",
                    MaGV = "GV002",
                    DanhSachSinhVien = new List<string> { "SV004", "SV005" },
                    DanhSachDeThi = new List<string> { "DT003" }
                }
            };

            // Lưu danh sách lớp vào tệp JSON
            string filePath = "Lop.json";
            ThaoTacFile.WriteJsonToFile(danhSachLop, filePath);

            Console.WriteLine($"Đã tạo tệp JSON: {filePath}");

            // Tạo danh sách giảng viên
            List<Class_GV> danhSachGiangVien = new List<Class_GV>
            {
                new Class_GV
                {
                    Ma = "GV001",
                    Ten = "Nguyễn An",
                    Email = "annguyen@example.com",
                    MatKhau = "123456",
                    Khoa = new Class_Khoa
                    {
                        MaKhoa = "K001",
                        TenKhoa = "Khoa Công Nghệ Thông Tin"
                    }
                },
                new Class_GV
                {
                    Ma = "GV002",
                    Ten = "Trần Minh Đức",
                    Email = "ductran@example.com",
                    MatKhau = "123456",
                    Khoa = new Class_Khoa
                    {
                        MaKhoa = "K002",
                        TenKhoa = "Khoa Toán - Tin"
                    }
                }
            };

            // Lưu danh sách giảng viên vào tệp JSON
            string filePath1 = "GiangVien.json";
            ThaoTacFile.WriteJsonToFile(danhSachGiangVien, filePath1);

            Console.WriteLine($"Đã tạo tệp JSON: {filePath1}");

            // Tạo danh sách sinh viên mẫu
            List<Class_SV> sinhVienList = new List<Class_SV>
            {
                new Class_SV { Ma = "SV001", Ten = "Trịnh Phương Tuấn", Email = "tuantrinh@example.com", MatKhau = "123456", MaLop = new List<string> { "L001", "L002" } },
                new Class_SV { Ma = "SV002", Ten = "Trần Đức Minh", Email = "minhtran@example.com", MatKhau = "123456", MaLop = new List<string> { "L001" } },
                new Class_SV { Ma = "SV003", Ten = "Dương Hoàng", Email = "hoangduong@example.com", MatKhau = "123456", MaLop = new List<string> { "L003", "L004" } }
            };

            // Ghi danh sách sinh viên vào tệp JSON
            string filePath2 = "SinhVien.json";
            ThaoTacFile.WriteJsonToFile(sinhVienList, filePath2);

            // Tạo danh sách câu hỏi cho đề 1
            List<Class_CauHoi> danhSachCauHoiDe1 = new List<Class_CauHoi>
            {
                new Class_CauHoi("CH01", "Câu hỏi 1: Nội dung câu hỏi 1", "A"),
                new Class_CauHoi("CH02", "Câu hỏi 2: Nội dung câu hỏi 2", "B"),
                new Class_CauHoi("CH03", "Câu hỏi 3: Nội dung câu hỏi 3", "C"),
                new Class_CauHoi("CH04", "Câu hỏi 4: Nội dung câu hỏi 4", "D"),
                new Class_CauHoi("CH05", "Câu hỏi 5: Nội dung câu hỏi 5", "A"),
                new Class_CauHoi("CH06", "Câu hỏi 6: Nội dung câu hỏi 6", "B"),
                new Class_CauHoi("CH07", "Câu hỏi 7: Nội dung câu hỏi 7", "C"),
                new Class_CauHoi("CH08", "Câu hỏi 8: Nội dung câu hỏi 8", "D"),
                new Class_CauHoi("CH09", "Câu hỏi 9: Nội dung câu hỏi 9", "A"),
                new Class_CauHoi("CH10", "Câu hỏi 10: Nội dung câu hỏi 10", "B")
            };

            // Tạo danh sách câu hỏi cho đề 2
            List<Class_CauHoi> danhSachCauHoiDe2 = new List<Class_CauHoi>
            {
                new Class_CauHoi("CH11", "Câu hỏi 1: Nội dung câu hỏi 1 (Đề 2)", "A"),
                new Class_CauHoi("CH12", "Câu hỏi 2: Nội dung câu hỏi 2 (Đề 2)", "B"),
                new Class_CauHoi("CH13", "Câu hỏi 3: Nội dung câu hỏi 3 (Đề 2)", "C"),
                new Class_CauHoi("CH14", "Câu hỏi 4: Nội dung câu hỏi 4 (Đề 2)", "D"),
                new Class_CauHoi("CH15", "Câu hỏi 5: Nội dung câu hỏi 5 (Đề 2)", "A"),
                new Class_CauHoi("CH16", "Câu hỏi 6: Nội dung câu hỏi 6 (Đề 2)", "B"),
                new Class_CauHoi("CH17", "Câu hỏi 7: Nội dung câu hỏi 7 (Đề 2)", "C"),
                new Class_CauHoi("CH18", "Câu hỏi 8: Nội dung câu hỏi 8 (Đề 2)", "D"),
                new Class_CauHoi("CH19", "Câu hỏi 9: Nội dung câu hỏi 9 (Đề 2)", "A"),
                new Class_CauHoi("CH20", "Câu hỏi 10: Nội dung câu hỏi 10 (Đề 2)", "B")
            };

            // Tạo đề thi
            List<Class_DeThi> danhSachDeThi = new List<Class_DeThi>
            {
                new Class_DeThi("DT001", "Môn Học 1", 10, 1,  DateTime.Now.ToString("dd/MM/yyyy"))
                {
                    DanhSachCauHoi = danhSachCauHoiDe1
                },
                new Class_DeThi("DT002", "Môn Học 2", 10, 1, DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"))
                {
                    DanhSachCauHoi = danhSachCauHoiDe2
                }
            };

            // Serialize danh sách đề thi thành JSON
            string serializedJson = JsonConvert.SerializeObject(danhSachDeThi, Formatting.Indented);

            // Ghi vào file DeThi.json
            File.WriteAllText("DeThi.json", serializedJson);

            Console.WriteLine("File DeThi.json đã được tạo thành công!");
        }

    
    }
}
