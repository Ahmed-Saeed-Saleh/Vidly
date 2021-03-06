using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
    public class Movie
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
        public MoviesType MovieType { get; set; }
        [Required]
        public byte MoviesTypeId { get; set; }
        [Required]
        public DateTime ReleasedDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Range(1,20)]
        public short NumberInStock { get; set; }
    }
}