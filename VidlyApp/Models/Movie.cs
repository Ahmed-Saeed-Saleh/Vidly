using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models
{
    public class Movie
    {
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
        public short NumberInStock { get; set; }
    }
}