namespace TT_QLSP2.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<NhomSanPham> NhomSanPhams { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhomSanPham>()
                .Property(e => e.TenNhom)
                .IsUnicode(false);

            modelBuilder.Entity<NhomSanPham>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<NhomSanPham>()
                .Property(e => e.Anh)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.TenSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MoTa)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.AnhSanPham)
                .IsUnicode(false);
        }
    }
}
