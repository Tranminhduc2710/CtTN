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
    public partial class FormGV : Form
    {
        public FormGV()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DSBaiKT dsKT = new DSBaiKT();
            dsKT.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
