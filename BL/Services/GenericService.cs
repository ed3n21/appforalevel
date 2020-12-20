using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public interface IGenericService<ModelBL>
        where ModelBL : class
    {
        void Create(ModelBL model);
        void Delete(int id);
        ModelBL Get(int id);
        IEnumerable<ModelBL> Get(string include = "");
        void Update(ModelBL model);
    }

    public abstract class GenericService<ModelBL, ModelDL> : IGenericService<ModelBL>
        where ModelBL : class
        where ModelDL : class
    {
        private readonly IGenericRepository<ModelDL> _repository;

        public GenericService()
        {
            _repository = new GenericRepository<ModelDL>();
        }

        public void Create(ModelBL modelBL)
        {
            var modelDL = Map(modelBL);
            _repository.Create(modelDL);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public ModelBL Get(int id)
        {
            return Map(_repository.Get(id));
        }

        public IEnumerable<ModelBL> Get(string include = "")
        {
            return Map(_repository.Get(include));
        }

        public void Update(ModelBL modelBL)
        {
            var modelDL = Map(modelBL);
            _repository.Update(modelDL);
        }


        public abstract ModelBL Map(ModelDL modelDL);
        public abstract ModelDL Map(ModelBL modeBL);

        public abstract IEnumerable<ModelBL> Map(IEnumerable<ModelDL> entity);
        public abstract IEnumerable<ModelDL> Map(IEnumerable<ModelBL> entity);
    }
}
