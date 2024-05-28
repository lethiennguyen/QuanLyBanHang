using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_LyBan_Quan_Ao.Forms
{
    public partial class ThongKeDoanhSo : Form
    {
        public ThongKeDoanhSo()
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

        private void ThongKeTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ThongKeTheo.Text == "Theo ngày chỉ định")
            {
                OpenChilForm(new ThongKe.ThongKeTheoNgay());

            }
        }

        private void BanChay_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLy.ModifiBill ketNoi = new QuanLy.ModifiBill();
                DataTable dataTable = ketNoi.SanPhamBanChay();

                if (dataTable.Rows.Count > 0)
                {
                    BangBanChay.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No best-selling products found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TongSoLuong_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
