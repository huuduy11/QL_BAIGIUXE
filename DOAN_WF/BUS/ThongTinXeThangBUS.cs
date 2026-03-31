using DOAN_WF.DAL;
using DOAN_WF.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DOAN_WF.BUS
{
    internal class ThongTinXeThangBUS
    {
        ThongTinXeThangDAL dal = new ThongTinXeThangDAL();
        public DataTable LayDSXeThang()
        {
            return dal.LayDSxethang();
        }
        public DataTable LayTenLoaiXeThang(int maThe)
        {
            return dal.LayThongTinXeThangTheoMaThe(maThe);
        }
        public DataTable LayDanhSachTheThang()
         {
                return dal.LayDanhSachTheThang();
        }
        public DataTable LayTheTrongVaTheDangChon(int maTheHienTai)
        {
            return dal.LayTheTrongVaTheDangChon(maTheHienTai);
        }
        public bool ThemXeDKT(ThongTinXeThangDTO xt)
        {
            return dal.ThemXeDKT(xt);
        }
        public bool SuaXeDKT(ThongTinXeThangDTO xt, int maTheCu)
        {
            return dal.SuaXeDKT(xt, maTheCu);
        }
        // Đổi string thành int để khớp với SQL Primary Key
        public bool XoaXeThang(int maDK, int maThe)
        {
            // Gọi xuống DAL và truyền cả 2 tham số
            return dal.XoaXeThang(maDK, maThe);
        }
    }

}
