using System.IO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CtTracNghiem
{
    public partial class ThongTinSV : Form
    {
        private string _username;
        private void LoadUserInfo()
        {
            string filePath = "SinhVien.json"; // Đường dẫn đến file JSON

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<Class_SV> userList = JsonConvert.DeserializeObject<List<Class_SV>>(json);

                Class_SV userInfo = userList.FirstOrDefault(u => u.Email.Equals(_username, StringComparison.OrdinalIgnoreCase));
                if (userInfo != null)
                {
                    txbMaSV.Text = userInfo.Ma;
                    txbTenSV.Text = userInfo.Ten;
                    txbTaiKhoan.Text = userInfo.Email;
                    txbMatKhauSV.Text = userInfo.MatKhau;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file thông tin người dùng.");
            }
        }

        public ThongTinSV(string username)
        {
            InitializeComponent();
            //this.FormClosed += ThongTinSV_FormClosed; // Đăng ký sự kiện FormClosed
            _username = username; // Lưu tên đăng nhập để sử dụng
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng của lớp KiemTra
            KiemTra formKiemTra = new KiemTra();

            // Hiển thị bảng KiemTra
            formKiemTra.ShowDialog(); // Hoặc sử dụng formKiemTra.Show() tùy theo nhu cầu
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txbTenSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbMatKhauSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThongTinSV_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }
    }
}
