using interbank_data.Source.Database.Seeds;
using interbank_data.Source.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interbank_data.Source.Database
{
    public class InterbankDbContext : DbContext
    {
        public InterbankDbContext(DbContextOptions<InterbankDbContext> opts)
            : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonTable>()
                .HasOne<UserTable>()
                .WithOne()
                .HasForeignKey<UserTable>(u => u.PersonId)
                .IsRequired();


            modelBuilder.Seed();
        }

        public DbSet<UserTable> User { get; set; }
        public DbSet<PersonTable> Person { get; set; }
    }
}
