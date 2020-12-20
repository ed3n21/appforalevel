using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ModelsBL
{
    public class CategoryBL
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<TransactionBL> transactions { get; set; }

        //public DateTime CreatedDate { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}
