namespace DoAn_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TheXe")]
    public partial class TheXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheXe()
        {
            LichSuVaoRa = new HashSet<LichSuVaoRa>();
            ThongTinXeThang = new HashSet<ThongTinXeThang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThe { get; set; }

        public int MaLoaiXe { get; set; }

        public int? MaLoaiThe { get; set; }

        [Required]
        [StringLength(30)]
        public string TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuVaoRa> LichSuVaoRa { get; set; }

        public virtual LoaiThe LoaiThe { get; set; }

        public virtual LoaiXe LoaiXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinXeThang> ThongTinXeThang { get; set; }
    }
}
