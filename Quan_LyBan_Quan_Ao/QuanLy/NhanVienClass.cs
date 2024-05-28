using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class NhanVienClass
    {
        private string _id_name;
        private string _Tennv;
        private string _Sdt;
        private string _DiaChi;
        private string _cccd;
        private DateTime _ngaysinh;
        private string _sex;
        public NhanVienClass()
        {

        }
        public NhanVienClass(string id_name, string Name, string PhoneNumber, string Address, string CCCd, DateTime dateTime, string Sex)
        {
            _id_name = id_name;
            _Tennv = Name;
            _Sdt = PhoneNumber;
            _DiaChi = Address;
            _cccd = CCCd;
            _ngaysinh = dateTime;
            _sex = Sex;
        }

        public string Id_name { get => _id_name; set => _id_name = value; }
        public string Name { get => _Tennv; set => _Tennv = value; }
        public string Phone { get => _Sdt; set => _Sdt = value; }
        public string Address { get => _DiaChi; set => _DiaChi = value; }
        public string Cccd { get => _cccd; set => _cccd = value; }
        public DateTime DateTime1 { get => _ngaysinh; set => _ngaysinh = value; }
        public string Sex { get => _sex; set => _sex = value; }
    }
}
