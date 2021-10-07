using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAsp.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduct { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }

        [StringLength(255)]
        [Required]
        public string image { get; set; }

        public string description { get; set; }

        public int cost { get; set; }

        public int number { get; set; }

        public int idCat { get; set; }

        public virtual Category Category { get; set; }

        public virtual List<Order> Orders { get; set; }

        public int status { get; set; }
    }
}