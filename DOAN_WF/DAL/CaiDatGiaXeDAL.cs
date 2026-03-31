using System.Data;
using System.Data.SqlClient;
using GiaDTO; // Đảm bảo namespace này chứa class GiaXeDTO của bạn

namespace GiaDAL
{
    public class GiaXeDAL
    {
        // Chuỗi kết nối nên để ở một lớp dùng chung (DBConnect) để dễ quản lý
        private readonly string strCon = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";

        public DataTable GetBangGia()
        {
            using (var conn = new SqlConnection(strCon))
            {
                // "SELECT *" sẽ lấy toàn bộ các cột: MaLoaiXe, TenLoaiXe, NhomXe, GiaTheoGio, GiaTheoThang...
                var da = new SqlDataAdapter("SELECT * FROM LoaiXe", conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool UpdateGia(GiaXeDTO gia)
        {
            using (var conn = new SqlConnection(strCon))
            {
                // Cập nhật câu lệnh để khớp với các cột trong Database mới (nếu cần)
                string sql = "UPDATE LoaiXe SET GiaTheoGio = @gtg, GiaTheoThang = @gtt WHERE MaLoaiXe = @ma";

                var cmd = new SqlCommand(sql, conn);

                // Ánh xạ dữ liệu từ DTO vào tham số SQL
                cmd.Parameters.AddWithValue("@gtg", gia.GiaLuotDau);
                cmd.Parameters.AddWithValue("@gtt", gia.GiaThang);
                cmd.Parameters.AddWithValue("@ma", gia.MaLoaiXe);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0; // Trả về true nếu có ít nhất 1 dòng được cập nhật
            }
        }
    }
}