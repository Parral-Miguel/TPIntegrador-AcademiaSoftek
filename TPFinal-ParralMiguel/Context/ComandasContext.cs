using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TPFinal_ParralMiguel.Models;
using TPFinal_ParralMiguel.Controllers;



namespace TPFinal_ParralMiguel.Context
{
    public class ComandasContext : DbContext
    {
        
        //Definicion de las entidades del context. Lo que represento en BBDD
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        public ComandasContext()
        {
        }

        public ComandasContext(DbContextOptions<ComandasContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NicoCPU;Database=CocinaBBDD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {//Metodos de definicion de tablas

            //Definicion de tabla Plato
            modelBuilder.Entity<Plato>(Plato =>
            {
                //Tabla de Pedidos en BBDD
                Plato.ToTable("Platos");

                //Primary key
                Plato.HasKey(pl => pl.PlatoId);

                //Propiedades
                Plato.Property(pl => pl.PlatoNombre)
                     .IsRequired()
                     .HasMaxLength(50)
                     .IsUnicode(false)
                     .HasColumnName("nombrePlato");

                Plato.Property(pl => pl.PlatoPrecio)
                .HasColumnName("precioPlato");

                Plato.Property(pl => pl.PlatoCantidad)
                .HasColumnName("platoCantidad");

                //Seed: Datos iniciales de valores Plato para el menu
                modelBuilder.Entity<Plato>().HasData(
                new Plato
                {
                    PlatoId = Guid.NewGuid().ToString(),
                    PlatoNombre = "Milanesa con guarnición",
                    PlatoPrecio = 1500,
                    PlatoCantidad = 0
                },

                new Plato
                {
                    PlatoId = Guid.NewGuid().ToString(),
                    PlatoNombre = "Plato de pastas",
                    PlatoPrecio = 1200,
                    PlatoCantidad = 0

                },

                new Plato
                {
                    PlatoId = Guid.NewGuid().ToString(),
                    PlatoNombre = "Hamburguesa con guarnición",
                    PlatoPrecio = 1600,
                    PlatoCantidad = 0

                },

                new Plato
                {
                    PlatoId = Guid.NewGuid().ToString(),
                    PlatoNombre = "Gaseosa linea Pepsi",
                    PlatoPrecio = 750,
                    PlatoCantidad = 0

                }
            );

            });

            //Definicion de tabla Pedido
            modelBuilder.Entity<Pedido>(Pedido =>
            {
                //Tabla de Pedidos en BBDD
                Pedido.ToTable("Pedidos");

                //Primary key
                Pedido.HasKey(p => p.PedidoId);

                Pedido.Property(p => p.PedidoUsuarioId)
                .HasColumnName("pedidoUsuarioId");
                
                Pedido.Property(p => p.PedidoPreparado)
                .HasColumnName("pedidoPreparado");

                Pedido.Property(p => p.PrecioTotal)
                .HasColumnName("precioTotal");

            });

            //Definicion de tabla Usuario
            modelBuilder.Entity<Usuario>(Usuario =>
            {
                //Tabla de Pedidos en BBDD
                Usuario.ToTable("Usuarios");

                //Primary key
                Usuario.HasKey(u => u.UsuarioId);

                //Propiedades
                Usuario.Property(u => u.UsuarioNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("usuarioNombre");

                Usuario.Property(u => u.UsuarioMail)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("usuarioMail");

                Usuario.Property(u => u.Contrasenia)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("contrasenia");

                Usuario.Property(u => u.UsuarioRol)
                    .HasColumnName("rol");

            });

            //Seed: Datos iniciales de Usuario en la BBDD.
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    UsuarioId = Guid.NewGuid().ToString(),
                    UsuarioNombre = "Pepe",
                    UsuarioRol = "Admin",
                    UsuarioMail = "pepe@gmail.com",
                    Contrasenia = "123"
                },
                new Usuario
                {
                    UsuarioId = Guid.NewGuid().ToString(),
                    UsuarioNombre = "Lucia",
                    UsuarioRol = "SuperAdmin",
                    UsuarioMail = "luci@gmail.com",
                    Contrasenia = "456"
                },

                new Usuario
                {
                    UsuarioId = Guid.NewGuid().ToString(),
                    UsuarioNombre = "Jose",
                    UsuarioRol = "User",
                    UsuarioMail = "jose@gmail.com",
                    Contrasenia = "789"
                }
            );


        }

    }
}
