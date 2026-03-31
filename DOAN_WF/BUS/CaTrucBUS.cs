using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DAL;
using DOAN_WF.DTO;
namespace DOAN_WF.BUS
{
    internal class CaTrucBUS
    {
        CaTrucDAL catrucdal = new CaTrucDAL();
        public List<CaTrucDTO> LayDanhSachCaTruc()
        {
            return catrucdal.LayDSCT();
        }
    }
}
