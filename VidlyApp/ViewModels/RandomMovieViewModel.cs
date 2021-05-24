using System.Collections.Generic;
using VidlyApp.Models;

namespace VidlyApp.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}