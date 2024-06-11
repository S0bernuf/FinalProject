using FinalProject.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database
{
    /*
     * 1. remove not used usings
     */
    public class FinalProjectDbContext : DbContext
    {
        public FinalProjectDbContext(DbContextOptions<FinalProjectDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Persons)
                .WithOne(pi => pi.User)
                .HasForeignKey(pi => pi.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete Person when User is deleted

            modelBuilder.Entity<Person>()
                .HasOne(pi => pi.Address)
                .WithOne()
                .HasForeignKey<Address>(por => por.AddressId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete Addres when Person is deleted


        }



    }
}
