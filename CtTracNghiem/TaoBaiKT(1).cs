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
    public partial class TaoBaiKT_1_ : Form
    {
        private Class_DeThi currentDeThi;
        public TaoBaiKT_1_(Class_DeThi deThi)
        {
            InitializeComponent();
            LoadData(deThi);
            currentDeThi = deThi;

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData(Class_DeThi deThi)
        {
            // Thêm cột vào ListView
            listView1.Columns.Add("MaDT", 100);
            listView1.Columns.Add("TenMH", 100);
            listView1.Columns.Add("ThoiGianLamBai", 100);
            listView1.Columns.Add("SoLuongCauHoi", 100);
            listView1.Columns.Add("ThoiGianThi", 100);
            listView1.Columns.Add("DanhSachCauHoi", 200);
            listView1.Columns.Add("DanhSachKetQua", 200);

            // Tạo một dòng mới cho ListView
            var item = new ListViewItem(deThi.MaDT);
            item.SubItems.Add(deThi.TenMH);
            item.SubItems.Add(deThi.ThoiGianLamBai);
            item.SubItems.Add(deThi.SoLuongCauHoi.ToString());
            item.SubItems.Add(deThi.ThoiGianThi.ToString());
            item.SubItems.Add(string.Join(", ", deThi.DanhSachCauHoi));
            item.SubItems.Add("Chưa có kết quả"); // Hoặc lấy từ một nguồn nào đó nếu có
            item.SubItems.Add(string.Join(", ", deThi.DanhSachCauHoi.Select(ch => ch.MaCH)));
            listView1.Items.Add(item);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maCH = textBox1.Text;
            string cauHoi = textBox3.Text;
            string dapAn = textBox2.Text;

            if (!string.IsNullOrWhiteSpace(maCH) && !string.IsNullOrWhiteSpace(cauHoi) && !string.IsNullOrWhiteSpace(dapAn))
            {
                dataGridView1.Rows.Add(maCH, cauHoi, dapAn);
                currentDeThi.DanhSachCauHoi.Add(new Class_CauHoi
                {
                    MaCH = maCH,
                    NoiDung = cauHoi,
                    DapAn = dapAn
                });

                // Cập nhật file DeThi.json
                UpdateDeThiJson();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
            }
        }
        private void UpdateDeThiJson()
        {
            // Đọc danh sách đề thi hiện tại từ file
            List<Class_DeThi> danhSachDeThi = ThaoTacFile.ReadJsonFromFile<Class_DeThi>("DeThi.json");

            // Tìm và cập nhật đề thi hiện tại trong danh sách
            var index = danhSachDeThi.FindIndex(d => d.MaDT == currentDeThi.MaDT);
            if (index != -1)
            {
                danhSachDeThi[index] = currentDeThi;
            }
            else
            {
                danhSachDeThi.Add(currentDeThi);
            }

            // Ghi lại danh sách đề thi vào file
            ThaoTacFile.WriteJsonToFile(danhSachDeThi, "DeThi.json");
        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
