using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class KhacHangClass
    {
        private string _MaKh;
        private string _TenKh;
        private string _SdtKh;
        private string _DiaChiKh;
        private DateTime _ngaysinhKH;
        private int _soluongmua;
        private int _TongTienMua;
        public KhacHangClass()
        {


        }

        public KhacHangClass(string maKh, string tenKh, string sdt, string diaChiKh, DateTime ngaysinhKH, int soluongmua, int tongTienMua)
        {
            this._MaKh = maKh;
            this._TenKh = tenKh;
            this._SdtKh = sdt;
            this._DiaChiKh = diaChiKh;
            this._ngaysinhKH = ngaysinhKH;
            this._soluongmua = soluongmua;
            this._TongTienMua = tongTienMua;
        }

        public string MaKh { get => _MaKh; set => _MaKh = value; }
        public string TenKh { get => _TenKh; set => _TenKh = value; }
        public string Sdt { get => _SdtKh; set => _SdtKh = value; }
        public string DiaChiKh { get => _DiaChiKh; set => _DiaChiKh = value; }
        public DateTime NgaysinhKH { get => _ngaysinhKH; set => _ngaysinhKH = value; }
        public int Soluongmua { get => _soluongmua; set => _soluongmua = value; }
        public int TongTienMua { get => _TongTienMua; set => _TongTienMua = value; }
    } 
}
