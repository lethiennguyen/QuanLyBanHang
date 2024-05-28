using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class ModifiBill
    {
        SqlDataAdapter dataAdapter;
        SqlCommand Command;
        public ModifiBill(){
            
        }
       
        public DataTable getBill()
        {
            DataTable dataTable = new DataTable();
            string Sql = "SELECT MaBill, MaKH, MaNV, MaSP, NgayMua, TrangThaiThanhToan FROM dbo.Bill";
            try
            {
                using (SqlConnection sqlConnection = DataLinkSQl.getConnection())
                {
                    sqlConnection.Open();
                    dataAdapter = new SqlDataAdapter(Sql, sqlConnection);
                    dataAdapter.Fill(dataTable);
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }
        public DataTable SanPhamBanChay()
        {
            
            DataTable dataTable = new DataTable();
            string query = @"
            SELECT 
            MaSP, 
            TenSP, 
            SUM(TongTien) AS SumTongTien,
            SUM(SLMuaMotSanPham) AS TotalQuantitySold
            FROM dbo.Bill
            GROUP BY MaSP, TenSP
            ORDER BY SumTongTien DESC, TotalQuantitySold DESC";
            try
            {
                using (SqlConnection sqlConnection = DataLinkSQl.getConnection())
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTable;
        }
        public bool Insert_Bill(BillClass bill)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "INSERT INTO dbo.Bill VALUES (@MaBill, @MaNV, @MaKH, @MaSP, @TenSP, @MauSac, @Size, @SLMuaMotSanPham, @Gia, @NgayMua, @TongTien, @TrangThaiThanhToan)";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaBill", SqlDbType.NVarChar).Value = bill.MaBill1;
                Command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = bill.MaNV1;
                Command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = bill.MaKH1;
                Command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = bill.MaSanPham;
                Command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = bill.TenSanPham;
                Command.Parameters.Add("@MauSac", SqlDbType.NVarChar).Value = bill.MauSac;
                Command.Parameters.Add("@Size", SqlDbType.NVarChar).Value = bill.Size;
                Command.Parameters.Add("@SLMuaMotSanPham", SqlDbType.Int).Value = bill.SoLuongMua;
                Command.Parameters.Add("@Gia", SqlDbType.Int).Value = bill.Gia;
                Command.Parameters.Add("@NgayMua", SqlDbType.DateTime).Value = bill.NgayMua;
                Command.Parameters.Add("@TongTien", SqlDbType.Decimal).Value = bill.TongTien1;
                Command.Parameters.Add("@TrangThaiThanhToan", SqlDbType.NVarChar).Value = bill.TrangThaiThanhToan;
                Command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public DataTable Search_Bill(string MaKH)
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "SELECT  MaBill, MaKH, MaNV, TenSP, NgayMua, TrangThaiThanhToan FROM dbo.Bill WHERE MaKH = @MaKH";

            try
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = MaKH;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
        }
        public bool Delete_Bill(string MaBill)
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "DELETE FROM dbo.Bill WHERE MaBill = @MaBill";

            try
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.Add("@MaBill", SqlDbType.NVarChar).Value = MaBill;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataTable);
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
        public DataTable XapXep_NgayMuabill()
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "SELECT MaBill, MaKH, MaNV, TenSP, NgayMua, TrangThaiThanhToan FROM dbo.Bill ORDER BY NgayMua DESC";

            try
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return dataTable;
        }
    }
}
