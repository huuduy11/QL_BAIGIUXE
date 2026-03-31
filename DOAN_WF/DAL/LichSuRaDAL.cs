using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DOAN_WF.DTO;

namespace DOAN_WF.DAL
{
    internal class LichSuRaDAL
    {
        string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";

        // Hàm tìm xe đang ở trong bãi theo mã thẻ
        public DataTable LayThongTinXeXuat(int maThe, string bienSoRa)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                // Sử dụng điều kiện OR để tìm theo 1 trong 2 hoặc cả 2
                // TrangThaiTrongBai = 1 đảm bảo xe vẫn còn trong bãi
                string sql = @"SELECT LS.MaThe, LS.BienSoVao, LS.ThoiGianVao, LX.TenLoaiXe, LX.GiaTheoGio, LT.TenLoaiThe
                       FROM LichSuVaoRa LS
                       JOIN LoaiXe LX ON LS.MaLoaiXe = LX.MaLoaiXe
                       JOIN TheXe TX ON LS.MaThe = TX.MaThe
                       JOIN LoaiThe LT ON TX.MaLoaiThe = LT.MaLoaiThe
                       WHERE (LS.MaThe = @maThe OR LS.BienSoVao = @bienSo) 
                       AND LS.TrangThaiTrongBai = 1";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);

                // Gán tham số
                da.SelectCommand.Parameters.AddWithValue("@maThe", maThe);
                // Nếu bienSoRa rỗng thì gán giá trị DBNull để tránh lỗi logic SQL
                da.SelectCommand.Parameters.AddWithValue("@bienSo", string.IsNullOrEmpty(bienSoRa) ? (object)DBNull.Value : bienSoRa);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Hàm cập nhật dữ liệu khi xe chính thức xuất bãi
        public bool CapNhatXuatBai(int maThe, string bienSoRa, decimal tongTien)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                // Cập nhật ThoiGianRa, BienSoRa, TongTien, TrangThaiTrongBai = 0 
                // Đồng thời trả thẻ về trạng thái 'Trống'
                string sql = @"UPDATE LichSuVaoRa 
                               SET ThoiGianRa = GETDATE(), BienSoRa = @bienSoRa, TongTien = @tongTien, TrangThaiTrongBai = 0 
                               WHERE MaThe = @maThe AND TrangThaiTrongBai = 1;
                               
                               UPDATE TheXe SET TrangThai = N'Trống' WHERE MaThe = @maThe;";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maThe", maThe);
                cmd.Parameters.AddWithValue("@bienSoRa", bienSoRa);
                cmd.Parameters.AddWithValue("@tongTien", tongTien);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}