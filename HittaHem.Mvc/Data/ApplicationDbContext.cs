using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HittaHemEntityModels;

namespace HittaHem.Mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //here we put all the normals OnModelCreating stuffs
        }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
        public DbSet<HomeViewing> HomeViewings{ get; set; }
        public DbSet<HousingType> HousingTypes{ get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<OwnershipType> OwnershipTypes { get; set; }
        public  DbSet<Street> Streets { get; set; }
    }
}