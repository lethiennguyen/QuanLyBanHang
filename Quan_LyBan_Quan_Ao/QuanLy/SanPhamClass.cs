using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class SanPhamClass
    {
        private string _MaSanPham;
        private string _TenSanPham;
        private string _LoaiSanPham;
        private string _Size;
        private string _SoLuong;
        private string _MauSac;
        private int _Gia;
        private byte[] _imageSanPham;

        public SanPhamClass()
        {

        }

        public SanPhamClass(string maSanPham, string tenSanPham, string loaiSanPham, string size, string soLuong, string mauSac, int gia, byte[] imageSanPham)
        {
            _MaSanPham = maSanPham;
            _TenSanPham = tenSanPham;
            _LoaiSanPham = loaiSanPham;
            _Size = size;
            _SoLuong = soLuong;
            _MauSac = mauSac;
            _Gia = gia;
            _imageSanPham = imageSanPham;
        }

        public string MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public string TenSanPham { get => _TenSanPham; set => _TenSanPham = value; }
        public string LoaiSanPham { get => _LoaiSanPham; set => _LoaiSanPham = value; }
        public string Size { get => _Size; set => _Size = value; }
        public string SoLuong { get => _SoLuong; set => _SoLuong = value; }
        public string MauSac { get => _MauSac; set => _MauSac = value; }
        public int Gia { get => _Gia; set => _Gia = value; }
        public byte[] ImageSanPham { get => _imageSanPham; set => _imageSanPham = value; }
    }
}
