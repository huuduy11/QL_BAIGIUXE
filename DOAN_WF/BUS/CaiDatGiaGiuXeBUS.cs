using GiaDAL;
using GiaDTO;
using System.Data;

namespace GiaBUS
{
    public class GiaXeBUS
    {
        private readonly GiaXeDAL dal = new GiaXeDAL();

        public DataTable GetAllGia() => dal.GetBangGia();

        public bool CapNhatGia(GiaXeDTO gia) => dal.UpdateGia(gia);
    }
}