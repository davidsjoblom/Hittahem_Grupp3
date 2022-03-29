﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HittaHemEntityModels
{
    public  class Municipality
    {
        public Municipality()
        {
            Homes = new HashSet<Home>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Name { get; set; }

        [InverseProperty(nameof(Home.Municipality))]
        public virtual ICollection<Home> Homes { get; set; }
    }
}