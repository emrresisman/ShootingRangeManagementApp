using Microsoft.EntityFrameworkCore;
using ShootingRangeManagementApp.Core.Interfaces;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRangeManagementApp.Core.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly StoreContext _storeContext;
        private DbSet<TEntity> _dbSet;
        public Repository(StoreContext context)
        {
            _storeContext = context;
            _dbSet = _storeContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        
        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
        // IQueryable yaz
        //public IEnumerable<TEntity> GetAll()
        //{
        //    return _dbSet.ToList();
        //}


        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            _dbSet.Remove(GetById(id));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _storeContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
