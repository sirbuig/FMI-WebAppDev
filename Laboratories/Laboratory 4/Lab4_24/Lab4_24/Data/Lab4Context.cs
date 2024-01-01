using Lab4_24.Models;
using Lab4_24.Models.Many_to_Many;
using Lab4_24.Models.One_to_Many;
using Lab4_24.Models.One_to_One;
using Microsoft.EntityFrameworkCore;

namespace Lab4_24.Data
{
    public class Lab4Context: DbContext
    {
        public DbSet<Student> Students { get; set; }

        // One to Many
        public DbSet<Model1> Models1 { get; set; }
        public DbSet<Model2> Models2 { get; set; }

        // One to One
        public DbSet<Model5> Models5 { get; set; }
        public DbSet<Model6> Models6 { get; set; }


        public Lab4Context(DbContextOptions<Lab4Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many
            modelBuilder.Entity<Model1>().HasMany(m1 => m1.Models2).WithOne(m2 => m2.Model1);

            // modelBuilder.Entity<Model2>().HasOne(m2 => m2.Model1).WithMany(m1 => m1.Models2);

            // One to One
            modelBuilder.Entity<Model5>().HasOne(m5 => m5.Model6).WithOne(m6 => m6.Model5).HasForeignKey<Model6>(m6 => m6.Model5);

            base.OnModelCreating(modelBuilder);
        }
    }
}
