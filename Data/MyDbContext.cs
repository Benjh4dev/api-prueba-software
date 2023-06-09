
using Microsoft.EntityFrameworkCore;

using API.Models;
namespace API.Data
{
using Microsoft.EntityFrameworkCore;
using API.Models;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Reserve> Reserves { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Agregar usuarios
        modelBuilder.Entity<User>().HasData(
            new User { id = 1, name = "Usuario 1", facultad = "Facultad 1" },
            new User { id = 2, name = "Usuario 2", facultad = "Facultad 2" }
        );

        // Agregar libros
        modelBuilder.Entity<Book>().HasData(
            new Book { id_book = 1, name = "Libro 1", description = "Descripción del libro 1" },
            new Book { id_book = 2, name = "Libro 2", description = "Descripción del libro 2" },
            new Book { id_book = 3, name = "Libro 3", description = "Descripción del libro 3" },
            new Book { id_book= 4, name = "Libro 4", description = "Descripción del libro 4" }
        );

        // Agregar reservas
        modelBuilder.Entity<Reserve>().HasData(
            new Reserve { id = 1, user_id = 1, book_id = 1,date_reserve = DateTime.Now },
            new Reserve { id = 2, user_id = 1, book_id = 2,date_reserve = DateTime.Now.AddDays(-7) },
            new Reserve { id = 3, user_id = 2, book_id = 3,date_reserve = DateTime.Now.AddDays(-14) },
            new Reserve { id = 4, user_id = 2, book_id = 4,date_reserve = DateTime.Now.AddDays(-21) }
        );

        base.OnModelCreating(modelBuilder);
    }
}

}
