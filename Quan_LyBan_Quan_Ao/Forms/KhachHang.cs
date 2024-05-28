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
using Quan_LyBan_Quan_Ao.Froms_KhachHang;

namespace Quan_LyBan_Quan_Ao.Forms
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        private Form currentChilFoms;
        private void OpenChilForm(Form ChilFoms)
        {
            if (currentChilFoms != null)//kiểm tra khơi tạo rồi đóng
            {
                currentChilFoms.Close();
            }
            currentChilFoms = ChilFoms;
            ChilFoms.TopLevel = false;
            ChilFoms.FormBorderStyle = FormBorderStyle.None;
            ChilFoms.Dock = DockStyle.Fill;
            ShowForm.Controls.Add(ChilFoms);
            ShowForm.Tag = ChilFoms;
            ChilFoms.BringToFront();
            ChilFoms.Show();

        }
        private void KhachHang_load(object sender, EventArgs e)
        {
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                BangKhachHang.DataSource = modify.getKhachHang();

            }
            catch
            {
                MessageBox.Show("erro", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ThemKhachHang_Click(object sender, EventArgs e)
        {
            ThemKH kH = new ThemKH();
            kH.Show();
        }

       

        private void HienThiKH_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                BangKhachHang.DataSource = modify.getKhachHang();

            }
            catch
            {
                MessageBox.Show("erro", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_SuaTTKhachHang_Click(object sender, EventArgs e)
        {
            if (BangKhachHang.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BangKhachHang.SelectedRows[0];
                string maKh = selectedRow.Cells[0].Value.ToString();
                string tenKh = selectedRow.Cells[1].Value.ToString();
                string sdt = selectedRow.Cells[2].Value.ToString();
                string diaChiKh = selectedRow.Cells[3].Value.ToString();
                DateTime ngaysinhKH = DateTime.MinValue; // Khởi tạo một giá trị mặc định cho ngaysinhKH
                if (selectedRow.Cells[5].Value != null && selectedRow.Cells[4].Value is DateTime)
                {
                    ngaysinhKH = (DateTime)selectedRow.Cells[4].Value;
                    // Tiếp tục xử lý
                }
                int soluongmua = int.Parse(selectedRow.Cells[5].Value.ToString());
                int tongTienMua = int.Parse(selectedRow.Cells[6].Value.ToString());
                XemThongTinKhachHang kh = new Froms_KhachHang.XemThongTinKhachHang(maKh, tenKh, sdt, diaChiKh, ngaysinhKH, soluongmua, tongTienMua);
                kh.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng trước khi sửa thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_Search_KhachHang_Click(object sender, EventArgs e)
        {
            string sdt = TextBox_Search_KH.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                DataTable dt = modify.Search_KH_1(sdt);
                if (dt.Rows.Count > 0)
                    {
                        BangKhachHang.DataSource = dt;
                    }
                
                else
                { 
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_Search_KH_TextChanged(object sender, EventArgs e)
        {
            string sdt = TextBox_Search_KH.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                DataTable dt = modify.Search_KH_1(sdt);
                if (dt.Rows.Count > 0)
                {
                    BangKhachHang.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
