using DOAN_WF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DOAN_WF.BUS
{
    internal class LoaiTheBUS
    {
        LoaiTheDAL loaithe = new LoaiTheDAL();
        public DataTable Laydanhsachloaithe()
        {
            return loaithe.Laydanhsachloaithe();
        }
    }
}
