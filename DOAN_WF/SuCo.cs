namespace DoAn_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuCo")]
    public partial class SuCo
    {
        [Key]
        public int MaSuCo { get; set; }

        public int? MaLS { get; set; }

        [StringLength(100)]
        public string LoaiSuCo { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public DateTime? ThoiGian { get; set; }

        public int? MaNV { get; set; }

        [StringLength(50)]
        public string TrangThaiXuLy { get; set; }

        public virtual LichSuVaoRa LichSuVaoRa { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
