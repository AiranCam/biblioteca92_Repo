using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi92.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuarios
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Airan",
                    User = "usuario1",
                    Password = "1234",
                    FkRol = 1
                });
            //Insertar en la tabla roles
            modelBuilder.Entity<Rol>().HasData(
                 new Rol
                 {
                     PkRol = 1,
                     Nombre = "SA"
                 });
        }
    }
}