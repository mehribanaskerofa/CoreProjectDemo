using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjectDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Please enter name...")]
        public string name { get; set; }
    }
}
