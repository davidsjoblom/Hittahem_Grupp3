﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HittaHem.Mvc.Models
{
    public partial class Image
    {
        [Key]
        public int Image_Id { get; set; }
        [Column("Image")]
        public byte[] Image1 { get; set; }
        public int? Home_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UploadingDate { get; set; }

        [ForeignKey(nameof(Home_Id))]
        [InverseProperty("Images")]
        public virtual Home Home { get; set; }
    }
}