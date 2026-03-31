using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DOAN_WF.DAL
{
    internal class LoaiXeDAL
    {
        public DataTable Laydanhsachloaixe()
        {
            DataTable dt = new DataTable();
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string strQuery = "SELECT MaLoaiXe, TenLoaiXe FROM LoaiXe";
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
