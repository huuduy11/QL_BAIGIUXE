using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DoAn_demo
{
    public partial class baocaodoanhthu : DbContext
    {
        public baocaodoanhthu()
            : base("name=baocaodoanhthu")
        {
        }

        public virtual DbSet<CaTruc> CaTruc { get; set; }
        public virtual DbSet<LichSuVaoRa> LichSuVaoRa { get; set; }
        public virtual DbSet<LoaiThe> LoaiThe { get; set; }
        public virtual DbSet<LoaiXe> LoaiXe { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<Quyen> Quyen { get; set; }
        public virtual DbSet<SuCo> SuCo { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoan { get; set; }
        public virtual DbSet<TheXe> TheXe { get; set; }
        public virtual DbSet<ThongTinXeThang> ThongTinXeThang { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LichSuVaoRa>()
                .Property(e => e.TongTien)
                .HasPrecision(20, 2);

            modelBuilder.Entity<LoaiXe>()
                .Property(e => e.GiaTheoGio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<LoaiXe>()
                .Property(e => e.GiaTheoThang)
                .HasPrecision(15, 2);

            modelBuilder.Entity<LoaiXe>()
                .HasMany(e => e.TheXe)
                .WithRequired(e => e.LoaiXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiXe>()
                .HasMany(e => e.ThongTinXeThang)
                .WithRequired(e => e.LoaiXe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.TaiKhoan)
                .WithRequired(e => e.Quyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheXe>()
                .HasMany(e => e.LichSuVaoRa)
                .WithRequired(e => e.TheXe)
                .WillCascadeOnDelete(false);
        }
    }
}
