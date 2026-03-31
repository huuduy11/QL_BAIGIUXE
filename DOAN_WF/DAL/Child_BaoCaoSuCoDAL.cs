using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DTO;
using static DOAN_WF.DTO.SuCoDTO;
namespace DOAN_WF.DAL
{
    internal class Child_BaoCaoSuCoDAL
    {
        string strConn = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
        public DataTable NoiDungSuCo()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"SELECT MIN(MaSuCo) AS MaSuCo, LoaiSuCo
                                FROM SuCo
                                GROUP BY LoaiSuCo
                                order by MaSuCo";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable TenNV()
        {
            using (SqlConnection con = new SqlConnection(strConn))
            {
                string sql = @"select  TenNV , MaNV
                                from NhanVien";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LayMaLS()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"select MaLS
                                from LichSuVaoRa";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool GuiBaoCao(SuCoDTO sc)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();
                string sql = @"insert into SuCo (MaLS,LoaiSuCo, MoTa, ThoiGian, MaNV) values (@MaLS,@LoaiSuCo,@MoTa, @ThoiGian, @MaNV )";

                SqlCommand com = new SqlCommand(sql, conn);

                // Truyền giá trị từ đối tượng vào các biến @
                com.Parameters.AddWithValue("@MaLS", sc.MaLS);
                com.Parameters.AddWithValue("@LoaiSuCo", sc.LoaiSuCo);
                com.Parameters.AddWithValue("@MoTa", sc.MoTa);
                com.Parameters.AddWithValue("@ThoiGian", sc.ThoiGian);
                com.Parameters.AddWithValue("@MaNV", sc.MaNV);


                // Thực thi lệnh. Trả về true nếu số dòng bị ảnh hưởng > 0
                return com.ExecuteNonQuery() > 0;

            }
        }

        public DataTable GetDanhSachSuCo()
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"SELECT *
                       FROM SuCo
                       ";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }


        }
        public bool CapNhatTrangThai(int maSuCo, string trangThai)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                string sql = @"UPDATE SuCo
                       SET TrangThaiXuLy = @TrangThai
                       WHERE MaSuCo = @MaSuCo";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);
                cmd.Parameters.AddWithValue("@MaSuCo", maSuCo);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
