using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Data
{
    public interface c<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity GetByName(string name);

        TEntity Update(TEntity entity);

        TEntity Add(TEntity entity);

        TEntity Delete(TEntity entity);
    }
}
