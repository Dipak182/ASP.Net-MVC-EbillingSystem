using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.Admin
{
    [Table("UsersRole")]
    public class UsersRole
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="Required")]
        public string RoleName { get; set; }

       // [Required(ErrorMessage = "Required")]
        public DateTime CreatedOn { get; set; }

        //[Required(ErrorMessage = "Required")]
        public DateTime ModifyOn { get; set; }

        //[Required(ErrorMessage = "Required")]
        public int CreatedBy { get; set; }

       // [Required(ErrorMessage = "Required")]
        public int ModifyBy { get; set; }

        //public int RoleId { get; set; }
    }
}