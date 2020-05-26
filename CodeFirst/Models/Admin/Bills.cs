using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirst.Models.Admin
{
    [Table("PrintBill")]

    public class Bills
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ProductId { get; set; }
        public string SessionId { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Required")]
        public int Qty { get; set; }

        public decimal Total { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Status { get; set; }

        public DateTime BillDate { get; set; }



    }
}