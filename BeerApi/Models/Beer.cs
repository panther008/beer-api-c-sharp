﻿using System.ComponentModel.DataAnnotations;

namespace BeerApi.Models
{
    public class Beer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        public double AverageRating { get; set; }
        public List<int> Ratings { get; set; } = new List<int>();
    }
}
