using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtTracNghiem
{
    public partial class TaoBaiKT : Form
    {
        public TaoBaiKT()
        {
            InitializeComponent();
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*private void btn_tao_Click(object sender, EventArgs e)
        {
            string MaLop = txtmalophoc.Text;
            string MaDT = txtmadethi.Text;
            string TenMH= txttenmon.Text;
            int SoCau = int.Parse(txtsocau.Text);
            int ThoiGianThi = int.Parse(txtthoigian.Text);
            string ThoiGianLamBai = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            List<Class_Lop> danhSachLop = ThaoTacFile.ReadJsonFromFile<Class_Lop>("Lop.json");
            List<Class_DeThi> danhSachDeThi = ThaoTacFile.ReadJsonFromFile<Class_DeThi>("DeThi.json");

            // Kiểm tra xem MaDT đã tồn tại hay chưa
            var deThiExists = danhSachDeThi.FirstOrDefault(d => d.MaDT == MaDT);

            if (deThiExists != null)
            {
                // Nếu MaDT đã tồn tại, mở Form TaoBaiKT_1
                TaoBaiKT_1_ form1 = new TaoBaiKT_1_(deThiExists);
                form1.ShowDialog();
                return; // Ngăn không cho tiếp tục tạo đề thi mới
            }
            Class_DeThi deThi = new Class_DeThi(MaDT, TenMH, SoCau, ThoiGianThi, ThoiGianLamBai);
            deThi.DanhSachCauHoi = new List<string>();
            ThaoTacFile.WriteJsonToConstantFile(deThi, "DeThi.json");
            foreach (Class_Lop lop in danhSachLop)
            {
                if (lop.MaLop == MaLop)
                {
                    lop.ThemDeThi(deThi.MaDT);
                    ThaoTacFile.WriteJsonToFile(danhSachLop, "Lop.json");
                    break;
                }    
            }
            this.Close();
        }*/

        private void tao_Click(object sender, EventArgs e)
        {
            string MaLop = txtmalophoc.Text.Trim();
            string MaDT = txtmadethi.Text.Trim();
            string TenMH = txttenmon.Text.Trim();
            int SoLuongCauHoi;
            if (!int.TryParse(txtsocau.Text.Trim(), out SoLuongCauHoi))
            {
                MessageBox.Show("Số câu hỏi không hợp lệ. Vui lòng nhập một số nguyên hợp lệ.");
                return; // Ngừng thực hiện nếu dữ liệu không hợp lệ
            }

            int ThoiGianThi;
            if (!int.TryParse(txtthoigian.Text.Trim(), out ThoiGianThi))
            {
                MessageBox.Show("Thời gian thi không hợp lệ. Vui lòng nhập một số nguyên hợp lệ.");
                return; // Ngừng thực hiện nếu dữ liệu không hợp lệ
            }
            string ThoiGianLamBai = dateTimePicker1.Value.ToString("dd/MM/yyyy");
            List<Class_Lop> danhSachLop = ThaoTacFile.ReadJsonFromFile<Class_Lop>("Lop.json");
            List<Class_DeThi> danhSachDeThi = ThaoTacFile.ReadJsonFromFile<Class_DeThi>("DeThi.json");

            // Kiểm tra xem MaDT đã tồn tại hay chưa
            var deThiExists = danhSachDeThi.FirstOrDefault(d => d.MaDT == MaDT);

            if (deThiExists != null)
            {
                /*// Nếu MaDT đã tồn tại, mở Form TaoBaiKT_1
                TaoBaiKT_1_ form1 = new TaoBaiKT_1_(deThiExists);
                form1.ShowDialog();
                return; // Ngăn không cho tiếp tục tạo đề thi mới*/
                MessageBox.Show("Mã đề thi đã tồn tại. Vui lòng nhập mã đề thi khác.");
                return; // Ngừng thực hiện nếu mã đề thi đã tồn tại
            }
           

            // Ghi danh sách đề thi vào file
            ThaoTacFile.WriteJsonToFile(danhSachDeThi, "DeThi.json");
            int SoCau = int.Parse(txtsocau.Text);
            Class_DeThi deThi = new Class_DeThi(MaDT, TenMH, SoCau, ThoiGianThi, ThoiGianLamBai);
            deThi.DanhSachCauHoi = new List<Class_CauHoi>();
            ThaoTacFile.WriteJsonToConstantFile(deThi, "DeThi.json");
            foreach (Class_Lop lop in danhSachLop)
            {
                if (lop.MaLop == MaLop)
                {
                    lop.ThemDeThi(deThi.MaDT);
                    ThaoTacFile.WriteJsonToFile(danhSachLop, "Lop.json");
                    break;
                }
            }
            this.Close();
        }
    }
}
