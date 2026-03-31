using System;
using System.Data;
using DOAN_WF.DAL;

namespace DOAN_WF.BUS
{
    internal class ThongTinXeRaBUS
    {
        LichSuRaDAL raDAL = new LichSuRaDAL();

        public DataTable LayDuLieuXuat(int maThe,string bienSoRa)
        {
            return raDAL.LayThongTinXeXuat(maThe,bienSoRa);
        }

        // Hàm tính tiền: (Giờ Ra - Giờ Vào) * Đơn giá
        public decimal TinhTienGuiXe(DateTime gioVao, DateTime gioRa, decimal giaTheoGio)
        {
            // Tính khoảng thời gian chênh lệch
            TimeSpan duration = gioRa - gioVao;
            double tongSoGio = duration.TotalHours;

            // Sử dụng Math.Ceiling: 0.1 giờ hay 0.9 giờ đều tính là 1 giờ (5.000đ)
            // 1.1 giờ sẽ tính là 2 giờ (10.000đ)
            int soGioTinhTien = (int)Math.Ceiling(tongSoGio);

            // Nếu vừa vào chưa kịp gửi mà ra ngay (giây đầu tiên) vẫn tính 1 giờ
            if (soGioTinhTien <= 0) soGioTinhTien = 1;

            return soGioTinhTien * giaTheoGio;
        }

        public bool XacNhanXeRa(int maThe, string bienSoRa, decimal tongTien)
        {
            return raDAL.CapNhatXuatBai(maThe, bienSoRa, tongTien);
        }
    }
}