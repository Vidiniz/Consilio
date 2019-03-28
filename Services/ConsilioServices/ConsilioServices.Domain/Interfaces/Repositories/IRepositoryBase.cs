using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        int Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(int pageNumber, int recordNumbers);

        int Update(TEntity obj);

        int Remove(TEntity obj);

        void Dispose();
    }
}
