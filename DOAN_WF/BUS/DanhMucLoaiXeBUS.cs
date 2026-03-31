using DAL;
using DOAN_WF.DAL;
using System.Data;

namespace BUS
{
    public class LoaiXeBUS
    {
        private readonly DAL.LoaiXeDAL dal = new DAL.LoaiXeDAL();

        public DataTable GetAllLoaiXe() => dal.GetData();

        public DataTable SearchLoaiXe(string keyword) => dal.Search(keyword);

        public bool AddLoaiXe(string ten, string nhom) => dal.Insert(ten, nhom);

        public bool UpdateLoaiXe(int ma, string ten, string nhom) => dal.Update(ma, ten, nhom);

        public bool DeleteLoaiXe(int ma) => dal.Delete(ma);
    }
}