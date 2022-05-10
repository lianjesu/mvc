using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyLJ.Models;

namespace StudyLJ.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}