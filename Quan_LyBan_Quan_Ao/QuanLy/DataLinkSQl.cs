using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Quan_LyBan_Quan_Ao.QuanLy
{
    class DataLinkSQl
    {
        private static string StringConnection = @"Data Source=.\sqlexpress;Initial Catalog=ClothingSalesManager;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(StringConnection);
        }
    }
}
