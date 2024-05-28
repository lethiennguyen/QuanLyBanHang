using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class KhachHangClass
    {
        private string _MaKh;
        private string _TenKh;
        private string _Sdt;
        private string _DiaChiKh;
        private DateTime _ngaysinhKH;
        private int _soluongmua;
        private float _TongTienMua;
        public KhachHangClass()
        {


        }
        public KhachHangClass(string _MaKh,string _TenKh, string _Sdt, string _DiaChiKh, DateTime _ngaysinhKH, int _soluongmua, float _TongTienMua)
        {
            _MaKh = MaKh;
            _TenKh = TenKh;
            _Sdt = Sdt;
            _DiaChiKh = DiaChiKh;
            _ngaysinhKH = ngaysinhKH;
            _soluongmua = Soluongmua;
            _TongTienMua = TongTienMua;
        }

        public string MaKh { get => _MaKh; set => _MaKh = value; }
        public string TenKh { get => _TenKh; set => _TenKh = value; }
        public string Sdt { get => _Sdt; set => _Sdt = value; }
        public string DiaChiKh { get => _DiaChiKh; set => _DiaChiKh = value; }
        public DateTime Ngaysinh { get => _ngaysinh; set => _ngaysinh = value; }
        public int Soluongmua { get => _soluongmua; set => _soluongmua = value; }
        public float TongTienMua { get => _TongTienMua; set => _TongTienMua = value; }     
    }
}
