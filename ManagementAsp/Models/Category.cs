using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAsp.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idCat { get; set; }

        [StringLength(255)]
        [Required]
        public string name { get; set; }

        public virtual List<Product> Products { get; set; }
        public int status { get; set; }
    }
}