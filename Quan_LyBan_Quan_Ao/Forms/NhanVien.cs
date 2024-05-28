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


namespace Quan_LyBan_Quan_Ao.Forms
{
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }
        QuanLy.NhanVienClass nhanVien;
        private void NhanVien_Load(object sender, EventArgs e)
        {
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                guna2DataGridView1.DataSource = modify.getNhanVien();
            }
            catch
            {
                MessageBox.Show("error", "loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Them
        private void AddStaff_Click(object sender, EventArgs e)
        {
            string id_name = this.EmployeeCode.Text;
            string Name = this.StaffName.Text;
            string PhoneNumber = this.PhoneName.Text;
            string Address = this.Address.Text; 
            string CCCd = this.CCCDStaff.Text;
            DateTime dateTime = this.DateTimeStaff.Value;
            string Sex = (RadioButtonMen.Checked ? RadioButtonMen.Text : RadioButtonGirl.Text);
            nhanVien = new QuanLy.NhanVienClass(id_name, Name, PhoneNumber, Address, CCCd, dateTime, Sex);
            try
            {
                
                QuanLy.Modify modify = new QuanLy.Modify(); 
                if (modify.Insert(nhanVien))
                {
                    guna2DataGridView1.DataSource = modify.getNhanVien();
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

        private void UpDateStaff_Click(object sender, EventArgs e)
        {
            string id_name = this.EmployeeCode.Text;
            string Name = this.StaffName.Text;
            string PhoneNumber = this.PhoneName.Text;
            string Address = this.Address.Text;
            string CCCd = this.CCCDStaff.Text;
            DateTime dateTime = this.DateTimeStaff.Value;
            string Sex = (RadioButtonMen.Checked ? RadioButtonMen.Text : RadioButtonGirl.Text);
            nhanVien = new QuanLy.NhanVienClass(id_name, Name, PhoneNumber, Address, CCCd, dateTime, Sex);
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                if (modify.UpDate(nhanVien))
                {
                    guna2DataGridView1.DataSource = modify.getNhanVien();
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

        private void DeleteStaff_Click(object sender, EventArgs e)
        {
           
             
            try {
                if(guna2DataGridView1.SelectedRows.Count > 0)
                 {
                    string id_name = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    QuanLy.Modify modify = new QuanLy.Modify();
                    if (modify.Delete(id_name))
                    {
                        guna2DataGridView1.DataSource = modify.getNhanVien();
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

        private void txt_Search_NhanVien_Click(object sender, EventArgs e)
        {
            string Name = this.textboxSearchNv.Text;
            try
            {
                QuanLy.Modify modify = new QuanLy.Modify();
                DataTable dt = modify.Search_NV(Name);
                if (dt.Rows.Count > 0)
                {
                    guna2DataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // them xoa sua 

    }
}
