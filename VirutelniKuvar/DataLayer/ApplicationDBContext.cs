using DataLayer.Models;
using System.Data.Entity;

namespace DataLayer
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Recept> Recepti { get; set; }
        public DbSet<Sastojak> Sastojci { get; set; }
        public DbSet<Stavka> Stavke { get; set; }

        public ApplicationDbContext() : base("name=DefaultConnection")
        {
        }
    }
}
