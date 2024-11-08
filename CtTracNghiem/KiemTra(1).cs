using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;
using System.Linq;


namespace CtTracNghiem
{
    public partial class KiemTra_1_ : Form
    {
        

        public KiemTra_1_(string maDT, string tenMH, string soLuongCauHoi, string thoiGianThi, string thoiGianLamBai)
        {
            InitializeComponent();
            
            DisplayDeThiInfo(maDT, tenMH, soLuongCauHoi, thoiGianThi, thoiGianLamBai);
        }

        private void DisplayDeThiInfo(string maDT, string tenMH, string soLuongCauHoi, string thoiGianThi, string thoiGianLamBai)
        {
           
            textBox3.Text = tenMH;
            textBox4.Text = thoiGianThi;
            textBox5.Text = soLuongCauHoi;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Lấy thông tin từ các TextBox trong KiemTra_1_
            string maDT = ""; // Cần thêm TextBox cho mã đề thi nếu chưa có
            string tenMH = textBox3.Text;
            string soLuongCauHoi = textBox5.Text;
            string thoiGianThi = textBox4.Text;
            string thoiGianLamBai = ""; // Cần thêm TextBox cho thời gian làm bài nếu chưa có

            // Tạo instance mới của KiemTra_2_ với các tham số
            KiemTra_2_ formKiemTra2 = new KiemTra_2_(maDT, tenMH, soLuongCauHoi, thoiGianThi, thoiGianLamBai);

            // Hiển thị form KiemTra_2_
            formKiemTra2.Show();

            // Ẩn form hiện tại (KiemTra_1_)
            this.Hide();
        }
    }
}
