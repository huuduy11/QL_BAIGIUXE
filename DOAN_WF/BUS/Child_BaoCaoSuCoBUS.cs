using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DAL;
using DOAN_WF.DTO;
namespace DOAN_WF.BUS
{
    internal class Child_BaoCaoSuCoBUS
    {
        Child_BaoCaoSuCoDAL dal = new Child_BaoCaoSuCoDAL();
        //SuCoDTO  sc = new SuCoDTO();
        public DataTable NoiDungSuCo()
        {
            return dal.NoiDungSuCo();
        }
        public DataTable TenNV()
        {
            return dal.TenNV();
        }
        public bool GuiBaoCao(SuCoDTO sc)
        {
            return dal.GuiBaoCao(sc);
        }
        public DataTable LayMaLS()
        {
            return dal.LayMaLS();
        }
        public DataTable GetDanhSachSuCo()
        {
            return dal.GetDanhSachSuCo();
        }
        public bool CapNhatTrangThai(int maSuCo, string trangThai)
        {
            return dal.CapNhatTrangThai(maSuCo, trangThai);
        }
    }
}
