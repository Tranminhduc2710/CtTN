using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtTracNghiem
{
    public class Class_User
    {
        private string ma;
        private string ten;
        private string matkhau;
        private string email;

        public string Ma { get => ma; set => ma = value; }
        public string Ten { get => ten; set => ten = value; }
        public string MatKhau { get => matkhau; set => matkhau = value; }
        public string Email { get => email; set => email = value; }
    }
}
