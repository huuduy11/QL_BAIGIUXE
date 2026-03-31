using DOAN_WF.DAL;
using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_WF.BUS
{
    internal class TheXeBUS
    {
            DAL.TheXeDAL thexeVL = new DAL.TheXeDAL();
            public int LayMaTheVangLaiTĐ(int maLoaiThe)
            {
                return thexeVL.LayMaTheVangLaiTĐ(maLoaiThe);
            }
            public string LayBienSoXeThang(int maThe)
            {
                // Gọi hàm từ tầng DAL
                // Giả sử đối tượng DAL của bạn tên là theXeDAL
                string bs = thexeVL.LayBienSoTuMaTheThang(maThe);

                if (string.IsNullOrEmpty(bs))
                {
                    return null; // Hoặc trả về chuỗi rỗng nếu không tìm thấy
                }

                return bs;
            }
        public bool IsTheThangDangTrongBai(int maThe)
            {
                return thexeVL.KiemTraTheThangDangTrongBai(maThe);
            }
            public bool CapNhatTrangThaiThe(int maThe, string trangThai)
            {
                return thexeVL.CapNhatTrangThaiThe(maThe, trangThai);
            }
            public bool KiemTraTheThangHopLe(int maThe)
            {
                return thexeVL.KiemTraTheThangHopLe(maThe);
            }

    }
}
