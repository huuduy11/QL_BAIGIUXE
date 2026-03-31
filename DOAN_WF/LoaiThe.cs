namespace DoAn_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiThe")]
    public partial class LoaiThe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiThe()
        {
            TheXe = new HashSet<TheXe>();
        }

        [Key]
        public int MaLoaiThe { get; set; }

        [Required]
        [StringLength(40)]
        public string TenLoaiThe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TheXe> TheXe { get; set; }
    }
}
