using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAsp.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idOrder { get; set; }

        public int idTransaction { get; set; }

        public int idProduct { get; set; }

        public int number { get; set; }

        public int status { get; set; }

        public virtual Product Product { get; set; }
        public virtual Transaction Transaction { get; set; }


    }
}