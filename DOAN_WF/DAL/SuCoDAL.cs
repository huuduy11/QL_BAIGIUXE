using System.Data;
using System;
using System.Data.SqlClient;

namespace DOAN_WF.DAL
{
    internal class SucoDAL
    {
        string strConn = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
        public DataTable TrangThaiXuLy()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"SELECT DISTINCT TrangThaiXuLy
                                FROM SuCo
                                ";
                
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable FullttsuCo()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"select MaSuCo,MaLS,LoaiSuco,MoTa,ThoiGian,MaNV,TrangThaiXuLy from SuCo";
                SqlDataAdapter da = new SqlDataAdapter( sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            } 
        }
        public DataTable TraCuu(DateTime tuNgay, DateTime denNgay, string trangThai)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"SELECT *
               FROM SuCo
               WHERE ThoiGian >= @TuNgay AND ThoiGian <= @DenNgay";

                if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả")
                {
                    sql += " AND TrangThaiXuLy = @TrangThai";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                if (!string.IsNullOrEmpty(trangThai) && trangThai != "Tất cả") //trang thai khong duoc rong && neu user chon tat ca thi khong loc theo trang thai
                {
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
