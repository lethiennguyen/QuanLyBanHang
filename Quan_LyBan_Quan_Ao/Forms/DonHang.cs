using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_LyBan_Quan_Ao.Forms;
namespace Quan_LyBan_Quan_Ao.Forms
{
    public partial class DonHang : Form
    {
        public DonHang()
        {
            InitializeComponent();

        }
        public DonHang(string maSanPham, string tenSanPham, string loaiSanPham, string size, string soLuong, string mauSac, int gia, byte[] imageSanPham)
        {
            InitializeComponent();
            MaSanPham.Text = maSanPham;
            TenSanPham.Text = tenSanPham;
           // LoaiSanPham.Text = loaiSanPham;
            SizeSanPham.Text = size;
            SoLuong.Text = soLuong;
            MauSac.Text = mauSac;
            GiaSanPham.Text = gia.ToString();
            AnhSanPham.Image = ByteToImage(imageSanPham);
        }
        private byte[] ImgaeToByte(PictureBox pictureBox)
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);

                return memoryStream.ToArray();
            }
        }
        private Image ByteToImage(byte[] imageBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(memoryStream);
                return image;
            }
        }
        private void Button_Search_hh_Click(object sender, EventArgs e)
        {
            string tenSanPham = this.txtSanPham.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                DataTable dt = modify.SearchSanPham(tenSanPham);
                if (dt.Rows.Count >= 0)
                {
                    BangSanPham.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy san phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BangSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BangSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BangSanPham.SelectedRows[0];

                MaSanPham.Text = selectedRow.Cells[0].Value.ToString();
                TenSanPham.Text = selectedRow.Cells[1].Value.ToString();
                //LoaiSanPham.Text = selectedRow.Cells[2].Value.ToString();
                SizeSanPham.Text = selectedRow.Cells[3].Value.ToString();
                SoLuong.Text = selectedRow.Cells[4].Value.ToString();
                MauSac.Text = selectedRow.Cells[5].Value.ToString();
                GiaSanPham.Text = selectedRow.Cells[6].Value.ToString();
                byte[] imageBytes = (byte[])selectedRow.Cells[7].Value;
                AnhSanPham.Image = ByteToImage(imageBytes);
            }
        }

        private void Button_Search_kh_Click(object sender, EventArgs e)
        {
            string sdt = TextBox_Search_KH.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                DataTable dt = modify.Search_KH(sdt);

                // Kiểm tra xem có dữ liệu trả về không
                if (dt != null && dt.Rows.Count >= 0)
                {
                    // Lấy tên khách hàng từ dòng đầu tiên của bảng kết quả
                    string tenKH = dt.Rows[0]["TenKH"].ToString();
                    string maKH = dt.Rows[0]["MaKH"].ToString();
                    // Hiển thị tên khách hàng lên giao diện người dùng
                    txt_TenKH.Text = tenKH;
                    txt_MaKH.Text = maKH;
                }
                else
                {
                    // Nếu không có dữ liệu trả về, bạn có thể thông báo cho người dùng
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_TenKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_thanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                string maBill = this.txt_MaBill.Text;
                string maNV = this.MaNV.Text;
                string maKH = this.txt_MaKH.Text;
                string maSanPham = this.MaSanPham.Text;
                string tenSanPham = this.TenSanPham.Text;
                //string loaiSanPham = this.LoaiSanPham.Text;
                string size = this.SizeSanPham.Text;
                string mauSac = this.MauSac.Text;
                int gia = int.Parse(this.GiaSanPham.Text);
                int soLuongMua = int.Parse(this.SoLuongMua.Text);
                DateTime ngayMua = Convert.ToDateTime(this.timeNgayBan.Text);
                string trangThaiThanhToan = this.TrangThaiThanhToan.Text;

                // Tạo đối tượng BillClass
                QuanLy.BillClass bill = new QuanLy.BillClass(maBill, maNV, maKH, maSanPham, tenSanPham, mauSac, size, gia, soLuongMua, ngayMua, 0, trangThaiThanhToan);


                // Tính tổng tiền
                bill.TinhTongTien_VAT();

                // Cập nhật giá trị tổng tiền trên giao diện
                this.TongTienTT.Text = bill.TongTien1.ToString("N2");
                bill.TinhTongTien();
                // Cập nhật giá trị tổng tiền trên giao diện
                this.TongTien.Text = bill.TongTien1.ToString("N2");

                // Thêm hóa đơn vào cơ sở dữ liệu
                QuanLy.ModifiBill modifyBill = new QuanLy.ModifiBill();
                bool result = modifyBill.Insert_Bill(bill);
                if (result)
                {
                    MessageBox.Show("Hóa đơn đã được thanh toán và lưu vào cơ sở dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi lưu hóa đơn vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TrangThaiThanhToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(TrangThaiThanhToan.Text == "Chuyển Khoản")
            {
                Forms.AnhQR anhGiaoDien = new AnhQR();
                anhGiaoDien.Show();
            }
         
        }

        private void btn_Seach_NV_Click(object sender, EventArgs e)
        {
            string maNV = NhanVien.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                DataTable dataTable = modify.Search_MaNV(maNV);
                // Kiểm tra xem có dữ liệu trả về không
                if (dataTable != null && dataTable.Rows.Count >= 0)
                {
                    // Lấy tên khách hàng từ dòng đầu tiên của bảng kết quả
                    string tenNV = dataTable.Rows[0]["MaNV"].ToString();

                    // Hiển thị tên khách hàng lên giao diện người dùng
                    MaNV.Text = tenNV;
                }
                else
                {
                    // Nếu không có dữ liệu trả về, bạn có thể thông báo cho người dùng
                    MessageBox.Show("Không tìm thấy khách hàng với số điện thoại này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TongTienTT_TextChanged(object sender, EventArgs e)
        {

        }

        private void TongTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void SoLuongMua_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThemSP_Click(object sender, EventArgs e)
        {
            int soLuongMua = int.Parse(this.SoLuongMua.Text);
            // Increment the value
            soLuongMua++;

            // Convert the incremented value back to a string and update the TextBox
            this.SoLuongMua.Text = soLuongMua.ToString();
        }

        private void TruSP_Click(object sender, EventArgs e)
        {
            int soLuongMua = int.Parse(this.SoLuongMua.Text);
            if (soLuongMua > 0)
            {
                soLuongMua++;
            }

            // Convert the decremented value back to a string and update the TextBox
            this.SoLuongMua.Text = soLuongMua.ToString();
        }
    }
}
