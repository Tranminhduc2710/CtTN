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

namespace CtTracNghiem
{
    public partial class KiemTra : Form
    {
        public KiemTra()
        {
            InitializeComponent();
            LoadDeThiData();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng của lớp KiemTra
            KiemTra formKiemTra = new KiemTra();

            // Hiển thị bảng KiemTra
            formKiemTra.ShowDialog(); // Hoặc sử dụng formKiemTra.Show() tùy theo nhu cầu
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //ThongTinGV formGV  = new ThongTinGV();
           //formGV.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDeThiData()
        {
            string filePath = "DeThi.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                List<Class_DeThi> danhSachDeThi = JsonConvert.DeserializeObject<List<Class_DeThi>>(jsonContent);

                dataGridView1.Rows.Clear();
                foreach (var deThi in danhSachDeThi)
                {
                    dataGridView1.Rows.Add(
                        deThi.MaDT,
                        deThi.TenMH,
                        deThi.SoLuongCauHoi,
                        deThi.ThoiGianThi,
                        deThi.ThoiGianLamBai
                    );
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy file DeThi.json", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string maDT = row.Cells["Column1"].Value.ToString();
                string tenMH = row.Cells["Column2"].Value.ToString();
                string soLuongCauHoi = row.Cells["Column4"].Value.ToString();
                string thoiGianThi = row.Cells["Column5"].Value.ToString();
                string thoiGianLamBai = row.Cells["Column3"].Value.ToString();

                KiemTra_1_ formKiemTra1 = new KiemTra_1_(maDT, tenMH, soLuongCauHoi, thoiGianThi, thoiGianLamBai);

                formKiemTra1.ShowDialog();
            }
        }
    }
}
