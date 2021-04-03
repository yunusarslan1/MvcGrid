using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGrid.Models
{
    [Table("Staffs")]
    public class Staff
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50),Required]
        public string FirstName { get; set; }
        [StringLength(50), Required]
        public string LastName { get; set; }
        public int Age { get; set; }

        public Country Country { get; set; }
    }
}