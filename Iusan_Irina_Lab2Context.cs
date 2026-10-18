using Microsoft.EntityFrameworkCore;

public class Iusan_Irina_Lab2Context(DbContextOptions<Iusan_Irina_Lab2Context> options) : DbContext(options)
{
    public DbSet<Iusan_Irina_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Iusan_Irina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Iusan_Irina_Lab2.Models.Author> Author { get; set; } = default!;
}
