using System;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactFrequency> ContactFrequencies { get; set; }
        public DbSet<ContactMethod> ContactMethods { get; set; }
        public DbSet<State> States { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasOne<State>(c => c.State);
            modelBuilder.Entity<Contact>().HasOne<ContactFrequency>(c => c.ContactFrequency);
            modelBuilder.Entity<Contact>().HasOne<ContactMethod>(c => c.ContactMethod);

            base.OnModelCreating(modelBuilder);
        }

    }
}
