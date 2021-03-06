﻿using System;
using System.Collections.Generic;
using System.Linq;
using SalesForceWeb.Domain.Base;

namespace SalesForceWeb.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity: EntidadeBase
    {

        // todos que herdem da Base.EntidadeBase vão poder usar o Irepository
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
        void commit();
        IQueryable<TEntity> Get();
        void AddOrUpdate(TEntity obj);
        IQueryable<TEntity> Localizar(Func<TEntity, bool> predicate);
    }
}
