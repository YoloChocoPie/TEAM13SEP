using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEAM13SEP.Models
{
    public class Edit
    {
        [Required(ErrorMessage = "Your elegant error message goes here")]
        public int ProductId { get; set; }
    }
}