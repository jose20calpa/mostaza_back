using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Datos.Repository.DbContextMostaza
{
    public partial class DbMostazaContext : DbContext
    {
        public DbMostazaContext()
        {
        }

        public DbMostazaContext(DbContextOptions<DbMostazaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articulos> Articulos { get; set; }
        public virtual DbSet<ArticulosImagenes> ArticulosImagenes { get; set; }
        public virtual DbSet<Campanias> Campanias { get; set; }
        public virtual DbSet<CampaniasImagenes> CampaniasImagenes { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<CategoriasPrincipales> CategoriasPrincipales { get; set; }
        public virtual DbSet<CategoriasPrincipalesCategorias> CategoriasPrincipalesCategorias { get; set; }
        public virtual DbSet<Direcciones> Direcciones { get; set; }
        public virtual DbSet<Donaciones> Donaciones { get; set; }
        public virtual DbSet<EstadosArticulos> EstadosArticulos { get; set; }
        public virtual DbSet<EstadosCampanias> EstadosCampanias { get; set; }
        public virtual DbSet<EstadosReservas> EstadosReservas { get; set; }
        public virtual DbSet<EstadosSolicitudes> EstadosSolicitudes { get; set; }
        public virtual DbSet<EstadosUsuarios> EstadosUsuarios { get; set; }
        public virtual DbSet<EstadosUsuariosCategorias> EstadosUsuariosCategorias { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }
        public virtual DbSet<Perfiles> Perfiles { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<Solicitudes> Solicitudes { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<UnidadesMedidas> UnidadesMedidas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosCategoria> UsuariosCategoria { get; set; }

        // Unable to generate entity type for table 'dbo.ArticulosCategorias'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CampaniasCategoria'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=dbMostaza;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Articulos>(entity =>
            {
                entity.HasKey(e => e.IdArticulo);

                entity.Property(e => e.IdArticulo).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdDireccionNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdDireccion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_Direcciones");

                entity.HasOne(d => d.IdEstadoArituculoNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdEstadoArituculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_EstadosArticulos");

                entity.HasOne(d => d.IdUnidadMedidaNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdUnidadMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_UnidadesMedidas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Articulos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Articulos_Usuarios");
            });

            modelBuilder.Entity<ArticulosImagenes>(entity =>
            {
                entity.HasKey(e => e.IdArticuloImagen)
                    .HasName("PK__Articulo__7147525661A315D9");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.ArticulosImagenes)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticulosImagenes_Articulos");

                entity.HasOne(d => d.IdImagenNavigation)
                    .WithMany(p => p.ArticulosImagenes)
                    .HasForeignKey(d => d.IdImagen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArticulosImagenes_Imagenes");
            });

            modelBuilder.Entity<Campanias>(entity =>
            {
                entity.HasKey(e => e.IdCampania);

                entity.Property(e => e.IdCampania).ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FechaFinal).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdEstadoCampaniaNavigation)
                    .WithMany(p => p.Campanias)
                    .HasForeignKey(d => d.IdEstadoCampania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Campanias_EstadosCampanias");
            });

            modelBuilder.Entity<CampaniasImagenes>(entity =>
            {
                entity.HasKey(e => e.IdCampaniaImagen)
                    .HasName("PK__Campania__ECBE56C0B0B295EE");

                entity.HasOne(d => d.IdCampaniaNavigation)
                    .WithMany(p => p.CampaniasImagenes)
                    .HasForeignKey(d => d.IdCampania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaniasImagenes_Campanias");

                entity.HasOne(d => d.IdImagenNavigation)
                    .WithMany(p => p.CampaniasImagenes)
                    .HasForeignKey(d => d.IdImagen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CampaniasImagenes_Imagenes");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.Property(e => e.IdCategoria).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CategoriasPrincipales>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaPrincipal);

                entity.Property(e => e.IdCategoriaPrincipal).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CategoriasPrincipalesCategorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaPrincipalCategoria);

                entity.Property(e => e.IdCategoriaPrincipalCategoria).ValueGeneratedNever();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.CategoriasPrincipalesCategorias)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriasPrincipalesCategorias_Categorias");

                entity.HasOne(d => d.IdCategoriaPrincipalNavigation)
                    .WithMany(p => p.CategoriasPrincipalesCategorias)
                    .HasForeignKey(d => d.IdCategoriaPrincipal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CategoriasPrincipalesCategorias_CategoriasPrincipales");
            });

            modelBuilder.Entity<Direcciones>(entity =>
            {
                entity.HasKey(e => e.IdDireccion);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Latitud).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Longitud).HasColumnType("decimal(18, 10)");

                entity.Property(e => e.Referencia).HasMaxLength(200);

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono1).HasMaxLength(15);

                entity.Property(e => e.Telefono2).HasMaxLength(15);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Direcciones)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Direcciones_Perfiles");
            });

            modelBuilder.Entity<Donaciones>(entity =>
            {
                entity.HasKey(e => e.IdDonacion)
                    .HasName("PK__Donacion__D7181B1CDFC2B794");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.Donaciones)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_Articulos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Donaciones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Donaciones_Usuarios");
            });

            modelBuilder.Entity<EstadosArticulos>(entity =>
            {
                entity.HasKey(e => e.IdEstadoArticulo);

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EstadosCampanias>(entity =>
            {
                entity.HasKey(e => e.IdEstadoCampania);

                entity.Property(e => e.IdEstadoCampania).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EstadosReservas>(entity =>
            {
                entity.HasKey(e => e.IdEstadoReserva)
                    .HasName("PK__EstadosR__3E654CA880DDAB68");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NULL')");
            });

            modelBuilder.Entity<EstadosSolicitudes>(entity =>
            {
                entity.HasKey(e => e.IdEstadoSolicitud);

                entity.Property(e => e.IdEstadoSolicitud).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(100);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<EstadosUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuario);

                entity.Property(e => e.IdEstadoUsuario).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(10);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<EstadosUsuariosCategorias>(entity =>
            {
                entity.HasKey(e => e.IdEstadoUsuarioCategoria)
                    .HasName("PK__EstadosU__58A9A10FDC0AA680");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NULL')");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('NULL')");
            });

            modelBuilder.Entity<Imagenes>(entity =>
            {
                entity.HasKey(e => e.IdImagen);

                entity.Property(e => e.Imagen)
                    .IsRequired()
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Perfiles>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fotografia).HasColumnType("image");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Perfiles)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Perfiles_Usuarios");
            });

            modelBuilder.Entity<Reservas>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PK__Reservas__0E49C69D9F789B9A");

                entity.Property(e => e.FechaMaxima).HasColumnType("datetime");

                entity.Property(e => e.FechaReserva).HasColumnType("datetime");

                entity.HasOne(d => d.IdArticuloNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdArticulo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_Articulos");

                entity.HasOne(d => d.IdEstadoReservaNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdEstadoReserva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_EstadosReservas");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservas_Usuarios");
            });

            modelBuilder.Entity<Solicitudes>(entity =>
            {
                entity.HasKey(e => e.IdSolicitud);

                entity.Property(e => e.IdSolicitud).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(500);

                entity.Property(e => e.Nombre).HasMaxLength(200);

                entity.HasOne(d => d.IdEstadoSolicitudNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdEstadoSolicitud)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_EstadosSolicitudes");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Solicitudes_Usuarios");
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTiposUsuarios);

                entity.Property(e => e.IdTiposUsuarios).ValueGeneratedNever();

                entity.Property(e => e.Descripcion).HasMaxLength(10);

                entity.Property(e => e.TipoUsuario)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<UnidadesMedidas>(entity =>
            {
                entity.HasKey(e => e.IdUnidadMedida);

                entity.Property(e => e.IdUnidadMedida).ValueGeneratedNever();

                entity.Property(e => e.Abreviatura)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UnidadMedida)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97E721BBD8");

                entity.Property(e => e.Contrasenia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('NULL')");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasDefaultValueSql("('NULL')");

                entity.Property(e => e.Token).HasMaxLength(500);

                entity.HasOne(d => d.IdEstadoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstadoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_EstadosUsuarios");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_TiposUsuarios");
            });

            modelBuilder.Entity<UsuariosCategoria>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioCategoria);

                entity.Property(e => e.IdUsuarioCategoria).ValueGeneratedNever();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.UsuariosCategoria)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosCategoria_Categorias");

                entity.HasOne(d => d.IdEstadoUsuarioCategoriaNavigation)
                    .WithMany(p => p.UsuariosCategoria)
                    .HasForeignKey(d => d.IdEstadoUsuarioCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosCategoria_EstadosUsuariosCategorias");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosCategoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosCategoria_Usuarios");
            });
        }
    }
}
