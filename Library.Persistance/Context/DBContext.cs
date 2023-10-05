using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using Library.Domain.Entities;

namespace Library.Services
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContextOptions) : base(dbContextOptions)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        const string connectionString = "Your SQL Server Connection String";
        public DbSet<Users> Users { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(a => a.id); // primary key

                entity.HasOne(a => a.user) // 1 user per book
                .WithMany(u => u.BookList) // 1 user has many books
                .HasForeignKey(a => a.userID);

                entity.HasOne(a => a.author) // 1 author per book
                .WithMany(a => a.BookList) // 1 author has many books
                .HasForeignKey(a => a.authorID);

                entity.HasOne(a => a.genre) // 1 genre per book
                .WithMany(a => a.BookList) // 1 genre have many books
                .HasForeignKey(a => a.genreID);
            });

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.ToTable("Authors");
                entity.HasKey(a => a.id); // primary key
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(a => a.id); // primary key

                entity.HasOne(a => a.role) // 1 user have 1 role
                .WithMany(a => a.usersList)  // 1 role have many users
                .HasForeignKey(a => a.roleID);  
            });

            modelBuilder.Entity<Genres>(entity =>
            {
                entity.ToTable("Genres");
                entity.HasKey(a => a.id); // primary key
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(a => a.id); // primary key                       
            });
        }
    }
}



