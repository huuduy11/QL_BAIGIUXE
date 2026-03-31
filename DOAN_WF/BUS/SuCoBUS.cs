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
    internal class SuCoBUS
    {
        SucoDAL dal = new SucoDAL();
        public DataTable TrangThaiXuLy()
        {
            return dal.TrangThaiXuLy();
        }
        public DataTable TraCuu(DateTime tuNgay, DateTime denNay, string trangThai)
        {
            return dal.TraCuu(tuNgay,  denNay,  trangThai);
        }
        public DataTable Thongtinsuco()
        {
            return dal.FullttsuCo();
        }
        
    }
}
