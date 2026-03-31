using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DAL;
using DOAN_WF.DTO;
namespace DOAN_WF.BUS
{
    internal class QuyenBUS
    {
        QuyenDAL quyenDAL = new QuyenDAL();
        public List<QuyenDTO> LayDanhSachQuyen()
        {
            return quyenDAL.LayDSQuyen();
        }
    }
}
