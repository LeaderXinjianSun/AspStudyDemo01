using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspStudyDemo01.Models;

namespace AspStudyDemo01.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Student Student { set; get; }
        public string PageTitle { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
