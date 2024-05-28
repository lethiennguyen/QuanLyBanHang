using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class UserControlSanPhamClass
    {
        byte[] anhspUserControl;
        string tenSP;
        string Gia;
        public UserControlSanPhamClass()
        {
           
        }
        public UserControlSanPhamClass(byte[] anhspUserControl, string tenSP, string gia)
        {
            this.anhspUserControl = anhspUserControl;
            this.tenSP = tenSP;
            Gia = gia;
        }

        public byte[] AnhspUserControl { get => anhspUserControl; set => anhspUserControl = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string Gia1 { get => Gia; set => Gia = value; }
    }
}
