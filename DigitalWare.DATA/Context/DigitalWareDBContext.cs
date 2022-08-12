using Microsoft.EntityFrameworkCore;
using DigitalWare.MODELS.Entities;

namespace DigitalWare.DATA.Context
{
    public partial class DigitalWareDBContext : DbContext
    {
        public DigitalWareDBContext()
        {
        }

        public DigitalWareDBContext(DbContextOptions<DigitalWareDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClienteEntitie> Clientes { get; set; } = null!;
        public virtual DbSet<ProductoEntitie> Productos { get; set; } = null!;
        public virtual DbSet<VentaEntitie> Ventas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=DigitalWareDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteEntitie>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasNoKey();
            });

            modelBuilder.Entity<ProductoEntitie>(entity =>
            {
                entity.Property(e => e.FechaIngreso).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasNoKey();
            });

            modelBuilder.Entity<VentaEntitie>(entity =>
            {
                entity.Property(e => e.ClienteId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaVenta).HasColumnType("datetime");

                entity.Property(e => e.ProductoId)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ProductoID");


                entity.HasNoKey();
                entity.Property(e => e.ValorTotal).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
