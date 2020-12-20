using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Level.Models
{
    public class CategoryModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Title { get; set; }

        public List<TransactionModel> Transactions { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}