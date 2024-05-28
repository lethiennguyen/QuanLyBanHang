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
    public partial class ChucNang : Form
    {
      
        public ChucNang()
        {
            InitializeComponent();
            LoadSanPhamData();
        }
        
        private void ThemSanPham_Click(object sender, EventArgs e)
        {
            ThemSanPhamQuanAo sanpham = new ThemSanPhamQuanAo();
            sanpham.Show();
        }
        private void LoadSanPhamData()
        {
            QuanLy.KetNoiUserControlSanPham ketNoi = new QuanLy.KetNoiUserControlSanPham();
            DataTable sanPhamTable = ketNoi.LayDuLieu();

            foreach (DataRow row in sanPhamTable.Rows)
            {
                var userControl = new SanPhamUserControl();
                userControl.SetData(
                    row["TenSP"].ToString(),
                    row["Gia"].ToString(),
                   (byte[])row["AnhSanPham"]
                );

                flowLayoutPanel1.Controls.Add(userControl);
            }
        }

        private void txt_Search_SanPham_Click(object sender, EventArgs e)
        {
            string searchText = this.txt_SanPham.Text;
            QuanLy.KetNoiUserControlSanPham ketNoi = new QuanLy.KetNoiUserControlSanPham();
            QuanLy.ModifiBill modifi = new QuanLy.ModifiBill();
            DataTable sanPhamTable = ketNoi.SearchSanPham_ChucNang(searchText);

            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in sanPhamTable.Rows)
            {
                var userControl = new SanPhamUserControl();
                userControl.SetData(
                    row["TenSP"].ToString(),
                    row["Gia"].ToString(),
                    (byte[])row["AnhSanPham"]
                );

                flowLayoutPanel1.Controls.Add(userControl);
            }

        }

        private void txt_SanPham_TextChanged(object sender, EventArgs e)
        {
            string searchText = this.txt_SanPham.Text;
            QuanLy.KetNoiUserControlSanPham ketNoi = new QuanLy.KetNoiUserControlSanPham();
            QuanLy.ModifiBill modifi = new QuanLy.ModifiBill();
            DataTable sanPhamTable = ketNoi.SearchSanPham_ChucNang(searchText);

            flowLayoutPanel1.Controls.Clear();

            foreach (DataRow row in sanPhamTable.Rows)
            {
                var userControl = new SanPhamUserControl();
                userControl.SetData(
                    row["TenSP"].ToString(),
                    row["Gia"].ToString(),
                    (byte[])row["AnhSanPham"]
                );

                flowLayoutPanel1.Controls.Add(userControl);
            }
        }

        private void btn_XoaSP_Click(object sender, EventArgs e)
        {
            // Check if any product is selected
            if (flowLayoutPanel1.Controls.Count > 0)
            {
                // Get the first control in the flowLayoutPanel
                SanPhamUserControl selectedControl = (SanPhamUserControl)flowLayoutPanel1.Controls[0];

                // Get the name of the product from the selected control
                string tenSanPham = selectedControl.TenSanPhamValue;

                // Delete the product from the database
                QuanLy.KetNoiUserControlSanPham ketNoi = new QuanLy.KetNoiUserControlSanPham();
                ketNoi.DeleteProduct(tenSanPham);

                // Remove the selected control from the flowLayoutPanel
                flowLayoutPanel1.Controls.Remove(selectedControl);
            }
            else
            {
                MessageBox.Show("There are no products to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
