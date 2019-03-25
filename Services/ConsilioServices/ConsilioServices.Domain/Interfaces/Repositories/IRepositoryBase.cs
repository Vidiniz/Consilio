using System;
using System.Collections.Generic;
using System.Text;

namespace ConsilioServices.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(int pageNumber, int recordNumbers);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
