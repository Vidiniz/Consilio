﻿using ConsilioServices.Domain.Interfaces.Repositories;
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

        public void Add(TEntity obj)
        {
            _dataBase.Set<TEntity>().Add(obj);
            _dataBase.SaveChanges();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataBase.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dataBase.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _dataBase.Set<TEntity>().Remove(obj);
            _dataBase.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _dataBase.Entry(obj).State = EntityState.Modified;
            _dataBase.SaveChanges();
        }
    }
}
