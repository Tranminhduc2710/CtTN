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
    public partial class FormKtraGVSV : Form
    {
        public FormKtraGVSV()
        {
            InitializeComponent();
        }

        private void btn_Gv_Click(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.ShowDialog();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormKtraGVSV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                e.Cancel = true;
        }

        private void btn_Sv_Click(object sender, EventArgs e)
        {
            FormDangNhap f = new FormDangNhap();
            f.ShowDialog();
        }
    }
}
