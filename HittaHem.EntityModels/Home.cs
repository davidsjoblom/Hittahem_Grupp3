﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HittaHemDemo.Models
{
    public  class Home
    {
        public Home()
        {
            Favourites = new HashSet<Favourite>();
            HomeImages = new HashSet<HomeImage>();
            HomeViewings = new HashSet<HomeViewing>();
            InterestedUsers = new HashSet<InterestedUser>();
        }

        [Key]
        public int Id { get; set; }
        public int MunicipalityId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public int RoomAmount { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal LivingArea { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? UninhabitableArea { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? GardenArea { get; set; }
        public int HousingTypeId { get; set; }
        public int OwnershipTypeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BuildYear { get; set; }
        [Required]
        [StringLength(250)]
        public string UserId { get; set; }
        public int StreetId { get; set; }
        [StringLength(250)]
        public string StreetNr { get; set; }

        [ForeignKey(nameof(HousingTypeId))]
        [InverseProperty("Homes")]
        public virtual HousingType HousingType { get; set; }
        [ForeignKey(nameof(MunicipalityId))]
        [InverseProperty("Homes")]
        public virtual Municipality Municipality { get; set; }
        [ForeignKey(nameof(OwnershipTypeId))]
        [InverseProperty("Homes")]
        public virtual OwnershipType OwnershipType { get; set; }
        [ForeignKey(nameof(StreetId))]
        [InverseProperty("Homes")]
        public virtual Street Street { get; set; }
        [InverseProperty(nameof(Favourite.Home))]
        public virtual ICollection<Favourite> Favourites { get; set; }
        [InverseProperty(nameof(HomeImage.Home))]
        public virtual ICollection<HomeImage> HomeImages { get; set; }
        [InverseProperty(nameof(HomeViewing.Home))]
        public virtual ICollection<HomeViewing> HomeViewings { get; set; }
        [InverseProperty(nameof(InterestedUser.Home))]
        public virtual ICollection<InterestedUser> InterestedUsers { get; set; }
    }
}