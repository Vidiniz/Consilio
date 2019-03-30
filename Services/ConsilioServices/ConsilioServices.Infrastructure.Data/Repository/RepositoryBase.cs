using ConsilioServices.Domain.Interfaces.Repositories;
using ConsilioServices.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsilioServices.Infrastructure.Data.Repository
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ConsilioContext _dataBase;

        public RepositoryBase()
        {
            this._dataBase = new ConsilioContext();
        }

        public int Add(TEntity obj)
        {
            _dataBase.Set<TEntity>().Add(obj);
            return _dataBase.SaveChanges();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll(int pageNumber, int recordNumbers)
        {
            var result = _dataBase.Set<TEntity>();

            var totalRegisters = result.Count();
            var count = (int)Math.Ceiling((decimal)totalRegisters / recordNumbers);
            var skip = (pageNumber - 1) * recordNumbers;

            result.Skip(skip).Take(recordNumbers).ToList();

            return result;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataBase.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dataBase.Set<TEntity>().Find(id);
        }

        public int Remove(TEntity obj)
        {
            _dataBase.Set<TEntity>().Remove(obj);
            return _dataBase.SaveChanges();
        }

        public int Update(TEntity obj)
        {
            _dataBase.Entry(obj).State = EntityState.Modified;
            return _dataBase.SaveChanges();
        }
    }
}
