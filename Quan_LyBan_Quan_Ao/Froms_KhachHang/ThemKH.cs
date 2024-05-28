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
    public partial class ThemKH : Form
    {
        
        public ThemKH()
        {
            InitializeComponent();
        }
        public ThemKH(string maKh, string tenKh, string sdt, string diaChiKh, DateTime ngaysinhKH, int soluongmua, int tongTienMua)
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
        QuanLy.KhacHangClass khacHang;
        private void InsertKhachHang_Click(object sender, EventArgs e)
        {
            string maKh = this.TextBox_MaKH.Text;
            string tenKh = this.TextBox_TenKH.Text;
            string sdt = this.TextBox_SDT_KH.Text;
            string diaChiKh = this.ComboBox_DiaChi.Text;
            DateTime ngaysinhKH = this.DateTimePicker_NgaySinhKH.Value;
            int soluongmua = int.Parse(this.TextBox_SoLuongMua.Text);
            int tongTienMua = int.Parse(this.TextBox_TongTienMua.Text);
            khacHang = new QuanLy.KhacHangClass(maKh, tenKh, sdt, diaChiKh, ngaysinhKH, soluongmua, tongTienMua);
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.InsertKH(khacHang)==true)
                {
                    
                    MessageBox.Show("Thành cồng", "Thêm được", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error", "Không thêm được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button_Thoat_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }
    }

}
