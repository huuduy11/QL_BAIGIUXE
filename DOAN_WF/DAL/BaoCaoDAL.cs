using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace DoAn_demo.DAL
{
    internal class BaoCaoDAL
    {
        string strChuoiketnoi = "Data Source=.;Initial Catalog=QLBAIGIUXE; Integrated Security=True";


        public int DemLuotVao()
        {
            SqlConnection conn = new SqlConnection(strChuoiketnoi);
            string sql = "SELECT COUNT(*) FROM LichSuVaoRa WHERE ThoiGianVao IS NOT NULL";
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int soluot = (int)cmd.ExecuteScalar();
            conn.Close();
            return soluot;
        }

        public DataTable LocTheoCa(DateTime tuNgay, DateTime denNgay, int? maCa)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiketnoi))
            {
                string sql = @"
                            SELECT 
                                LoaiXe.MaLoaiXe as MaLoaiXe,
                                LoaiXe.TenLoaiXe as TenLoaiXe,


                                COUNT(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NOT NULL 
                                    THEN LichSuVaoRa.ThoiGianVao 
                                END) AS LuotVaoThang,

                                COUNT(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NOT NULL 
                                    THEN LichSuVaoRa.ThoiGianRa 
                                END) AS LuotRaThang,

                                COUNT(DISTINCT CASE 
                                    WHEN ThongTinXeThang.MaThe IS NOT NULL 
                                    THEN LichSuVaoRa.MaThe 
                                END) * LoaiXe.GiaTheoThang AS XeThang,
                                COUNT(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NULL 
                                    THEN LichSuVaoRa.ThoiGianVao 
                                END) AS LuotVaoVangLai,

                                COUNT(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NULL 
                                    THEN LichSuVaoRa.ThoiGianRa 
                                END) AS LuotRaVangLai,

                                SUM(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NULL 
                                    THEN ISNULL(LichSuVaoRa.TongTien, 0)
                                    ELSE 0
                                END) AS XeVangLai,

    
                                COUNT(LichSuVaoRa.ThoiGianVao) AS TongLuotVao,
                                COUNT(LichSuVaoRa.ThoiGianRa) AS TongLuotRa,

    
                                SUM(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NULL 
                                    THEN ISNULL(LichSuVaoRa.TongTien, 0)
                                    ELSE 0
                                END)
                                +
                                COUNT(DISTINCT CASE 
                                    WHEN ThongTinXeThang.MaThe IS NOT NULL 
                                    THEN LichSuVaoRa.MaThe 
                                END) * LoaiXe.GiaTheoThang AS TongDoanhThu

                        FROM LichSuVaoRa

                                LEFT JOIN ThongTinXeThang 
                                ON LichSuVaoRa.MaThe = ThongTinXeThang.MaThe

                                JOIN LoaiXe 
                                ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe

                                LEFT JOIN CaTruc 
                                ON (
                                    CAST(LichSuVaoRa.ThoiGianVao AS TIME) >= CaTruc.GioBatDau
                                    AND CAST(LichSuVaoRa.ThoiGianVao AS TIME) < CaTruc.GioKetThuc)


                        WHERE 
                            LichSuVaoRa.ThoiGianVao >= @TuNgay
                            AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                            AND (@MaCa IS NULL OR CaTruc.MaCa = @MaCa)

                        GROUP BY 
                            LoaiXe.MaLoaiXe,
                            LoaiXe.TenLoaiXe,
                            LoaiXe.GiaTheoThang

                        ORDER BY 
                            LoaiXe.MaLoaiXe";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // ngày
                da.SelectCommand.Parameters.Add("@TuNgay", SqlDbType.DateTime).Value = tuNgay.Date;
                da.SelectCommand.Parameters.Add("@DenNgay", SqlDbType.DateTime).Value = denNgay.Date;

                // ca (QUAN TRỌNG: luôn truyền, kể cả null)
                da.SelectCommand.Parameters.Add("@MaCa", SqlDbType.Int).Value =
                    (object)maCa ?? DBNull.Value;

                DataTable dt = new DataTable();

                var v = da.Fill(dt);
                return dt;
            }
        }



        public decimal TongDoanhThu(DateTime tuNgay, DateTime denNgay, int? maCa)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiketnoi))
            {
                string sql = @"SELECT 
                                SUM(CASE 
                                    WHEN ThongTinXeThang.MaThe IS NULL 
                                    THEN ISNULL(LichSuVaoRa.TongTien, 0)
                                    ELSE 0
                                END)
                                +
                                COUNT(DISTINCT CASE 
                                    WHEN ThongTinXeThang.MaThe IS NOT NULL 
                                    THEN LichSuVaoRa.MaThe 
                                END)
                                * MAX(LoaiXe.GiaTheoThang) as TongDoanhThu

                            FROM LichSuVaoRa

                                LEFT JOIN ThongTinXeThang 
                                    ON LichSuVaoRa.MaThe = ThongTinXeThang.MaThe

                                JOIN LoaiXe 
                                    ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe

                                LEFT JOIN CaTruc 
                                    ON (
                                        CAST(LichSuVaoRa.ThoiGianVao AS TIME) >= CaTruc.GioBatDau
                                        AND CAST(LichSuVaoRa.ThoiGianVao AS TIME) < CaTruc.GioKetThuc)

                            WHERE 
                                LichSuVaoRa.ThoiGianRa IS NOT NULL
                                AND LichSuVaoRa.ThoiGianVao >= @TuNgay
                                AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY,1,@DenNgay)
                                AND (@MaCa IS NULL OR CaTruc.MaCa = @MaCa";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                if (maCa.HasValue)
                    cmd.Parameters.AddWithValue("@MaCa", maCa.Value);
                else
                    cmd.Parameters.AddWithValue("@MaCa", DBNull.Value);

                conn.Open();

                object result = cmd.ExecuteScalar();

                return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
            }
        }


        public DataTable DoanhThuVeThang(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiketnoi))
            {
                string sql = @"
                                SELECT 
                                    LoaiXe.MaLoaiXe as MaLoaiXe,
                                    LoaiXe.TenLoaiXe as TenLoaiXe,
                                   
                                    COUNT(LichSuVaoRa.ThoiGianVao) AS TongLuotVao,
                                    COUNT(LichSuVaoRa.ThoiGianRa) AS TongLuotRa,
                                    COUNT(DISTINCT LichSuVaoRa.MaThe) * LoaiXe.GiaTheoThang AS TongDoanhThu
                                FROM LichSuVaoRa
                                    JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
                                    JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
                                    JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
                                WHERE LoaiThe.MaLoaiThe = 2 and  LichSuVaoRa.ThoiGianVao >= @TuNgay
                                    AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                                GROUP BY  
                                    LoaiXe.MaLoaiXe, 
                                    LoaiXe.TenLoaiXe, 
                                    LoaiXe.GiaTheoThang
                                    
                                ORDER BY TongLuotVao DESC;";


                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.Add("@TuNgay", SqlDbType.Date).Value = tuNgay.Date;
                da.SelectCommand.Parameters.Add("@DenNgay", SqlDbType.Date).Value = denNgay.Date;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;

            }
        }


    }
}
