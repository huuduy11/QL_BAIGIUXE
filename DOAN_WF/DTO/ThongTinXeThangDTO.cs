using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_WF.DTO
{
    internal class ThongTinXeThangDTO
    {
        public int MaDK { get; set; }
        public string BienSo {  get; set; }
        public string MauSac {  get; set; }
        public int MaLoaiXe { get; set; }
        public string HoTenChuXe { get; set; }
        public string SDT {  get; set; }
        public int MaThe {  get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayHetHan { get; set; }
        public bool TrangThaiActice { get; set; }

        public object TrangThaiActive { get; internal set; }
    }
}
