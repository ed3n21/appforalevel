using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Level.Models
{
    public class TransactionModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Range(9, float.MaxValue, ErrorMessage = "Please enter valid decimal Number")]
        public decimal Value { get; set; }

        [Required]
        [StringLength(200,MinimumLength = 3)]
        public string Description { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdateDate { get; set; }
    }
}