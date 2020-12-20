using AutoMapper;
using BL.ModelsBL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface ICategoryService : IGenericService<CategoryBL>
    {

    }

    public class CategoryService : GenericService<CategoryBL, Category>, ICategoryService
    {
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper) : base()
        {
            _mapper = mapper;
        }

        public override CategoryBL Map(Category categoryDL)
        {
            return _mapper.Map<Category, CategoryBL>(categoryDL);
        }

        public override Category Map(CategoryBL categoryBL)
        {
            return _mapper.Map<CategoryBL, Category>(categoryBL);
        }

        public override IEnumerable<CategoryBL> Map(IEnumerable<Category> categoriesDL)
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryBL>>(categoriesDL);
        }

        public override IEnumerable<Category> Map(IEnumerable<CategoryBL> categoriesBL)
        {
            return _mapper.Map<IEnumerable<CategoryBL>, IEnumerable<Category>>(categoriesBL);
        }
    }
}
