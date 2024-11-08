using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CtTracNghiem
{
    public partial class ThongTinGV : Form
    {
        private string _email;

        public ThongTinGV(string email)
        {
            InitializeComponent();
            _email = email; // Lưu email đăng nhập để sử dụng
        }

        private void ThongTinGV_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void LoadUserInfo()
        {
            string filePath = "GiangVien.json";

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<Class_GV> userList = JsonConvert.DeserializeObject<List<Class_GV>>(json);

                if (string.IsNullOrEmpty(_email))
                {
                    MessageBox.Show("Email đăng nhập không hợp lệ.");
                    return;
                }

                Class_GV userInfo = userList.FirstOrDefault(u => u.Email.Equals(_email, StringComparison.OrdinalIgnoreCase));

                if (userInfo != null)
                {
                    txbMaGV.Text = userInfo.Ma;
                    txbTenGV.Text = userInfo.Ten;
                    txbTaiKhoan.Text = userInfo.Email;
                    txbMatKhau.Text = userInfo.MatKhau;
                    txbKhoaGV.Text = userInfo.Khoa.TenKhoa;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thô qng tin giảng viên với email: " + _email);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thông tin giảng viên.");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGV quanly = new FormGV();
            quanly.ShowDialog();
            this.Hide();
        }
    }
}
