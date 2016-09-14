using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Table365.Core.Models.Context;
using Table365.Core.Models.POCO;
using Table365.Core.Models.Repository.Interface;
using Table365.Core.Models.ViewModel;

namespace Table365.Core.Models.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public GenericRepository()
            : this(new Table365Context())
        {

            Mapper.Initialize(cfg => cfg.CreateMap<UserViewModels, User>());
        }

        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
        }

        protected DbContext Context { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            Context.Set<TEntity>().Add(instance);
            SaveChanges();
        }

        public void Update(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            Context.Entry(instance).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            Context.Entry(instance).State = EntityState.Deleted;
            SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (Context == null) return;
            Context.Dispose();
            Context = null;
        }
    }
}