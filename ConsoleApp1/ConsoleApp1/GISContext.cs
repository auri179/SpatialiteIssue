using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class GISContext : DbContext
    {
        private readonly string _departement;
        public GISContext()
        {
            //this._departement = departement;
        }

        public GISContext(DbContextOptions<GISContext> options)
            : base(options)
        {
            //this._departement = departement;
        }

        #region Dbsets
        public virtual DbSet<GeoParcelle> GeoParcelle { get; set; }
        
        #endregion

        

        public void SetDepartement(string dept)
        {
            this.Database.GetDbConnection().ConnectionString = string.Format(this.Database.GetDbConnection().ConnectionString, dept);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = e:\\Cadastre\\Cadastre33.sqlite", x => x.UseNetTopologySuite());
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            

            modelBuilder.Entity<GeoParcelle>(entity =>
            {
                entity.HasKey(e => e.OgcFid);

                entity.ToTable("geo_parcelle");

                entity.HasIndex(e => e.GeoParcelle1)
                    .HasName("geo_parcelle_geo_parcelle");

                entity.HasIndex(e => e.GeoSection)
                    .HasName("geo_parcelle_geo_section_idx");

                entity.HasIndex(e => e.Idu)
                    .HasName("geo_parcelle_idu_idx");

                entity.HasIndex(e => e.OgcFid)
                    .HasName("idx_geo_parcelle_ogc_fid");

                entity.Property(e => e.OgcFid)
                    .HasColumnName("ogc_fid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Annee)
                    .IsRequired()
                    .HasColumnName("annee");

                entity.Property(e => e.Coar).HasColumnName("coar");

                entity.Property(e => e.Codm).HasColumnName("codm");

                entity.Property(e => e.CreatDate)
                    .HasColumnName("creat_date")
                    .HasColumnType("date");

                entity.Property(e => e.GeoIndp).HasColumnName("geo_indp");

                entity.Property(e => e.GeoParcelle1)
                    .IsRequired()
                    .HasColumnName("geo_parcelle");

                entity.Property(e => e.GeoSection)
                    .IsRequired()
                    .HasColumnName("geo_section");

                entity.Property(e => e.GeoSubdsect).HasColumnName("geo_subdsect");

                entity.Property(e => e.Geom).HasColumnName("geom");

                entity.Property(e => e.Idu).HasColumnName("idu");

                entity.Property(e => e.Lot).HasColumnName("lot");

                entity.Property(e => e.ObjectRid).HasColumnName("object_rid");

                entity.Property(e => e.Supf)
                    .HasColumnName("supf")
                    .HasColumnType("numeric");

                entity.Property(e => e.Tex).HasColumnName("tex");

                entity.Property(e => e.Tex2).HasColumnName("tex2");

                entity.Property(e => e.UpdateDat)
                    .HasColumnName("update_dat")
                    .HasColumnType("date");
            });

            
        }
    }
}
