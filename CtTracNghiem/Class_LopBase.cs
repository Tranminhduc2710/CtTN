using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtTracNghiem
{
    public abstract class Class_LopBase
    {
        public abstract void ThemDeThi(string deThi);
        public abstract List<string> getDanhSachDeThi(string MaLop);
    }
}
