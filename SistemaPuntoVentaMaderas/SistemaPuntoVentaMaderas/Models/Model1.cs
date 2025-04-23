using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SistemaPuntoVentaMaderas.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ClientesSet> ClientesSet { get; set; }
        public virtual DbSet<ComprasSet> ComprasSet { get; set; }
        public virtual DbSet<DetalleComprasSet> DetalleComprasSet { get; set; }
        public virtual DbSet<DetalleVentasSet> DetalleVentasSet { get; set; }
        public virtual DbSet<MaderasSet> MaderasSet { get; set; }
        public virtual DbSet<PrecioCompraProveedorSet> PrecioCompraProveedorSet { get; set; }
        public virtual DbSet<PrecioVentaClienteSet> PrecioVentaClienteSet { get; set; }
        public virtual DbSet<ProveedoresSet> ProveedoresSet { get; set; }
        public virtual DbSet<RegistroAbonoClientesSet> RegistroAbonoClientesSet { get; set; }
        public virtual DbSet<RegistroAbonoProveedorSet> RegistroAbonoProveedorSet { get; set; }
        public virtual DbSet<TipoPagoSet> TipoPagoSet { get; set; }
        public virtual DbSet<UsuariosSet> UsuariosSet { get; set; }
        public virtual DbSet<VentasSet> VentasSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientesSet>()
                .HasMany(e => e.PrecioVentaClienteSet)
                .WithRequired(e => e.ClientesSet)
                .HasForeignKey(e => e.Clientes_IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClientesSet>()
                .HasMany(e => e.VentasSet)
                .WithRequired(e => e.ClientesSet)
                .HasForeignKey(e => e.ClientesSet_IdCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComprasSet>()
                .HasMany(e => e.DetalleComprasSet)
                .WithRequired(e => e.ComprasSet)
                .HasForeignKey(e => e.Compras_IdCompra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ComprasSet>()
                .HasMany(e => e.RegistroAbonoProveedorSet)
                .WithRequired(e => e.ComprasSet)
                .HasForeignKey(e => e.Compras_IdCompra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaderasSet>()
                .HasMany(e => e.PrecioCompraProveedorSet)
                .WithRequired(e => e.MaderasSet)
                .HasForeignKey(e => e.Maderas_IdMadera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MaderasSet>()
                .HasMany(e => e.PrecioVentaClienteSet)
                .WithRequired(e => e.MaderasSet)
                .HasForeignKey(e => e.Maderas_IdMadera)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrecioCompraProveedorSet>()
                .HasMany(e => e.DetalleComprasSet)
                .WithRequired(e => e.PrecioCompraProveedorSet)
                .HasForeignKey(e => e.PrecioCompraProveedorSet_IdPrecioCpm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrecioVentaClienteSet>()
                .HasMany(e => e.DetalleVentasSet)
                .WithRequired(e => e.PrecioVentaClienteSet)
                .HasForeignKey(e => e.PrecioVentaClienteSet_IdPrecioVcm)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProveedoresSet>()
                .HasMany(e => e.ComprasSet)
                .WithRequired(e => e.ProveedoresSet)
                .HasForeignKey(e => e.Proveedores_IdProveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProveedoresSet>()
                .HasMany(e => e.PrecioCompraProveedorSet)
                .WithRequired(e => e.ProveedoresSet)
                .HasForeignKey(e => e.Proveedores_IdProveedor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPagoSet>()
                .HasMany(e => e.ComprasSet)
                .WithRequired(e => e.TipoPagoSet)
                .HasForeignKey(e => e.TipoPago_IdTipoPago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPagoSet>()
                .HasMany(e => e.VentasSet)
                .WithRequired(e => e.TipoPagoSet)
                .HasForeignKey(e => e.TipoPagoSet_IdTipoPago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VentasSet>()
                .HasMany(e => e.DetalleVentasSet)
                .WithRequired(e => e.VentasSet)
                .HasForeignKey(e => e.Ventas_IdVenta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VentasSet>()
                .HasMany(e => e.RegistroAbonoClientesSet)
                .WithRequired(e => e.VentasSet)
                .HasForeignKey(e => e.Ventas_IdVenta)
                .WillCascadeOnDelete(false);
        }
    }
}
