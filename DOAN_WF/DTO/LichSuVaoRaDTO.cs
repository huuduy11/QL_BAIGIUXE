using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_WF.DTO
{
    internal class LichSuVaoRaDTO
    {
        public int MaLS { get;set;  }
        public int MaThe { get;set; }
        public int MaLoaiThe { get; set; }
        public string TenLoaiThe { get; set; }
        public string BienSoVao { get; set; }
        public string BienSoRa { get;set; } 
        public DateTime ThoiGianVao { get; set; }
        public DateTime ThoiGianRa { get; set; }
        public decimal TongTien { get; set; }
        public int MaLoaiXe { get; set; }
        public int MaNV { get; set; }
        public bool TrangThaiTrongBai { get; set; }
        public string TenNV { get; set; }   
        public string TenLoaiXe { get; set; } 
    }
}
