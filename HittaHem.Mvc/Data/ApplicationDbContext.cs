using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using HittaHemEntityModels;
using System.Diagnostics;
using System.Reflection.Emit;

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
            builder.Entity<Home>()
            .HasOne<HousingType>(h => h.HousingTypeId)
            .WithMany(t=> t.Homes)
            .HasForeignKey(h => h.HomeId);

            builder.Entity<Home>()
                .HasOne<Municipality>(h => h.MunicipalityId)
                .WithMany(m => m.Homes)
                .HasForeignKey(h => h.MunicipalityId);

            builder.Entity<Home>()
                .HasOne<OwnershipType>(h => h.OwnershipTypeId)
                .WithMany(o => o.Homes)
                .HasForeignKey(h=>h.OwnershipTypeId);

            builder.Entity<Home>()
                .HasOne<Street>(h=> h.StreetId)
                .WithMany(s=>s.Homes)
                .HasForeignKey(h=>h.StreetId);

            builder.Entity<HomeImage>()
                .HasOne<Home>(i => i.HomeId)
                .WithMany(h => h.HomeImages)
                .HasForeignKey(i => i.HomeId);
            builder.Entity<HomeViewing>()
                .HasOne<Home>(v => v.HomeId)
                .WithMany(h => h.HomeViewings)
                .HasForeignKey(v => v.HomeId);
           
        }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeImage> HomeImages { get; set; }
        public DbSet<HomeViewing> HomeViewings{ get; set; }
        public DbSet<HousingType> HousingTypes { get; set; }  
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<OwnershipType> OwnershipTypes { get; set; }
        public  DbSet<Street> Streets { get; set; }
    }
}