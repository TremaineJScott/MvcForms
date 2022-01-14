using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcForms.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
    }

}
