using AutoMapper;
using BL.ModelsBL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AutomapperProfileBL : Profile
    {
        public AutomapperProfileBL()
        {
            CreateMap<Category, CategoryBL>().ReverseMap();
            CreateMap<Transaction, TransactionBL>().ReverseMap();
        }
    }
}
