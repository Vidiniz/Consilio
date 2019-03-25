using System.Collections.Generic;

namespace ConsilioServices.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(int numberRegisters, int maxRegisters);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
