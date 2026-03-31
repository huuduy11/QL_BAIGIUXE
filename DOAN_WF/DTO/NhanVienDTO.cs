using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN_WF.DTO
{
    public class NhanVienDTO
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public int MaTK { get; set; }
        public int MaCa { get; set; }
        public string TenCa { get; set; }
        public QuyenDTO Quyen { get; set; }
        public int MaQuyen { get; set; }

    }
}
