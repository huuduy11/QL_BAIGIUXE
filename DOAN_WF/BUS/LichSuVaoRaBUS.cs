using DOAN_WF.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_WF.BUS
{

    internal class LichSuVaoRaBUS
    {
        LichSuVaoRaDAL dal = new LichSuVaoRaDAL();

        public DataTable LayDuLieu(DateTime tuNgay, DateTime denNgay)
        {
            return dal.LayDuLieu(tuNgay, denNgay);
        }
        public DataTable TrongBai(DateTime tuNgay, DateTime denNgay)
        {
            return dal.TrongBai(tuNgay, denNgay);
        }
        public DataTable DaRa(DateTime tuNgay, DateTime denNgay)
        {
            return dal.DaRa(tuNgay, denNgay);
        }
        public DataTable XeThang(DateTime tuNgay, DateTime denNgay)
        {
            return dal.XeThang(tuNgay, denNgay);
        }
        public DataTable VangLai(DateTime tuNgay, DateTime denNgay)
        {
            return dal.VangLai(tuNgay, denNgay);
        }
        public DataTable TraCuu(
            DateTime tuNgay,
            DateTime denNgay,
            bool trongBai,
            bool daRa,
            bool xeThang,
            bool vangLai)
        {
            return dal.TraCuu(tuNgay, denNgay, trongBai, daRa, xeThang, vangLai);
        }
    }

}
