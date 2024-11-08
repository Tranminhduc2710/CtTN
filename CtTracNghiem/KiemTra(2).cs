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
    public partial class KiemTra_2_ : Form
    {
        private Timer examTimer;
        private int remainingTime;
        public KiemTra_2_(string maDT, string tenMH, string soLuongCauHoi, string thoiGianThi, string thoiGianLamBai)
        {
            InitializeComponent();
            // Hiển thị thông tin đề thi
            textBox3.Text = tenMH;
            textBox4.Text = soLuongCauHoi;
            textBox5.Text = thoiGianThi;

            // Khởi tạo thời gian đếm ngược
            if (int.TryParse(thoiGianThi, out int minutes))
            {
                remainingTime = minutes * 60; // Chuyển đổi phút thành giây
                StartTimer();
            }
            else
            {
                MessageBox.Show("Thời gian thi không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void StartTimer()
        {
            examTimer = new Timer();
            examTimer.Interval = 1000; // 1 giây
            examTimer.Tick += ExamTimer_Tick;
            examTimer.Start();
        }

        private void ExamTimer_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                UpdateTimerDisplay();
            }
            else
            {
                examTimer.Stop();
                MessageBox.Show("Hết thời gian làm bài!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Thêm code để xử lý khi hết thời gian (ví dụ: tự động nộp bài)
            }
        }

        private void UpdateTimerDisplay()
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime % 60;
            label3.Text = $"{minutes:D2}:{seconds:D2}";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
