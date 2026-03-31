using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DOAN_WF.DAL
{
    internal class NhanVienDAL
    {
        //tạo chuỗi kết nối
        string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
        public NhanVienDTO KiemTraDangNhap(string tendangnhap, string matkhau)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
            SELECT nv.MaNV, nv.TenNV, tk.MaTK, q.MaQuyen, q.TenQuyen
            FROM TaiKhoan tk
            JOIN Quyen q ON tk.MaQuyen = q.MaQuyen
            JOIN NhanVien nv ON tk.MaTK = nv.MaTK
            WHERE tk.TaiKhoan = @user AND tk.MatKhau = @pass";
                cmd.Parameters.AddWithValue("@user", tendangnhap);
                cmd.Parameters.AddWithValue("@pass", matkhau);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                {
                    if (reader.Read())
                    {
                        var nv = new NhanVienDTO
                        {
                            MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                            TenNV = reader.GetString(reader.GetOrdinal("TenNV")),
                            MaTK = reader.IsDBNull(reader.GetOrdinal("MaTK")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaTK")),
                            MaCa = 0,
                            Quyen = new QuyenDTO
                            {
                                MaQuyen = reader.IsDBNull(reader.GetOrdinal("MaQuyen")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaQuyen")),
                                TenQuyen = reader.IsDBNull(reader.GetOrdinal("TenQuyen")) ? string.Empty : reader.GetString(reader.GetOrdinal("TenQuyen"))
                            }
                        };
                        return nv;
                    }
                }
                return null;
            }
        }
        public List<NhanVienDTO> LayDSNV()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                string sql = @"
            SELECT nv.MaNV, nv.TenNV, tk.MaTK, ct.TenCa, q.MaQuyen, q.TenQuyen
            FROM NhanVien nv
            JOIN CaTruc ct ON nv.MaCa = ct.MaCa
            JOIN TaiKhoan tk ON nv.MaTK = tk.MaTK
            JOIN Quyen q ON tk.MaQuyen = q.MaQuyen";

                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var nv = new NhanVienDTO
                    {
                        MaNV = reader.GetInt32(reader.GetOrdinal("MaNV")),
                        TenNV = reader.GetString(reader.GetOrdinal("TenNV")),
                        MaTK = reader.IsDBNull(reader.GetOrdinal("MaTK")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaTK")),
                        TenCa = reader.IsDBNull(reader.GetOrdinal("TenCa")) ? string.Empty : reader.GetString(reader.GetOrdinal("TenCa")),
                        Quyen = new QuyenDTO
                        {
                            MaQuyen = reader.IsDBNull(reader.GetOrdinal("MaQuyen")) ? 0 : reader.GetInt32(reader.GetOrdinal("MaQuyen")),
                            TenQuyen = reader.IsDBNull(reader.GetOrdinal("TenQuyen")) ? string.Empty : reader.GetString(reader.GetOrdinal("TenQuyen"))
                        }
                    };
                    dsNhanVien.Add(nv);
                }
            }
            return dsNhanVien;
        }
        public bool ThemNV(NhanVienDTO nv)
        {
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                // Bạn phải thêm @MaNV vào đây vì bảng của bạn không tự tăng ID
                string sql = "INSERT INTO NhanVien (MaNV, TenNV, MaTK, MaCa) VALUES (@MaNV, @TenNV, @MaTK, @MaCa)";

                SqlCommand com = new SqlCommand(sql, conn);

                // Truyền giá trị từ đối tượng nv vào các biến @
                com.Parameters.AddWithValue("@MaNV", nv.MaNV);
                com.Parameters.AddWithValue("@TenNV", nv.TenNV);
                com.Parameters.AddWithValue("@MaTK", nv.MaTK);
                com.Parameters.AddWithValue("@MaCa", nv.MaCa);

                // Thực thi lệnh. Trả về true nếu số dòng bị ảnh hưởng > 0
                return com.ExecuteNonQuery() > 0;
            }
        }
        public bool SuaNV(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    
                    // Chuỗi SQL cập nhật liên bảng thông qua MaTK của nhân viên
                    string sql = @"
                UPDATE NhanVien 
                SET TenNV = @ten, MaCa = @maCa 
                WHERE MaNV = @maNV;

                UPDATE TaiKhoan 
                SET MaQuyen = @maQuyen 
                WHERE MaTK = (SELECT MaTK FROM NhanVien WHERE MaNV = @maNV)";
                    
                    SqlCommand com = new SqlCommand(sql, conn);
                    com.Transaction = tran;
                    // Truyền tham số chính xác
                    com.Parameters.AddWithValue("@maNV", nv.MaNV);
                    com.Parameters.AddWithValue("@ten", nv.TenNV);
                    com.Parameters.AddWithValue("@maCa", nv.MaCa);

                    // SỬA TẠI ĐÂY: Dùng nv.MaQuyen thay vì nv.Quyen.MaQuyen để tránh lỗi Null
                    com.Parameters.AddWithValue("@maQuyen", nv.MaQuyen);

                    // Thực thi và kiểm tra
                    int rowsAffected = com.ExecuteNonQuery();
                    tran.Commit();
                    return rowsAffected > 0;
                }
                catch (Exception )
                {
                    // Ghi log lỗi nếu cần
                    throw;
                }
            }
        }
        public bool XoaNV(int maNV)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string sql = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand com = new SqlCommand(sql, conn);

                com.Parameters.AddWithValue("@MaNV", maNV);

                return com.ExecuteNonQuery() > 0;
            }
        }
        public bool KiemTraMaNV(int maNV)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM NhanVien WHERE MaNV = @MaNV";
                SqlCommand com = new SqlCommand(sql, conn);
                com.Parameters.AddWithValue("@MaNV", maNV);
                int count = (int)com.ExecuteScalar();
                return count > 0; // Trả về true nếu mã nhân viên đã tồn tại
            }
        }
        
    }
    
}
