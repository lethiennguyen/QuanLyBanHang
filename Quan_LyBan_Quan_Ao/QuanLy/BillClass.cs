using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class BillClass
    {
        private string MaBill;
        private string MaNV;
        private string MaKH;
        private string _MaSanPham;
        private string _TenSanPham;
        //private string _LoaiSanPham;
        private string _Size;
        private string _MauSac;
        private int _Gia;
        private int _SoLuongMua;
        private DateTime _NgayMua;
        private decimal TongTien;
        private string _TrangThaiThanhToan;
        public BillClass()
        {
            
        }

        public BillClass(string maBill, string maNV, string maKH, string maSanPham, string tenSanPham, string size, string mauSac, int gia, int soLuongMua, DateTime ngayMua, decimal tongTien, string trangThaiThanhToan)
        {
            MaBill = maBill;
            MaNV = maNV;
            MaKH = maKH;
            _MaSanPham = maSanPham;
            _TenSanPham = tenSanPham;
           // _LoaiSanPham = loaiSanPham;
            _Size = size;
            _MauSac = mauSac;
            _Gia = gia;
            _SoLuongMua = soLuongMua;
            _NgayMua = ngayMua;
            TongTien = tongTien;
            _TrangThaiThanhToan = trangThaiThanhToan;
        }

        public string MaBill1 { get => MaBill; set => MaBill = value; }
        public string MaNV1 { get => MaNV; set => MaNV = value; }
        public string MaKH1 { get => MaKH; set => MaKH = value; }
        public string MaSanPham { get => _MaSanPham; set => _MaSanPham = value; }
        public string TenSanPham { get => _TenSanPham; set => _TenSanPham = value; }
       // public string LoaiSanPham { get => _LoaiSanPham; set => _LoaiSanPham = value; }
        public string Size { get => _Size; set => _Size = value; }
        public string MauSac { get => _MauSac; set => _MauSac = value; }
        public int Gia { get => _Gia; set => _Gia = value; }
        public int SoLuongMua { get => _SoLuongMua; set => _SoLuongMua = value; }
        public DateTime NgayMua { get => _NgayMua; set => _NgayMua = value; }
        public decimal TongTien1 { get => TongTien; set => TongTien = value; }
        public string TrangThaiThanhToan { get => _TrangThaiThanhToan; set => _TrangThaiThanhToan = value; }
        public void TinhTongTien()
        {
            TongTien = (Gia * SoLuongMua);

        }
        public void TinhTongTien_VAT()
        {
            TongTien = (Gia * SoLuongMua) + ((Gia * SoLuongMua) * 0.1m);

        }
    }

}
