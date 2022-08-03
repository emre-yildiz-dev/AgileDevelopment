using System.Linq;
using AgileDevelopment.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileDevelopment.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Methodology>()
        //        .HasData
        //        (
        //         new Methodology
        //         {
        //             MethodologyID = 9,
        //             Title = "Rapid",
        //             Description = "Rapid Development Methodology",
        //         },
        //         new Methodology
        //         {
        //             MethodologyID = 10,
        //             Title = "DevOps",
        //             Description = "DevOps Methodology",
                      
        //         }
        //        );
        //}

        public DbSet<Methodology> Methodology { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Principle> Principle { get; set; }
        public DbSet<MindSet> MindSet { get; set; }
        public DbSet<Practice> Practice { get; set; }
        public DbSet<MethodFramework> MethodFrameworks { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<WiseSaying> WiseSaying { get; set; }
    }
}
