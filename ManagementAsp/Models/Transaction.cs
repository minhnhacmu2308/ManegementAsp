using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementAsp.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTranSaction { get; set; }

        public int amount { get; set; }

        public DateTime createdAt { get; set; }

        public virtual int status { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}