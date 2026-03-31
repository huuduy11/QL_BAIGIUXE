using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DOAN_WF.DTO;
namespace DOAN_WF.DAL
{
    internal class LichSuVaoDAL
    {

        public List <LichSuVaoRaDTO> Laydulieuxedavao()
        {
            List<LichSuVaoRaDTO> lsxevao = new List<LichSuVaoRaDTO>();
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                // JOIN 3 bảng: LichSuVaoRa -> TheXe (lấy mã loại) -> LoaiThe (lấy tên loại)
                string strQuery = @"SELECT ls.MaLS, ls.MaThe, t.MaLoaiThe, 
                           nv.TenNV, lx.TenLoaiXe, 
                           ls.BienSoVao, ls.ThoiGianVao, ls.MaNV, ls.MaLoaiXe, ls.TrangThaiTrongBai 
                    FROM LichSuVaoRa ls
                    JOIN TheXe t ON ls.MaThe = t.MaThe
                    JOIN NhanVien nv ON ls.MaNV = nv.MaNV
                    JOIN LoaiXe lx ON ls.MaLoaiXe = lx.MaLoaiXe
                    WHERE ls.TrangThaiTrongBai = 1 
                    ORDER BY ls.ThoiGianVao DESC";

                SqlCommand comm = new SqlCommand(strQuery, conn);
                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LichSuVaoRaDTO ls = new LichSuVaoRaDTO();
                        ls.MaLS = Convert.ToInt32(reader["MaLS"]);
                        ls.MaThe = Convert.ToInt32(reader["MaThe"]);
                        ls.MaLoaiThe = Convert.ToInt32(reader["MaLoaiThe"]);
                        ls.TenNV = reader["TenNV"].ToString();
                        ls.TenLoaiXe = reader["TenLoaiXe"].ToString();
                        ls.BienSoVao = reader["BienSoVao"].ToString();
                        ls.ThoiGianVao = Convert.ToDateTime(reader["ThoiGianVao"]);
                        ls.MaNV = Convert.ToInt32(reader["MaNV"]);
                        ls.MaLoaiXe = Convert.ToInt32(reader["MaLoaiXe"]);
                        ls.TrangThaiTrongBai = Convert.ToBoolean(reader["TrangThaiTrongBai"]);

                        lsxevao.Add(ls);
                    }
                }
            }
            return lsxevao;
        }
        public bool ChoXeIntoBai(LichSuVaoRaDTO dto)
        {
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string sql = @"INSERT INTO LichSuVaoRa (MaThe, BienSoVao, ThoiGianVao, MaNV, MaLoaiXe, TrangThaiTrongBai) 
                       VALUES (@MaThe, @BienSoVao, GETDATE(), @MaNV, @MaLoaiXe, 1)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaThe", dto.MaThe);
                    cmd.Parameters.AddWithValue("@BienSoVao", dto.BienSoVao);
                    cmd.Parameters.AddWithValue("@MaNV", dto.MaNV);
                    cmd.Parameters.AddWithValue("@MaLoaiXe", dto.MaLoaiXe);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // Hàm đếm số lượng thẻ VL còn trống trong bãi để hiển thị
        public int DemTheVangLaiTrong()
        {
            string strChuoiKetNoi = @"Data Source=.;Initial Catalog=QLBAIGIUXE;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(strChuoiKetNoi))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM TheXe WHERE MaLoaiThe = 1 AND TrangThai = N'Trống'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
