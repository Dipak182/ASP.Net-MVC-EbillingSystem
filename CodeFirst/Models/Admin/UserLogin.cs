using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.Admin
{
 
    public class UserLogin
    {
        [Required(ErrorMessage="Required")]
        public string UserNmame { get; set; }

        [Required(ErrorMessage="Required")]
        public string Password { get; set; }
    }
}