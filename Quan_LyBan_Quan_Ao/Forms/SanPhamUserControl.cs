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
using Quan_LyBan_Quan_Ao.Froms_SanPham;
namespace Quan_LyBan_Quan_Ao.Forms
{
   
    public partial class SanPhamUserControl : UserControl
    {
        public string TenSanPhamValue
        {
            get { return TenSanPham.Text; }
        }

        QuanLy.UserControlSanPhamClass UserControlSanPhamClass;
        public SanPhamUserControl()
        {
            InitializeComponent();
           
        }
        private Image ByteToImage(byte[] imageBytes)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                Image image = Image.FromStream(memoryStream);
                return image;
            }
        }
        public void SetData(string tenSanPham, string giaSanPham, byte[] anhSanPham)
        {
            TenSanPham.Text = tenSanPham;
            GiaSanPham.Text = giaSanPham;
            pictureBoxSanPham.Image = ByteToImage( anhSanPham);
        }
        private byte[] ImgaeToByte(PictureBox pictureBox)
        {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
                return memoryStream.ToArray();
            }
        }
        private void btnXemSP_Click(object sender, EventArgs e)
        {
            string tenSP = TenSanPham.Text;
            string gia = GiaSanPham.Text;

            UserControlSanPhamClass = new QuanLy.UserControlSanPhamClass(
                ImgaeToByte(pictureBoxSanPham),
                tenSP,
                gia
            );

            // Hiển thị thông tin sản phẩm lên form ThemSanPhamQuanAo
            Froms_SanPham.ThemSanPhamQuanAo them = new ThemSanPhamQuanAo( );
            them.Show();
        }

        private void SanPhamUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
