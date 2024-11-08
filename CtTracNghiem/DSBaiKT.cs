using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CtTracNghiem
{
    public partial class DSBaiKT : Form
    {
        public DSBaiKT()
        {
            InitializeComponent();
            LoadDanhSachLop(); // Đọc danh sách lớp từ file
            LoadDanhSachDeThi(); // Đọc danh sách đề thi từ file
            LoadDanhSachBaiKT(); // Hiển thị danh sách bài kiểm tra
            listView2.DoubleClick += ListView2_DoubleClick;
        }
        private List<Class_Lop> danhSachLop = new List<Class_Lop>(); // Danh sách các lớp
        private List<Class_DeThi> danhSachDeThi = new List<Class_DeThi>(); // Danh sách các đề thi

        private void ListView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView2.SelectedItems[0];
                string maDeThi = selectedItem.SubItems[0].Text; // Giả sử MaDT là cột đầu tiên

                // Đọc danh sách đề thi từ file
                List<Class_DeThi> danhSachDeThi = ThaoTacFile.ReadJsonFromFile<Class_DeThi>("DeThi.json");

                // Tìm đề thi được chọn
                Class_DeThi selectedDeThi = danhSachDeThi.FirstOrDefault(d => d.MaDT == maDeThi);

                if (selectedDeThi != null)
                {
                    // Mở form TaoBaiKT_1_ với đề thi được chọn
                    TaoBaiKT_1_ formTaoBaiKT = new TaoBaiKT_1_(selectedDeThi);
                    formTaoBaiKT.ShowDialog();

                    // Sau khi đóng form TaoBaiKT_1_, cập nhật lại danh sách nếu cần
                    LoadDanhSachBaiKT();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin đề thi.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadDanhSachLop()
        {
            danhSachLop = ThaoTacFile.ReadJsonFromFile<Class_Lop>("Lop.json");
        }

        private void LoadDanhSachDeThi()
        {
            danhSachDeThi = ThaoTacFile.ReadJsonFromFile<Class_DeThi>("DeThi.json");
        }

        private void LoadDanhSachBaiKT()
        {
            listView2.Items.Clear();
            foreach (Class_DeThi deThi in danhSachDeThi)
            {
                ListViewItem item = new ListViewItem(deThi.MaDT);
                item.SubItems.Add(deThi.MaDT);
                item.SubItems.Add(deThi.TenMH);
                item.SubItems.Add(deThi.SoLuongCauHoi.ToString());
                item.SubItems.Add(deThi.ThoiGianThi.ToString());
                item.SubItems.Add(deThi.ThoiGianLamBai);
                listView2.Items.Add(item);
            }
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ form
                string maLopHoc = txtmalophoc.Text.Trim();
                string maDeThi = textBox1.Text.Trim();
                string tenMonHoc = textBox2.Text.Trim();

                if (string.IsNullOrEmpty(maLopHoc) || string.IsNullOrEmpty(maDeThi) || string.IsNullOrEmpty(tenMonHoc))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Mã lớp học, Mã đề thi và Tên môn học.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox3.Text, out int soCauHoi) || soCauHoi <= 0)
                {
                    MessageBox.Show("Số câu hỏi phải là một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(textBox4.Text, out int thoiGianThiMoi) || thoiGianThiMoi <= 0)
                {
                    MessageBox.Show("Thời gian thi phải là một số nguyên dương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string thoiGianLamBaiMoi = dateTimePicker1.Value.ToString("dd/MM/yyyy");

                // Tạo đối tượng Class_DeThi mới
                Class_DeThi newDeThi = new Class_DeThi
                {
                    MaDT = "DT" + (danhSachDeThi.Count + 1).ToString("D3"),
                    TenMH = tenMonHoc,
                    SoLuongCauHoi = soCauHoi,
                    ThoiGianThi = thoiGianThiMoi,
                    ThoiGianLamBai = thoiGianLamBaiMoi
                };
                newDeThi.MaDT = textBox1.Text.Trim(); 
                newDeThi.TenMH = textBox2.Text.Trim(); // Set a default name or prompt user for input
                newDeThi.ThoiGianLamBai = DateTime.Now.ToString("dd/MM/yyyy"); // Set a default time or prompt user for input
                newDeThi.SoLuongCauHoi = 0;
                if (int.TryParse(textBox4.Text.Trim(), out int thoiGianThi))
                {
                    newDeThi.ThoiGianThi = thoiGianThi;
                }
                else
                {
                    MessageBox.Show("Thời gian thi không hợp lệ. Vui lòng nhập một số nguyên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngừng thực hiện nếu dữ liệu không hợp lệ
                }

                // Thêm đề thi mới vào danh sách
                danhSachDeThi.Add(newDeThi);

                // Ghi toàn bộ danh sách (bao gồm đề thi mới) vào file JSON
                ThaoTacFile.WriteJsonToFile(danhSachDeThi, "DeThi.json");

                // Cập nhật hiển thị danh sách bài kiểm tra
                LoadDanhSachBaiKT();

                // Thêm đề thi vào lớp học tương ứng
                /*Class_Lop lop = danhSachLop.Find(l => l.MaLop == maLopHoc);
                if (lop != null)
                {
                    lop.ThemDeThi(maDeThi);
                    ThaoTacFile.WriteJsonToFile(danhSachLop, "Lop.json");
                }
                else
                {
                    MessageBox.Show($"Không tìm thấy lớp với mã {maLopHoc}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }*/

                // Clear input fields
                txtmalophoc.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Value = DateTime.Now;

                MessageBox.Show("Bài kiểm tra mới đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Check if there is a selected item
            if (listView2.SelectedItems.Count > 0)
            {
                // Confirm deletion
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bài kiểm tra đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Remove the selected item from the ListView
                    listView2.Items.Remove(listView2.SelectedItems[0]);
                    MessageBox.Show("Bài kiểm tra đã được xóa thành công!", "Thông báo");
                }
            }
            else
            {
                // Notify user if no item is selected
                MessageBox.Show("Vui lòng chọn một bài kiểm tra để xóa.", "Thông báo");
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
