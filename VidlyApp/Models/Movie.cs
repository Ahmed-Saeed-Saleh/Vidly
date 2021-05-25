﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
    public class Movie
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public MoviesType MovieType { get; set; }
        [Required]
        [Display(Name = "Movie Type")]
        public byte MoviesTypeId { get; set; }
        [Required]
        [Display(Name="Released Date")]
        public DateTime ReleasedDate { get; set; }
        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display(Name = "Number In Stock")]
        public short NumberInStock { get; set; }
    }
}