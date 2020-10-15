using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services
{
    public class DataServices<TEntity, TRepository> : IDataServices<TEntity> where TEntity : class where TRepository : Repository.IDataRepository<TEntity>
    {
        private TRepository _repository;

        public DataServices(TRepository repository)
        {
            _repository = repository;
        }

        public List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public TEntity GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public TEntity Update(TEntity data)
        {
            return _repository.Update(data);
        }

        public TEntity Add(TEntity data)
        {
            return _repository.Add(data);
        }

        public TEntity Delete(TEntity data)
        {
            return _repository.Delete(data);
        }
    }
}
