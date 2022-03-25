﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HittaHemDemo.Models
{
    public partial class InterestedUser
    {
        [Key]
        public int HomeId { get; set; }
        [Key]
        [StringLength(250)]
        public string UserId { get; set; }

        [ForeignKey(nameof(HomeId))]
        [InverseProperty("InterestedUsers")]
        public virtual Home Home { get; set; }
    }
}