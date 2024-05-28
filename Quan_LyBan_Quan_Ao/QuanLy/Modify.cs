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
    class Modify
    {
        
        SqlDataAdapter dataAdapter;
        SqlCommand Command;
        public Modify()
        {
        }
        public bool Account(AccClass accClass)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "INSERT INTO dbo.AccountAdmin VALUES (@IdName, @IdPassWord)";

            try
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@IdName", SqlDbType.NVarChar).Value = accClass.TenTaiKhoan1;
                command.Parameters.AddWithValue("@IdPassWord", SqlDbType.NVarChar).Value = accClass.MatKhau1;
                command.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
            finally
            {
                if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
        public DataTable getNhanVien()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select * from dbo.NhanVien";
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
        public bool Insert(NhanVienClass nhanVien)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "INSERT INTO dbo.NhanVien VALUES (@MaNV, @TenNV,@SDT,@DiaChi,@CCCD,@DateTime,@sex)";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.Id_name;
                Command.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.Name;
                Command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhanVien.Phone;
                Command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.Address;
                Command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = nhanVien.Cccd;
                Command.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = nhanVien.DateTime1.ToShortDateString();
                Command.Parameters.Add("@sex", SqlDbType.NVarChar).Value = nhanVien.Sex;
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
        public bool UpDate(NhanVienClass nhanVien)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "UPDATE dbo.NhanVien SET TenNV = @TenNV, SDT = @SDT, DiaChi = @DiaChi, CCCD = @CCCD, DateTime = @DateTime, sex = @sex WHERE MaNV = @MaNV";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = nhanVien.Id_name;
                Command.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = nhanVien.Name;
                Command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = nhanVien.Phone;
                Command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = nhanVien.Address;
                Command.Parameters.Add("@CCCD", SqlDbType.NVarChar).Value = nhanVien.Cccd;
                Command.Parameters.Add("@DateTime", SqlDbType.DateTime).Value = nhanVien.DateTime1.ToShortDateString();
                Command.Parameters.Add("@sex", SqlDbType.NVarChar).Value = nhanVien.Sex;
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
        public bool Delete( string id_name)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "DELETE FROM dbo.NhanVien WHERE MaNV = @MaNV";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = id_name;

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
        public DataTable Search_NV(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "SELECT *FROM dbo.NhanVien WHERE TenNV  LIKE '%' + @TenNV + '%'";
            try
            {
                sqlConnection.Open();
                SqlCommand Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@TenNV", SqlDbType.NVarChar).Value = Name;
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(dt);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
        public DataTable Search_MaNV(string maNV)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "SELECT *FROM dbo.NhanVien WHERE MaNV  LIKE '%' + @MaNV + '%'";
            try
            {
                sqlConnection.Open();
                SqlCommand Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = maNV;
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
        // Quan ly Khách Hàng 
        public DataTable getKhachHang()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select * from dbo.KhachHang";
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
        public bool InsertKH(KhacHangClass khachHang)
        {

            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "INSERT INTO dbo.KhachHang VALUES (@MaKH, @TenKH, @SDT, @DiaChi, @NgaySinh, @SoLuongMua, @TongTienMua)";
          
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = khachHang.MaKh;
                Command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = khachHang.TenKh;
                Command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = khachHang.Sdt;
                Command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = khachHang.DiaChiKh;
                Command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = khachHang.NgaysinhKH.ToShortDateString();
                Command.Parameters.Add("@SoLuongMua", SqlDbType.Int).Value = khachHang.Soluongmua;
                Command.Parameters.Add("@TongTienMua", SqlDbType.Int).Value = khachHang.TongTienMua;
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
        public bool Delete_KH(string MaKh)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "DELETE FROM dbo.KhachHang WHERE MaKH = @MaKH";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = MaKh;

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
        public bool UpDate_KH(KhacHangClass khacHang)
        {
            // Sử dụng @MaKH, @TenKH, @SDT, @DiaChi, @NgaySinh, @SoLuongMua, @TongTienMua
            string query = "UPDATE dbo.KhachHang SET TenKH = @TenKH, SDT = @SDT, DiaChi = @DiaChi, NgaySinh = @NgaySinh, SoLuongMua = @SoLuongMua, TongTienMua = @TongTienMua WHERE MaKH = @MaKH";

            try
            {
                using (SqlConnection sqlConnection = DataLinkSQl.getConnection())
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.Add("@MaKH", SqlDbType.NVarChar).Value = khacHang.MaKh;
                        command.Parameters.Add("@TenKH", SqlDbType.NVarChar).Value = khacHang.TenKh;
                        command.Parameters.Add("@SDT", SqlDbType.NVarChar).Value = khacHang.Sdt;
                        command.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = khacHang.DiaChiKh;
                        command.Parameters.Add("@NgaySinh", SqlDbType.DateTime).Value = khacHang.NgaysinhKH;
                        command.Parameters.Add("@SoLuongMua", SqlDbType.Int).Value = khacHang.Soluongmua;
                        command.Parameters.Add("@TongTienMua", SqlDbType.Int).Value = khacHang.TongTienMua;

                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }
        public DataTable Search_KH(string sdt)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "SELECT TenKH,MaKH FROM dbo.KhachHang WHERE SDT = @SDT    ";
            try
            {
                sqlConnection.Open();
                SqlCommand Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("SDT", SqlDbType.NVarChar).Value = sdt;
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
        public DataTable Search_KH_1(string sdt)
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "SELECT TenKH,MaKH, SDT, DiaChi, NgaySinh, SoLuongMua, TongTienMua FROM dbo.KhachHang WHERE SDT LIKE '%' + @SDT + '%'   ";
            try
            {
                sqlConnection.Open();
                SqlCommand Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("SDT", SqlDbType.NVarChar).Value = sdt;
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return dt;
        }
        //San Pham
        public DataTable getSanPham()
        {
            DataTable dataTable = new DataTable();
            string Sql = "select * from dbo.SanPham";
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
        public bool InsertSanPham(SanPhamClass sanPham)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "INSERT INTO dbo.SanPham VALUES (@MaSP, @TenSP,@LoaiSP,@Size,@SoLuong,@MauSac,@Gia,@AnhSanPham)";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = sanPham.MaSanPham;
                Command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = sanPham.TenSanPham;
                Command.Parameters.Add("@LoaiSP", SqlDbType.NVarChar).Value = sanPham.LoaiSanPham;
                Command.Parameters.Add("@Size", SqlDbType.NVarChar).Value = sanPham.Size;
                Command.Parameters.Add("@SoLuong", SqlDbType.NVarChar).Value = sanPham.SoLuong;
                Command.Parameters.Add("@MauSac", SqlDbType.NVarChar).Value = sanPham.MauSac;
                Command.Parameters.Add("@Gia", SqlDbType.Int).Value = sanPham.Gia;
                Command.Parameters.Add("@AnhSanPham", SqlDbType.Image).Value = sanPham.ImageSanPham;
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
        public DataTable SearchSanPham(string tenSanPham)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM dbo.SanPham WHERE TenSP LIKE '%' + @TenSP + '%'";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = tenSanPham;
                SqlDataAdapter adapter = new SqlDataAdapter(Command);
                adapter.Fill(dataTable);
            }
            catch
            {
                // Xử lý lỗi nếu cần thiết
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataTable;
        }
       
        public bool UpDate_SP(SanPhamClass sanPham)
        {
            // Sử dụng @MaKH, @TenKH, @SDT, @DiaChi, @NgaySinh, @SoLuongMua, @TongTienMua
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "UPDATE dbo.SanPham SET TenSP= @TenSP,LoaiSP = @LoaiSP,Size = @Size,SoLuong = @SoLuong,MauSac = @MauSac,Gia = @Gia,AnhSanPham = @AnhSanPham WHERE MaSP = @MaSP";

            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = sanPham.MaSanPham;
                Command.Parameters.Add("@TenSP", SqlDbType.NVarChar).Value = sanPham.TenSanPham;
                Command.Parameters.Add("@LoaiSP", SqlDbType.NVarChar).Value = sanPham.LoaiSanPham;
                Command.Parameters.Add("@Size", SqlDbType.NVarChar).Value = sanPham.Size;
                Command.Parameters.Add("@SoLuong", SqlDbType.NVarChar).Value = sanPham.SoLuong;
                Command.Parameters.Add("@MauSac", SqlDbType.NVarChar).Value = sanPham.MauSac;
                Command.Parameters.Add("@Gia", SqlDbType.Int).Value = sanPham.Gia;
                Command.Parameters.Add("@AnhSanPham", SqlDbType.Image).Value = sanPham.ImageSanPham;
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
        public bool Delete_SP(String MaSP)
        {
            SqlConnection sqlConnection = DataLinkSQl.getConnection();
            string query = "DELETE FROM dbo.SanPham WHERE MaSP = @MaSP";
            try
            {
                sqlConnection.Open();
                Command = new SqlCommand(query, sqlConnection);
                Command.Parameters.Add("@MaSP", SqlDbType.NVarChar).Value = MaSP;

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
    }
}
