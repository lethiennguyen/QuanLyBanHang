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

namespace Quan_LyBan_Quan_Ao.DangNhap
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }
        private void txtSignIn_Click(object sender, EventArgs e)
        {
            string tenTaiKhoan = txtName.Text;
            string matKhau = txtPass.Text;
            string matKhauLap = txtPassLap.Text;

            // Create an instance of AccClass with the entered credentials
            QuanLy.AccClass accClass = new QuanLy.AccClass(tenTaiKhoan, matKhau);

            try
            {
                if (matKhau == matKhauLap)
                {
                    QuanLy.Modify modify = new QuanLy.Modify();
                    if (modify.Account(accClass))
                    {
                        MessageBox.Show("Đăng kí Tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Đăng kí Tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
