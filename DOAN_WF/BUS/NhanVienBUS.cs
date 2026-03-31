using DOAN_WF.DAL;
using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_WF.BUS
{
    internal class NhanVienBUS
    {
        NhanVienDAL dalNV = new NhanVienDAL();

        public bool DangNhap(string user, string pass)
        {
            // Xử lý logic: chặn để trống trước khi gọi xuống CSDL
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;

            NhanVienDTO nv = dalNV.KiemTraDangNhap(user, pass);

            if (nv != null)
            {
                LuuPhienDangNhap.CurrentUser = nv; // Lưu vào phiên làm việc
                return true;
            }
            return false;
        }
        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return dalNV.LayDSNV();
        }
        public bool ThemNhanVien(NhanVienDTO nv)
        {
            return dalNV.ThemNV(nv);
        }
        public bool CapNhatNhanVien(NhanVienDTO nv)
        {
            return dalNV.SuaNV(nv);
        }
        public bool XoaNhanVien(int maNV)
        {
            return dalNV.XoaNV(maNV);
        }
        public bool KiemTraMaNV(int maNV)
        {
                return dalNV.KiemTraMaNV(maNV);
        }
    }
}
