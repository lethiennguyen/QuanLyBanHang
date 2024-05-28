using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_LyBan_Quan_Ao.DangNhap;


namespace Quan_LyBan_Quan_Ao
{
    public partial class ManagementPage : Form
    {
        public ManagementPage()
        {
            InitializeComponent();
        }
        private Form currentChilFoms;
        private void OpenChilForm(Form ChilFoms)
        {
            if(currentChilFoms != null)//kiểm tra khơi tạo rồi đóng
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
        private void txtQuanao_Click(object sender, EventArgs e)
        {
            
            OpenChilForm(new Forms.ChucNang()); 
           
        }

        private void txtDonHang_Click(object sender, EventArgs e)
        {
            OpenChilForm(new Forms.DonHang());
        }

        private void txtNhanVien_Click(object sender, EventArgs e)
        {
            OpenChilForm(new Forms.NhanVien());
        }

        private void txtKhachHang_Click(object sender, EventArgs e)
        {
            OpenChilForm(new Forms.KhachHang());
        }

        private void txtCamera_Click(object sender, EventArgs e)
        {
            Camera Cam = new Camera();
            Cam.Show();
        }
        private void btn_Bill_Click(object sender, EventArgs e)
        {
            OpenChilForm(new Forms.LichSuGiaoDich());
        }
        private void ThongKe_Click(object sender, EventArgs e)
        {
            OpenChilForm(new Forms.ThongKeDoanhSo());
        }

        private void ShowForm_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void ManagementPage_Load(object sender, EventArgs e)
        {

        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            DangNhap.LogIn logIn = new DangNhap.LogIn();
            DialogResult result = MessageBox.Show("Bạn muống đăng xuất?", "Đăng Xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
                logIn.Show();
            }

        }
        bool expand = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (expand == false)
            {
                panelComboBox.Height += 50;
                if (panelComboBox.Height >= panelComboBox.MaximumSize.Height)
                {
                    timer1.Stop();
                    expand = true;
                }
            }
            else
            {
                panelComboBox.Height -= 50;
                if (panelComboBox.Height <= panelComboBox.MinimumSize.Height)
                {
                    timer1.Stop();
                    expand = false;
                }
            }
            
        }

        private void TrangChu_Click(object sender, EventArgs e)
        {
            timer1.Start();
            OpenChilForm(new Forms.AnhGiaoDien());
        }

      
    }
}
