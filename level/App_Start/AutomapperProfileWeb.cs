using AutoMapper;
using BL.ModelsBL;
using Level.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Level.App_Start
{
    public class AutomapperProfileWeb : Profile
    {
        public AutomapperProfileWeb()
        {
            CreateMap<CategoryBL, CategoryModel>().ReverseMap();
            CreateMap<TransactionBL, TransactionModel>().ReverseMap();
            //CreateMap<TransactionModel, TransactionIndexModel>().ForMember("CategoryTitle", opt => opt.MapFrom(src => src.Category.Title));
        }
    }
}