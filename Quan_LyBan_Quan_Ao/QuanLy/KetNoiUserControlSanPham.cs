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
    class KetNoiUserControlSanPham
    {

        public DataTable LayDuLieu()
        {
            DataTable dataTable = new DataTable();
            string Sql = "SELECT AnhSanPham,TenSP,Gia FROM dbo.SanPham";
            try
            {
                using (SqlConnection sqlConnection = DataLinkSQl.getConnection())
                {
                    sqlConnection.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(Sql, sqlConnection))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTable;
        }
        public DataTable SearchSanPham_ChucNang(string searchText)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM dbo.SanPham WHERE TenSP LIKE '%' + @TenSP + '%'";
            using (SqlConnection connection = DataLinkSQl.getConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = "%" + searchText + "%";
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public void DeleteProduct(string tenSanPham)
        {
            string query = "DELETE FROM dbo.SanPham WHERE TenSP = @TenSP";
            using (SqlConnection connection = DataLinkSQl.getConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = tenSanPham;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
