namespace DoAn_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongTinXeThang")]
    public partial class ThongTinXeThang
    {
        [Key]
        public int MaDK { get; set; }

        [Required]
        [StringLength(20)]
        public string BienSo { get; set; }

        [StringLength(50)]
        public string MauSac { get; set; }

        public int MaLoaiXe { get; set; }

        [StringLength(100)]
        public string HoTenChuXe { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        public int? MaThe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayHetHan { get; set; }

        public bool? TrangThaiActive { get; set; }

        public virtual LoaiXe LoaiXe { get; set; }

        public virtual TheXe TheXe { get; set; }
    }
}
