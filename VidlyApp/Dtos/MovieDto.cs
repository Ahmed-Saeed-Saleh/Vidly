using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyApp.Dtos
{
    public class MovieDto
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
        [Required]
        public byte MoviesTypeId { get; set; }
        public DateTime ReleasedDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1, 20)]
        public short NumberInStock { get; set; }
    }
}