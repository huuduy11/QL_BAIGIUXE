using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoAn_demo.DTO
{
    internal class BaoCaoDoanhThuDTO
    {
        public class BaoCaoDoanhThu
        {
            public int MaLoaiXe { get; set; }
            public string TenLoaiXe { get; set; }
            public int LuotVaoThang { get; set; }
            public int LuotRaThang { get; set; }
            public decimal XeThang { get; set; }
            public int LuotVaoVangLai { get; set; }
            public int LuotRaVangLai { get; set; }
            public decimal XeVangLai { get; set; }
            public int TongLuotVao { get; set; }
            public int TongLuotRa { get; set; }
            public decimal TongDoanhThu { get; set; }
        }
    }
}
