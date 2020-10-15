using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Services
{
    public interface IDataServices<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity GetByName(string name);

        TEntity Update(TEntity data);

        TEntity Add(TEntity data);

        bool Delete(TEntity data);
    }
}
