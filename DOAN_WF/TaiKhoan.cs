namespace DoAn_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        [Key]
        public int MaTK { get; set; }

        [Column("TaiKhoan")]
        [Required]
        [StringLength(50)]
        public string TaiKhoan1 { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        public int MaQuyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanVien { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
