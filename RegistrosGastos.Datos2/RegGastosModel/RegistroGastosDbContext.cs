using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RegistrosGastos.Datos2.RegGastosModel
{
    public partial class RegistroGastosDbContext : DbContext
    {
        public RegistroGastosDbContext()
        {
        }

        public RegistroGastosDbContext(DbContextOptions<RegistroGastosDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Monedum> Moneda { get; set; }
        public virtual DbSet<MovimGasto> MovimGastos { get; set; }
        public virtual DbSet<TipoCambio> TipoCambios { get; set; }
        public virtual DbSet<TipoGasto> TipoGastos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=WIN-3VU0IUD67IK\\SQLEXPRESS;Database=RegistroGastos;User Id=sa;Password=Flpvrgs1966");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Monedum>(entity =>
            {
                entity.HasKey(e => e.CodMonedaN)
                    .HasName("Moneda_PK");

                entity.Property(e => e.CodMonedaN).HasColumnName("COD_MONEDA_N");

                entity.Property(e => e.DesMoneda)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DES_MONEDA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("date")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.UsuIngreso)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USU_INGRESO");
            });

            modelBuilder.Entity<MovimGasto>(entity =>
            {
                entity.HasKey(e => e.CodMovimN)
                    .HasName("MovimGastos_PK");

                entity.Property(e => e.CodMovimN).HasColumnName("COD_MOVIM_N");

                entity.Property(e => e.CodMonedaN).HasColumnName("COD_MONEDA_N");

                entity.Property(e => e.CodTipogastoN).HasColumnName("COD_TIPOGASTO_N");

                entity.Property(e => e.DesObserva)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("DES_OBSERVA");

                entity.Property(e => e.DesReferencia)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DES_REFERENCIA");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("date")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FecRegistro)
                    .HasColumnType("date")
                    .HasColumnName("FEC_REGISTRO");

                entity.Property(e => e.MtoMoneori)
                    .HasColumnType("numeric(18, 3)")
                    .HasColumnName("MTO_MONEORI");

                entity.Property(e => e.UsuIngreso)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USU_INGRESO");

                entity.HasOne(d => d.CodMonedaNNavigation)
                    .WithMany(p => p.MovimGastos)
                    .HasForeignKey(d => d.CodMonedaN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovimGastos_Moneda_FK");

                entity.HasOne(d => d.CodTipogastoNNavigation)
                    .WithMany(p => p.MovimGastos)
                    .HasForeignKey(d => d.CodTipogastoN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MovimGastos_TipoGasto_FK");
            });

            modelBuilder.Entity<TipoCambio>(entity =>
            {
                entity.HasKey(e => e.CodTipocambioN)
                    .HasName("TipoCambio_PK");

                entity.ToTable("TipoCambio");

                entity.HasIndex(e => new { e.FecTipocambio, e.CodMoneoriN, e.CodMonedestN }, "TipoCambio__UN")
                    .IsUnique();

                entity.Property(e => e.CodTipocambioN).HasColumnName("COD_TIPOCAMBIO_N");

                entity.Property(e => e.CodMonedestN).HasColumnName("COD_MONEDEST_N");

                entity.Property(e => e.CodMoneoriN).HasColumnName("COD_MONEORI_N");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("date")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.FecTipocambio)
                    .HasColumnType("date")
                    .HasColumnName("FEC_TIPOCAMBIO");

                entity.Property(e => e.MtoTipocambio)
                    .HasColumnType("numeric(10, 6)")
                    .HasColumnName("MTO_TIPOCAMBIO");

                entity.Property(e => e.UsuIngreso)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USU_INGRESO");

                entity.HasOne(d => d.CodMonedestNNavigation)
                    .WithMany(p => p.TipoCambioCodMonedestNNavigations)
                    .HasForeignKey(d => d.CodMonedestN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TipoCambio_Moneda_FKv1");

                entity.HasOne(d => d.CodMoneoriNNavigation)
                    .WithMany(p => p.TipoCambioCodMoneoriNNavigations)
                    .HasForeignKey(d => d.CodMoneoriN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TipoCambio_Moneda_FK");
            });

            modelBuilder.Entity<TipoGasto>(entity =>
            {
                entity.HasKey(e => e.CodTipogastoN)
                    .HasName("TipoGasto_PK");

                entity.ToTable("TipoGasto");

                entity.Property(e => e.CodTipogastoN).HasColumnName("COD_TIPOGASTO_N");

                entity.Property(e => e.DesTipogasto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DES_TIPOGASTO");

                entity.Property(e => e.FecIngreso)
                    .HasColumnType("date")
                    .HasColumnName("FEC_INGRESO");

                entity.Property(e => e.UsuIngreso)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("USU_INGRESO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
