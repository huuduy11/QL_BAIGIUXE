using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DTO;
namespace DOAN_WF.DAL
{
    internal class ThongTinXeThangDAL
    {
        string strChuoiKetNoi = @"Data Source =.;Initial Catalog=QLBAIGIUXE;Integrated Security =True";
        public DataTable LayDSxethang()
        {
            DataTable dt = new DataTable();
            string strQuery = @" SELECT 
                        xt.MaDk, 
                        xt.BienSo, 
                        xt.MauSac, 
                        lx.TenLoaiXe, 
                        xt.MaLoaiXe,
                        xt.HoTenChuXe, 
                        xt.SDT, 
                        xt.MaThe,
                        xt.NgayDangKy, 
                        xt.NgayHetHan, 
                        xt.TrangThaiActive 
                    FROM ThongTinXeThang xt
                    LEFT JOIN LoaiXe lx ON xt.MaLoaiXe = lx.MaLoaiXe";
            using (SqlConnection conn =new SqlConnection(strChuoiKetNoi))
            {
                SqlDataAdapter da = new SqlDataAdapter(strQuery,conn);
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable LayThongTinXeThangTheoMaThe(int maThe)
        {
            DataTable dt = new DataTable();
            // Sử dụng tham số @MaThe để tránh SQL Injection và lọc đúng xe
            string strQuery = @" SELECT 
                             xt.BienSo, 
                             lx.TenLoaiXe, 
                             xt.NgayHetHan
                         FROM ThongTinXeThang xt
                         LEFT JOIN LoaiXe lx ON xt.MaLoaiXe = lx.MaLoaiXe
                         WHERE xt.MaThe = @MaThe AND xt.TrangThaiActive = 1"; // Chỉ lấy xe còn hạn/đang hoạt động

            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                cmd.Parameters.AddWithValue("@MaThe", maThe);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        // Hàm này lấy danh sách thẻ tháng có trạng thái "Trống"
        public DataTable LayDanhSachTheThang()
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                // Lấy những thẻ thuộc loại thẻ tháng (MaLoaiThe = 2) 
                // và chưa được đăng ký cho xe nào (TrangThai = N'Trống')
                string sql = @"SELECT MaThe FROM TheXe 
                       WHERE MaLoaiThe = 2 AND TrangThai = N'Trống'";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable LayTheTrongVaTheDangChon(int maTheHienTai)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                // Lấy thẻ đang trống HOẶC là thẻ mà xe này đang giữ
                string sql = @"SELECT MaThe FROM TheXe 
                       WHERE MaLoaiThe = 2 
                       AND (TrangThai = N'Trống' OR MaThe = @MaTheHienTai)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaTheHienTai", maTheHienTai);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool ThemXeDKT(ThongTinXeThangDTO xt)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction(); // Dùng Transaction để đảm bảo an toàn dữ liệu
                try
                {
                    // 1. Chèn dữ liệu vào bảng ThongTinXeThang
                    string sqlInsert = @"INSERT INTO ThongTinXeThang 
                                (BienSo, MauSac, MaLoaiXe, HoTenChuXe, SDT, MaThe, NgayDangKy, NgayHetHan, TrangThaiActive) 
                                VALUES (@BienSo, @MauSac, @MaLoaiXe, @HoTenChuXe, @SDT, @MaThe, @NgayDangKy, @NgayHetHan, 1)";

                    SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn, trans);
                    cmdInsert.Parameters.AddWithValue("@BienSo", xt.BienSo);
                    cmdInsert.Parameters.AddWithValue("@MauSac", xt.MauSac);
                    cmdInsert.Parameters.AddWithValue("@MaLoaiXe", xt.MaLoaiXe);
                    cmdInsert.Parameters.AddWithValue("@HoTenChuXe", xt.HoTenChuXe);
                    cmdInsert.Parameters.AddWithValue("@SDT", xt.SDT);
                    cmdInsert.Parameters.AddWithValue("@MaThe", xt.MaThe);
                    cmdInsert.Parameters.AddWithValue("@NgayDangKy", xt.NgayDangKy);
                    cmdInsert.Parameters.AddWithValue("@NgayHetHan", xt.NgayHetHan);
                    cmdInsert.Parameters.AddWithValue("@TrangThaiActive", 1); // Mặc định là active khi thêm mới
                    cmdInsert.ExecuteNonQuery();

                    // 2. Cập nhật trạng thái Thẻ Xe sang 'Đã sử dụng'
                    string sqlUpdateThe = "UPDATE TheXe SET TrangThai = N'Đã sử dụng' WHERE MaThe = @MaThe";
                    SqlCommand cmdUpdate = new SqlCommand(sqlUpdateThe, conn, trans);
                    cmdUpdate.Parameters.AddWithValue("@MaThe", xt.MaThe);
                    cmdUpdate.ExecuteNonQuery();

                    trans.Commit(); // Hoàn tất
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback(); // Nếu lỗi thì hủy bỏ toàn bộ các bước trên
                    throw ex;
                }
            }
        }
        // Thêm tham số int maTheCu vào đây
        public bool SuaXeDKT(ThongTinXeThangDTO xt, int maTheCu)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Cập nhật thông tin xe (Giữ nguyên đoạn code của bạn)
                    string sqlUpdateXe = @"UPDATE ThongTinXeThang SET 
                                        BienSo=@BS, MauSac=@MS, MaLoaiXe=@MLX, HoTenChuXe=@HT, 
                                        SDT=@SDT, MaThe=@MT, NgayHetHan=@NHH 
                                        WHERE MaDK=@MaDK";
                    SqlCommand cmd = new SqlCommand(sqlUpdateXe, conn, trans);
                    cmd.Parameters.AddWithValue("@BS", xt.BienSo);
                    cmd.Parameters.AddWithValue("@MS", xt.MauSac);
                    cmd.Parameters.AddWithValue("@MLX", xt.MaLoaiXe);
                    cmd.Parameters.AddWithValue("@HT", xt.HoTenChuXe);
                    cmd.Parameters.AddWithValue("@SDT", xt.SDT);
                    cmd.Parameters.AddWithValue("@MT", xt.MaThe);
                    cmd.Parameters.AddWithValue("@NHH", xt.NgayHetHan);
                    cmd.Parameters.AddWithValue("@MaDK", xt.MaDK);
                    cmd.ExecuteNonQuery();

