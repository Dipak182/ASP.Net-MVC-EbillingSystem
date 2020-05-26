using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.Admin
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ProductCode { get; set; }


        [Required(ErrorMessage="Required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        public bool Status { get; set; }

        public string ImageName { get; set; }
        
    }
}