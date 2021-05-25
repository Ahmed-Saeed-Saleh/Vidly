using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyApp.Models;

namespace VidlyApp.ViewModels
{
    public class MovieTypesViewModel
    {
        public IEnumerable<MoviesType> MoviesTypes { get; set; }
        public Movie movie { get; set; }
        public string Title
        {
            get
            {
                if (movie != null && movie.Id != 0)
                    return "Edit Movie";

                return "New Movie";
            }
        }
    }
}