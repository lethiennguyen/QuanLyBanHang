using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Quan_LyBan_Quan_Ao.Froms_SanPham
{
    public partial class ThemSanPhamQuanAo : Form
    {
        public ThemSanPhamQuanAo()
        {
            InitializeComponent();
        }
        public ThemSanPhamQuanAo(string maSanPham,string tenSanPham, string loaiSanPham,string size,string soLuong , string mauSac,int gia, byte[] imageSanPham)
        {
            InitializeComponent();
            MaSanPham.Text = maSanPham;
            TenSanPham.Text = tenSanPham;
            LoaiSanPham.Text = loaiSanPham;
            SizeSanPham.Text = size;
            SoLuong.Text = soLuong;
            MauSac.Text = mauSac;
            GiaSanPham.Text = gia.ToString();
            AnhSanPham.Image = ByteToImage(imageSanPham);
        }
        private Image ByteToImage(byte[] imageBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(memoryStream);
                return image;
            }
        }

        QuanLy.SanPhamClass sanPham;
        private void SanPham_Load(object sender, EventArgs e)
        {
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                BangSanPham.DataSource = modify.getSanPham();
            }
            catch
            {
                MessageBox.Show("error", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // lấy anh chuyển sang byte lưu vào sql
        private byte[] ImgaeToByte(PictureBox pictureBox)
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);

                return memoryStream.ToArray();
            }
        }
        private void ThemSanPham_Click(object sender, EventArgs e)
        {
            string maSanPham = this.MaSanPham.Text;
            string tenSanPham = this.TenSanPham.Text;
            string loaiSanPham = this.LoaiSanPham.Text;
            string size =this.SizeSanPham.Text;
            string soLuong =this.SoLuong.Text;
            string mauSac = this.MauSac.Text;
            int gia = int.Parse(this.GiaSanPham.Text);
            byte[] imageSanPham = ImgaeToByte(AnhSanPham);
            // Khởi tạo đối tượng SanPham với các thông tin đã lấy được
            sanPham = new QuanLy.SanPhamClass(maSanPham, tenSanPham, loaiSanPham, size, soLuong, mauSac, gia, imageSanPham);

            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.InsertSanPham(sanPham))
                {
                    BangSanPham.DataSource = modify.getSanPham();
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

        private void AnhSanPham_Click(object sender, EventArgs e)
        {

        }

        private void ThemAnhSanPham_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif,*.jfif)|*.jpg; *.jpeg; *.png; *.gif;*.jfif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AnhSanPham.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            string MaSP = MaSanPham.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.Delete_SP(MaSP))
                {
                    BangSanPham.DataSource = modify.getSanPham();
                    MessageBox.Show("Xóa khách hàng", "xóa thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng", "xóa không thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                BangSanPham.DataSource = modify.getSanPham();

            }
            catch
            {
                MessageBox.Show("erro", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BangSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BangSanPham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = BangSanPham.SelectedRows[0];

                MaSanPham.Text = selectedRow.Cells[0].Value.ToString();
                TenSanPham.Text = selectedRow.Cells[1].Value.ToString();
                LoaiSanPham.Text = selectedRow.Cells[2].Value.ToString();
                SizeSanPham.Text = selectedRow.Cells[3].Value.ToString();
                SoLuong.Text = selectedRow.Cells[4].Value.ToString();
                MauSac.Text = selectedRow.Cells[5].Value.ToString();
                GiaSanPham.Text = selectedRow.Cells[6].Value.ToString();

                byte[] imageBytes = (byte[])selectedRow.Cells[7].Value;
                AnhSanPham.Image = ByteToImage(imageBytes);
            }
        }

        private void SuaSanPham_Click(object sender, EventArgs e)
        {
            string maSanPham = this.MaSanPham.Text;
            string tenSanPham = this.TenSanPham.Text;
            string loaiSanPham = this.LoaiSanPham.Text;
            string size = this.SizeSanPham.Text;
            string soLuong = this.SoLuong.Text;
            string mauSac = this.MauSac.Text;
            int gia = int.Parse(this.GiaSanPham.Text);
            byte[] imageSanPham = ImgaeToByte(AnhSanPham);
            // Khởi tạo đối tượng SanPham với các thông tin đã lấy được
            sanPham = new QuanLy.SanPhamClass(maSanPham, tenSanPham, loaiSanPham, size, soLuong, mauSac, gia, imageSanPham);

            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.UpDate_SP(sanPham))
                {
                    BangSanPham.DataSource = modify.getSanPham();
                    MessageBox.Show("Sửa sản phẩm", "sửa thành công ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
