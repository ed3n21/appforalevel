using AutoMapper;
using BL.ModelsBL;
using level.Models;
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
            CreateMap<CategoryBL, SuggestionModel>()
                .ForMember("data", opt => opt.MapFrom(src => src.Id))
                .ForMember("value", opt => opt.MapFrom(src => src.Title));
            //CreateMap<IEnumerable<TransactionBL>, ChartModel>().ForMember("chartData", opt => opt.MapFrom(src => { src.ToList();     }));
            //CreateMap<TransactionModel, TransactionIndexModel>().ForMember("CategoryTitle", opt => opt.MapFrom(src => src.Category.Title));
        }
    }
}