using Microsoft.EntityFrameworkCore;
using PrimeiraAPI.Model;


namespace PrimeiraAPI.DB
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VS91KTF\\SQLEXPRESS;Database=ApiTeste;Trusted_Connection=True; trustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
