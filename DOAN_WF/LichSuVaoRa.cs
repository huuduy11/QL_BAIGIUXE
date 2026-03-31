namespace DoAn_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichSuVaoRa")]
    public partial class LichSuVaoRa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichSuVaoRa()
        {
            SuCo = new HashSet<SuCo>();
        }

        [Key]
        public int MaLS { get; set; }

        public int MaThe { get; set; }

        [Required]
        [StringLength(20)]
        public string BienSoVao { get; set; }

        [StringLength(20)]
        public string BienSoRa { get; set; }

        public DateTime? ThoiGianVao { get; set; }

        public DateTime? ThoiGianRa { get; set; }

        public decimal? TongTien { get; set; }

        public int? MaNV { get; set; }

        public bool? TrangThaiTrongBai { get; set; }

        public int? MaLoaiXe { get; set; }

        public virtual TheXe TheXe { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuCo> SuCo { get; set; }
    }
}
