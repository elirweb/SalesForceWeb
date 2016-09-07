using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using SalesForceWeb.Domain.Base;
using SalesForceWeb.Domain.Interfaces;
using SalesForceWeb.Repository.EFDataBase;

namespace SalesForceWeb.Repository.Repositorys
{
    public class RepositoryBase<TEntity>
        : IRepositoryBase<TEntity> where TEntity : EntidadeBase
    {
        private readonly EFDataBase.Contexto contexto = null;
        private DbSet<TEntity> Entity = null;

        public RepositoryBase(Contexto context_)
        {
            contexto = context_;
            Entity = context_.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            obj.DtInclusao = DateTime.Now;
            Entity.Add(obj);
        }

        public void AddOrUpdate(TEntity obj)
        {
            if (obj.Id > 0)
                Update(obj);
            else
                Add(obj);
        }

        public void commit()
        {
            try
            {
                contexto.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State, eve.Entry.CurrentValues);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        System.IO.File.AppendText(@"c:\errors.txt" + ve.ErrorMessage +ve.PropertyName);
                    }
                }
                throw;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IQueryable<TEntity> Get()
        {
            return Entity.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entity.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return Entity.Find(id);
        }

        public void Remove(TEntity obj)
        {
            Entity.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            obj.DtAlteracao = DateTime.Now;
            contexto.Entry(obj).State = EntityState.Modified;

        }
    }
}
