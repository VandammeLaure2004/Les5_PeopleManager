using Microsoft.EntityFrameworkCore;
using PeopleManager.Ui.Mvc.Models;

namespace PeopleManager.Ui.Mvc.Core
{
    public class PeopleManagerDbContext: DbContext
    {

        public PeopleManagerDbContext(DbContextOptions<PeopleManagerDbContext> options): base(options)
        {
            
        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Vehicle> Vehicles => Set<Vehicle>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.ResponsiblePerson)
                .WithMany(p => p.ResponsibleForVehicles)
                .HasForeignKey(v => v.ResponsiblePersonId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }

        public void Seed()
        {
            People.AddRange(new List<Person>
            {
                new Person
                {
                    FirstName = "Bavo",
                    LastName = "Ketels",
                    Email = "bavo.ketels@vives.be",
                    Description = "Lector"
                },
                new Person{FirstName = "Isabelle", LastName = "Vandoorne", Email = "isabelle.vandoorne@vives.be" },
                new Person
                {
                    FirstName = "Wim",
                    LastName = "Engelen",
                    Email = "wim.engelen@vives.be",
                    Description = "Opleidingshoofd"
                },
                new Person{FirstName = "Ebe", LastName = "Deketelaere", Email = "ebe.deketelaere@vives.be" }
            });

            SaveChanges();
        }
    }
}
