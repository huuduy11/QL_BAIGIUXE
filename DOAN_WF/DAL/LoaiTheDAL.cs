using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOAN_WF.DTO;
using System.Data;

namespace DOAN_WF.DAL
{
    internal class LoaiTheDAL
    {
        public DataTable Laydanhsachloaithe()
        {
            DataTable dt = new DataTable();
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string strQuery = "SELECT MaLoaiThe, TenLoaiThe FROM LoaiThe";
                using (var com = new SqlCommand(strQuery, conn))
                using (var da = new SqlDataAdapter(com))
                {
                    da.Fill(dt);
                }
            }
            return dt;
            }
    }
}
