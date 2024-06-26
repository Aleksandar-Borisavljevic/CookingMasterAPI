﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CookingMasterAPI.Models.Entity
{
    public class IngredientCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string IconPath { get; set; } = string.Empty;

        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Uid { get; set; } = string.Empty;
    }
}
