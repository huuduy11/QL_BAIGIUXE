using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOAN_WF.DAL;
namespace DOAN_WF.BUS
{
    internal class LoaiXeBUS
    {
        LoaiXeDAL loaixe= new LoaiXeDAL();
        public DataTable Laydanhsachloaixe()
        {
            return loaixe.Laydanhsachloaixe();
        }
    }
}
