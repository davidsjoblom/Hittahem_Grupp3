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
        DbSet <Home> Homes { get; set; }
        DbSet <HomeImage> HomeImages { get; set; }  
        DbSet<HomeViewing> HomeViewings { get; set; }   
        DbSet<HousingType> HousingTypes { get; set; }   
        DbSet<Municipality> Municipality { get; set;}
        DbSet<OwnershipType> OwnershipTypes { get; set; }
        DbSet<Street> Streets { get; set; }           
    }
}