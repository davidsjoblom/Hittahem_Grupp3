﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HittaHemEntityModels
{
    public  class Home
    {
     
       
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
    
        public HousingType HousingType { get; set; }      
      
        public  Municipality Municipality { get; set; }
     
        public  OwnershipType OwnershipType { get; set; }
        public  Street Street { get; set; }
    
        
  
        public  ICollection<HomeImage> HomeImages { get; set; }
  
        public  ICollection<HomeViewing> HomeViewings { get; set; }

    }
}