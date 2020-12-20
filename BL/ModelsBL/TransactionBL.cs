﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelsBL
{
    public class TransactionBL
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public int CategoryId { get; set; }
        public CategoryBL Category { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdateDate { get; set; }
    }
}
