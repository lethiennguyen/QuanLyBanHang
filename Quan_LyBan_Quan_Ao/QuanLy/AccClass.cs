using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class AccClass
    {
        private string TenTaiKhoan;
        private string MatKhau;

        public AccClass()
        {

        }
        public AccClass(string tenTaiKhoan, string matKhau)
        {
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
        }

        public string TenTaiKhoan1 { get => TenTaiKhoan; set => TenTaiKhoan = value; }
        public string MatKhau1 { get => MatKhau; set => MatKhau = value; }
    }
}
