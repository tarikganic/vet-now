﻿using System.ComponentModel.DataAnnotations;

namespace VetStat.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}