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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btn_DangNhap_Click(object sender, EventArgs e)
        {

            // Đọc danh sách giảng viên từ file JSON
            List<Class_GV> danhSachGiangVien = ThaoTacFile.ReadJsonFromFile<Class_GV>("GiangVien.json");

            // Đọc danh sách sinh viên từ file JSON
            List<Class_SV> danhSachSinhVien = ThaoTacFile.ReadJsonFromFile<Class_SV>("SinhVien.json");

            // Lấy thông tin người dùng nhập
            string tenDangNhap = textDangNhapGV.Text;
            string matKhau = textMatKhauGV.Text;

            this.Hide();
            // Kiểm tra thông tin đăng nhập trong danh sách giảng viên
            bool isAuthenticatedGV = danhSachGiangVien.Any(gv => gv.Email == tenDangNhap && gv.MatKhau == matKhau);

            if (isAuthenticatedGV)
            {
                // Nếu đăng nhập thành công với giảng viên, mở FormGV
                string username = textDangNhapGV.Text;
                ThongTinGV formGV = new ThongTinGV(tenDangNhap);
                formGV.Show();
                this.Hide();
            }
            else
            {
                // Kiểm tra thông tin đăng nhập trong danh sách sinh viên
                bool isAuthenticatedSV = danhSachSinhVien.Any(sv => sv.Email == tenDangNhap && sv.MatKhau == matKhau);


                if (isAuthenticatedSV)
                {
                    // Nếu đăng nhập thành công với sinh viên, mở KiemTra
                    string username = textDangNhapGV.Text;
                    ThongTinSV formttsv = new ThongTinSV(tenDangNhap);
                    formttsv.Show();
                    this.Hide();
                }
                else
                {
                    // Thông báo lỗi nếu đăng nhập thất bại
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormDangNhap_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn muốn thoát chương trình?", "Canh bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            //e.Cancel = true;
        }

        private void textDangNhapGV_TextChanged(object sender, EventArgs e)
        {
            /*List<Class_GV> danhSachGiangVien = ThaoTacFile.ReadJsonFromFile<Class_GV>("GiangVien.json");

            // Lấy thông tin người dùng nhập
            string tenDangNhap = textDangNhapGV.Text;
            string matKhau = textMatKhauGV.Text;

            // Kiểm tra thông tin đăng nhập
            bool isAuthenticated = danhSachGiangVien.Any(gv => gv.Email == tenDangNhap && gv.MatKhau == matKhau);

            if (isAuthenticated)
            {
                // Nếu đăng nhập thành công, mở FormGV
                FormGV formGV = new FormGV();
                formGV.ShowDialog();
                this.Hide();
            }
            else
            {
                // Thông báo lỗi nếu đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void textMatKhauGV_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
