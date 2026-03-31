using DoAn_demo.DAL;
using System;
using System.Data;

namespace DoAn_demo.BUS
{
    internal class BaoCaoBUS
    {
        //BaoCaoDAL dao = new BaoCaoDAL();

        BaoCaoDAL dal = new BaoCaoDAL();


        public DataTable LocTheoCa(DateTime tuNgay, DateTime denNgay, int? maCa)
        {
            return dal.LocTheoCa(tuNgay, denNgay, maCa);
        }
        public decimal TongDoanhThu(DateTime tuNgay, DateTime denNgay, int? maCa)
        {
            return dal.TongDoanhThu(tuNgay, denNgay, maCa);
        }
        public DataTable DoanhThuVeThang(DateTime tuNgay, DateTime denNgay)
        {
            return dal.DoanhThuVeThang(tuNgay, denNgay);
        }

    }
}