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

namespace Quan_LyBan_Quan_Ao.Forms
{
    public partial class LichSuGiaoDich : Form
    {
        public LichSuGiaoDich()
        {
            InitializeComponent();
        }
        QuanLy.BillClass BillClass;
        private void LoadBillData()
        {
            try
            {
                QuanLy.ModifiBill modify = new QuanLy.ModifiBill();
                BangBill.DataSource = modify.getBill();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            LoadBillData();
        }

        private void Button_Search_hh_Click(object sender, EventArgs e)
        {
            string maKH = this.NgayMuaDonHang.Text;

            try
            {
                QuanLy.ModifiBill modify = new QuanLy.ModifiBill();
                DataTable dataTable = modify.Search_Bill(maKH);
                if (dataTable.Rows.Count > 0)
                {
                    BangBill.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bill của khách hàng " + maKH, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_MaBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (BangBill.SelectedRows.Count > 0)
                {
                    string maBill = BangBill.SelectedRows[0].Cells[0].Value.ToString();
                    QuanLy.ModifiBill modify = new QuanLy.ModifiBill();
                    if (modify.Delete_Bill(maBill))
                    {
                        BangBill.DataSource = modify.getBill();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Không xóa được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XapXep_Click(object sender, EventArgs e)
        {
            try
            {
                QuanLy.ModifiBill modifi = new QuanLy.ModifiBill();
                DataTable sortedBillsTable = modifi.XapXep_NgayMuabill();

                if (sortedBillsTable.Rows.Count > 0)
                {
                    
                    BangBill.DataSource = sortedBillsTable;
                }
                else
                {
                    MessageBox.Show("không bill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
