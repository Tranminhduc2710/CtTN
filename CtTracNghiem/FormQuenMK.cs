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
    public partial class FormQuenMK : Form
    {
        bool check = true;
        public FormQuenMK(string maGV)
        {
            InitializeComponent();
        }
        public FormQuenMK()
        {
            InitializeComponent();
            check = false;
        }
        
        private void btn_tieptheo_click(object sender, EventArgs e)
        {
            if (check == true)
            {

                List<Class_GV> danhsachGiangVien = ThaoTacFile.ReadJsonFromFile<Class_GV>("GiangVien.Json");
                bool emailMatched = false;
                foreach (Class_GV giangvien in danhsachGiangVien)
                {
                    if (giangvien.Email == txt_email.Text)
                    {
                        emailMatched = true;
                        if (txt_mkmoi.Text == txt_confirm.Text)
                        {
                            ThaoTacFile.WriteJsonToFile(danhsachGiangVien, "GiangVien.json");
                            this.Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu nhập lại không khớp!");
                            return;
                        }
                    }
                }
                if (!emailMatched)
                {
                    MessageBox.Show("Email không chính xác!");
                }
            }
            else
            {
                List<Class_SV> danhsachSinhVien = ThaoTacFile.ReadJsonFromFile<Class_SV>("SinhVien.json");
                bool emailMatched = false;
                foreach (Class_SV sinhvien in danhsachSinhVien)
                {
                    if (sinhvien.Email == txt_email.Text)
                    {
                        emailMatched= true;
                        if (txt_mkmoi.Text == txt_confirm.Text)
                        {
                            sinhvien.MatKhau = txt_mkmoi.Text;
                            ThaoTacFile.WriteJsonToFile(danhsachSinhVien, "SinhVien.json");
                            this.Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu nhập lại không khớp!");
                            return;
                        }
                    }
                }
                if (!emailMatched)
                {
                    MessageBox.Show("Email không chính xác!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