                    // 2. Logic đổi thẻ (Sử dụng maTheCu vừa được truyền vào)
                    if (xt.MaThe != maTheCu)
                    {
                        // Thẻ cũ -> Trống (Dùng Parameter để an toàn hơn nối chuỗi trực tiếp)
                        string sqlVancant = "UPDATE TheXe SET TrangThai = N'Trống' WHERE MaThe = @oldCard";
                        SqlCommand cmdOld = new SqlCommand(sqlVancant, conn, trans);
                        cmdOld.Parameters.AddWithValue("@oldCard", maTheCu);
                        cmdOld.ExecuteNonQuery();

                        // Thẻ mới -> Đã sử dụng
                        string sqlOccupied = "UPDATE TheXe SET TrangThai = N'Đã sử dụng' WHERE MaThe = @newCard";
                        SqlCommand cmdNew = new SqlCommand(sqlOccupied, conn, trans);
                        cmdNew.Parameters.AddWithValue("@newCard", xt.MaThe);
                        cmdNew.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }
        public bool XoaXeThang(int maDK, int maThe)
        {
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Xóa bản ghi xe tháng
                    string sqlDelete = "DELETE FROM ThongTinXeThang WHERE MaDK = @MaDK";
                    SqlCommand cmdDel = new SqlCommand(sqlDelete, conn, trans);
                    cmdDel.Parameters.AddWithValue("@MaDK", maDK);
                    cmdDel.ExecuteNonQuery();

                    // 2. Trả lại trạng thái TRỐNG cho thẻ xe
                    string sqlUpdateThe = "UPDATE TheXe SET TrangThai = N'Trống' WHERE MaThe = @MaThe";
                    SqlCommand cmdUp = new SqlCommand(sqlUpdateThe, conn, trans);
                    cmdUp.Parameters.AddWithValue("@MaThe", maThe);
                    cmdUp.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch { trans.Rollback(); throw; }
            }
        }
    }
}
