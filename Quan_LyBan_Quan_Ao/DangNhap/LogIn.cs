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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void TxtLognIn_Click(object sender, EventArgs e)
        {
            //lay sql
            SqlConnection SQL = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=ClothingSalesManager;Integrated Security=True");
            try
            {
                SQL.Open();
                string Name = txtName.Text;
                string Password = txtPass.Text;
                string Select = "SELECT * FROM dbo.AccountAdmin WHERE IdName = @Name AND IdPassWord = @Password";
                SqlCommand Command = new SqlCommand(Select, SQL);
                Command.Parameters.AddWithValue("@Name", Name);
                Command.Parameters.AddWithValue("@Password", Password);
                SqlDataReader adapter = Command.ExecuteReader();

                if (adapter.Read() == true)
                {
                    ManagementPage Man = new ManagementPage();
                    this.Hide();
                    Man.Show();
                }
                else
                {
                    MessageBox.Show("Sai Tài Khoản Mật Khẩu");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("ko kết nối");

            }
            finally
            {
                // Đảm bảo rằng kết nối được đóng sau khi sử dụng
                SQL.Close();
            }
        }

        private void checkPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkPass.Checked == false)
            {
                txtPass.UseSystemPasswordChar = true;
            }
            else
            {
                txtPass.UseSystemPasswordChar = false;
            }
           
        }

        private void txtSignIn_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
