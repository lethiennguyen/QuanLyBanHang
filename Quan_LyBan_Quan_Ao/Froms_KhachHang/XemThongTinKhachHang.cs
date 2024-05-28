using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Quan_LyBan_Quan_Ao.QuanLy;

namespace Quan_LyBan_Quan_Ao.Froms_KhachHang
{
    public partial class XemThongTinKhachHang : Form
    {
        public XemThongTinKhachHang()
        {
            InitializeComponent();
        }
        QuanLy.KhacHangClass KhacHang;
        public XemThongTinKhachHang(string maKh, string tenKh, string sdt, string diaChiKh, DateTime ngaysinhKH, int soluongmua, int tongTienMua)
        {
            InitializeComponent();
            TextBox_MaKH.Text = maKh;
            TextBox_TenKH.Text = tenKh;
            TextBox_SDT_KH.Text = sdt;
            ComboBox_DiaChi.Text = diaChiKh;
            DateTimePicker_NgaySinhKH.Value = ngaysinhKH;
            TextBox_SoLuongMua.Text = soluongmua.ToString();
            TextBox_TongTienMua.Text = tongTienMua.ToString();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
      
        private void CircleProgressBa_ThuongKhacHang_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_XoaKH_Click(object sender, EventArgs e)
        {
            string MaKh = TextBox_MaKH.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.Delete_KH(MaKh))
                {
                    MessageBox.Show("Xóa khách hàng", "xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng", "xóa không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bnt_SuaKH_Click(object sender, EventArgs e)
        {
            string MaKh = TextBox_MaKH.Text;
            string TenKh = TextBox_TenKH.Text;
            string Sdt = TextBox_SDT_KH.Text;
            string DiaChiKH = ComboBox_DiaChi.Text;
            DateTime NgaysinhKH = DateTimePicker_NgaySinhKH.Value;
            int Soluongmua = int.Parse(TextBox_SoLuongMua.Text);
            int TongTienMua = int.Parse(TextBox_TongTienMua.Text);
            KhacHang = new QuanLy.KhacHangClass(MaKh, TenKh, Sdt, DiaChiKH, NgaysinhKH, Soluongmua, TongTienMua);
            try
            {
               
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.UpDate_KH(KhacHang))
                {
                    MessageBox.Show("Sửa khách hàng", "Sửa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa khách hàng", "Không sửa được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
