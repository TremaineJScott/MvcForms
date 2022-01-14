using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcForms.Models
{
    public class FormViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
   
        public bool IsSameName { get; set; }

        [Display(Name = "What's your favorite animal?")]
        public string Animal { get; set; }
        public string Message { get; set; }

        [Display(Name = "What's your full name?")]
        public string FullName { get; set; }
    }
}
