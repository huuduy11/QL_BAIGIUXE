using System;
using System.Data;
using System.Data.SqlClient;

namespace DOAN_WF.DAL
{
    internal class LichSuVaoRaDAL
    {
        string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";

        public DataTable LayDuLieu(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"SELECT 
                        LichSuVaoRa.MaLS,
                        LoaiXe.TenLoaiXe,
                        LichSuVaoRa.TongTien,
                       COALESCE(LichSuVaoRa.BienSoRa, LichSuVaoRa.BienSoVao) AS BienSo,
                        LichSuVaoRa.ThoiGianVao,
                        LichSuVaoRa.ThoiGianRa,
                        LichSuVaoRa.MaThe,
                        ISNULL(LoaiThe.TenLoaiThe, N'Xe lượt') AS TenLoaiThe
                    FROM LichSuVaoRa
                    JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
                    LEFT JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
                    LEFT JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
                    WHERE LichSuVaoRa.ThoiGianVao >= @TuNgay
                      AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                    ORDER BY LichSuVaoRa.ThoiGianVao DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable TrongBai(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"SELECT 
                        LichSuVaoRa.MaLS,
                        LoaiXe.TenLoaiXe,
                        LichSuVaoRa.TongTien,
                        COALESCE(LichSuVaoRa.BienSoRa, LichSuVaoRa.BienSoVao) AS BienSo,
                        LichSuVaoRa.ThoiGianVao,
                        CAST(NULL AS DATETIME) AS ThoiGianRa,
                        LichSuVaoRa.MaThe,
                        ISNULL(LoaiThe.TenLoaiThe, N'Xe lượt') AS TenLoaiThe
                    FROM LichSuVaoRa
                    JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
                    LEFT JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
                    LEFT JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
                    WHERE LichSuVaoRa.ThoiGianVao >= @TuNgay
                      AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                      AND (LichSuVaoRa.TrangThaiTrongBai = 1 OR LichSuVaoRa.ThoiGianRa IS NULL)
                    ORDER BY LichSuVaoRa.ThoiGianVao DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable DaRa(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"SELECT 
                            LichSuVaoRa.MaLS,
                        LoaiXe.TenLoaiXe,
                        LichSuVaoRa.TongTien,
                        COALESCE(LichSuVaoRa.BienSoRa, LichSuVaoRa.BienSoVao) AS BienSo,
                        LichSuVaoRa.ThoiGianVao,
                        LichSuVaoRa.ThoiGianRa,
                        LichSuVaoRa.MaThe,
                        ISNULL(LoaiThe.TenLoaiThe, N'Xe lượt') AS TenLoaiThe
                    FROM LichSuVaoRa
                    JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
                    LEFT JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
                    LEFT JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
                    WHERE LichSuVaoRa.ThoiGianVao >= @TuNgay
                      AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                      AND (LichSuVaoRa.TrangThaiTrongBai = 0 OR LichSuVaoRa.ThoiGianRa IS NOT NULL)
                    ORDER BY LichSuVaoRa.ThoiGianVao DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable XeThang(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"SELECT 
                            LichSuVaoRa.MaLS,
                        LoaiXe.TenLoaiXe,
                        LichSuVaoRa.TongTien,
                        COALESCE(LichSuVaoRa.BienSoRa, LichSuVaoRa.BienSoVao) AS BienSo,
                        LichSuVaoRa.ThoiGianVao,
                        LichSuVaoRa.ThoiGianRa,
                        LichSuVaoRa.MaThe,
                        LoaiThe.TenLoaiThe
                    FROM LichSuVaoRa
                    JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
                    JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
                    JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
                    WHERE LoaiThe.MaLoaiThe = 2
                      AND LichSuVaoRa.ThoiGianVao >= @TuNgay
                      AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                    ORDER BY LichSuVaoRa.ThoiGianVao DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable VangLai(DateTime tuNgay, DateTime denNgay)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"SELECT 
                        LichSuVaoRa.MaLS,
                        LoaiXe.TenLoaiXe,
                        LichSuVaoRa.TongTien,
                        COALESCE(LichSuVaoRa.BienSoRa, LichSuVaoRa.BienSoVao) AS BienSo,
                        LichSuVaoRa.ThoiGianVao,
                        LichSuVaoRa.ThoiGianRa,
                        LichSuVaoRa.MaThe,
                        LoaiThe.TenLoaiThe
                    FROM LichSuVaoRa
                    JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
                    JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
                    JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
                    WHERE LoaiThe.MaLoaiThe = 1
                      AND LichSuVaoRa.ThoiGianVao >= @TuNgay
                      AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)
                    ORDER BY LichSuVaoRa.ThoiGianVao DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Date);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable TraCuu(
    DateTime tuNgay,
    DateTime denNgay,
    bool trongBai,
    bool daRa,
    bool xeThang,
    bool vangLai)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"
        SELECT 
                            LichSuVaoRa.MaLS,
            LoaiXe.TenLoaiXe,
            LichSuVaoRa.TongTien,
            COALESCE(LichSuVaoRa.BienSoRa, LichSuVaoRa.BienSoVao) AS BienSo,
            LichSuVaoRa.ThoiGianVao,
            LichSuVaoRa.ThoiGianRa,
            LichSuVaoRa.MaThe,
            ISNULL(LoaiThe.TenLoaiThe, N'Xe lượt') AS TenLoaiThe
        FROM LichSuVaoRa
        JOIN LoaiXe ON LoaiXe.MaLoaiXe = LichSuVaoRa.MaLoaiXe
        LEFT JOIN TheXe ON TheXe.MaThe = LichSuVaoRa.MaThe
        LEFT JOIN LoaiThe ON LoaiThe.MaLoaiThe = TheXe.MaLoaiThe
        WHERE 
            LichSuVaoRa.ThoiGianVao >= @TuNgay
            AND LichSuVaoRa.ThoiGianVao < DATEADD(DAY, 1, @DenNgay)

            --Trong bãi / Đã ra
            AND
            (
                (@TrongBai = 1 AND (LichSuVaoRa.TrangThaiTrongBai = 1 OR LichSuVaoRa.ThoiGianRa IS NULL))
                OR
                (@DaRa = 1 AND (LichSuVaoRa.TrangThaiTrongBai = 0 OR LichSuVaoRa.ThoiGianRa IS NOT NULL))
                OR
                (@TrongBai = 0 AND @DaRa = 0)
            )

            -- 🪪 Xe tháng / Vãng lai
            AND
            (
                (@XeThang = 1 AND LoaiThe.MaLoaiThe = 2)
                OR
                (@VangLai = 1 AND LoaiThe.MaLoaiThe = 1)
                OR
                (@XeThang = 0 AND @VangLai = 0)
            )

        ORDER BY LichSuVaoRa.ThoiGianVao DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay.Date);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay.Date);

                da.SelectCommand.Parameters.AddWithValue("@TrongBai", trongBai);
                da.SelectCommand.Parameters.AddWithValue("@DaRa", daRa);
                da.SelectCommand.Parameters.AddWithValue("@XeThang", xeThang);
                da.SelectCommand.Parameters.AddWithValue("@VangLai", vangLai);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}