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
    internal class TheXeDAL
    {
        public string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
        public int LayMaTheVangLaiTĐ(int maLoaiThe)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                // Lấy mã thẻ thấp nhất đang rảnh của loại thẻ tương ứng
                string sql = "SELECT TOP 1 MaThe FROM TheXe WHERE MaLoaiThe = @maLoaiThe AND TrangThai = N'Trống' ORDER BY MaThe ASC";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@maLoaiThe", maLoaiThe);
                object result = cmd.ExecuteScalar();
                return result != null ? (int)result : 0;
            }
        }
        public string LayBienSoTuMaTheThang(int maThe)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = "SELECT BienSo FROM ThongTinXeThang WHERE MaThe = @MaThe AND TrangThaiActive = 1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaThe", maThe);
                conn.Open();
                object res = cmd.ExecuteScalar();
                return res != null ? res.ToString() : "";
            }
        }
        public bool CapNhatTrangThaiThe(int maThe, string trangThai)
        {
           
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string sql = "UPDATE TheXe SET TrangThai = @trangThai WHERE MaThe = @maThe";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trangThai", trangThai);
                cmd.Parameters.AddWithValue("@maThe", maThe);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // kiểm tra thẻ tháng
        public bool KiemTraTheThangDangTrongBai(int maThe)
        { 

            // SQL: Đếm xem có dòng nào mà Mã thẻ khớp, Trang thái là đang trong bãi, 
            // VÀ phải là loại thẻ tháng (MaLoaiThe = 2)
            string sql = @"SELECT COUNT(*) 
                   FROM LichSuVaoRa ls
                   JOIN TheXe tx ON ls.MaThe = tx.MaThe
                   WHERE ls.MaThe = @MaThe 
                   AND ls.TrangThaiTrongBai = 1 
                   AND tx.MaLoaiThe = 2";

            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaThe", maThe);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public bool KiemTraTheThangHopLe(int maThe)
        {
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";

            // Câu lệnh SQL kiểm tra sự tồn tại của thẻ trong danh sách đăng ký xe tháng
            string sql = @"SELECT COUNT(*) FROM ThongTinXeThang 
                   WHERE MaThe = @MaThe 
                   AND TrangThaiActive = 1 
                   AND NgayHetHan >= CAST(GETDATE() AS DATE)";

            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@MaThe", maThe);

                    // Ép kiểu an toàn để lấy số lượng bản ghi trả về
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Trả về true nếu tìm thấy thẻ hợp lệ, ngược lại trả về false
                    return count > 0;
                }
                catch (Exception)
                {
                    // Ghi log lỗi nếu cần và trả về false để chặn xe vào
                    return false;
                }
            }
        }
    }
}
