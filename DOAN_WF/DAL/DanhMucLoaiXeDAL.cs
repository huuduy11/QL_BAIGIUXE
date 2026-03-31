using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LoaiXeDAL
    {
        private readonly string strCon = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";

        public DataTable GetData()
        {
            using (var conn = new SqlConnection(strCon))
            {
                var da = new SqlDataAdapter("SELECT MaLoaiXe, TenLoaiXe, NhomXe FROM LoaiXe", conn);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool Insert(string ten, string nhom)
        {
            using (var conn = new SqlConnection(strCon))
            {
                // Bạn cần truyền cả mã vào nếu SQL không tự tăng
                // Ở đây mình ví dụ truyền mã là một số ngẫu nhiên hoặc lấy Max + 1
                string sql = "INSERT INTO LoaiXe (MaLoaiXe, TenLoaiXe, NhomXe, GiaTheoGio, GiaTheoThang) " +
                             "VALUES ((SELECT ISNULL(MAX(MaLoaiXe),0) + 1 FROM LoaiXe), @ten, @nhom, 0, 0)";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@nhom", nhom);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public bool Update(int ma, string ten, string nhom)
        {
            using (var conn = new SqlConnection(strCon))
            {
                var cmd = new SqlCommand("UPDATE LoaiXe SET TenLoaiXe = @ten, NhomXe = @nhom WHERE MaLoaiXe = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@nhom", nhom);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool Delete(int ma)
        {
            using (var conn = new SqlConnection(strCon))
            {
                var cmd = new SqlCommand("DELETE FROM LoaiXe WHERE MaLoaiXe = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable Search(string keyword)
        {
            using (var conn = new SqlConnection(strCon))
            {
                var da = new SqlDataAdapter("SELECT MaLoaiXe, TenLoaiXe, NhomXe FROM LoaiXe WHERE TenLoaiXe LIKE @key OR NhomXe LIKE @key", conn);
                da.SelectCommand.Parameters.AddWithValue("@key", "%" + keyword + "%");
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}