using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _repositoryContext;
        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return  _repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondtition(Expression<Func<T, bool>> expression)
        {;
            return  _repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }
        public  void Create(T entity)
        {
             _repositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
             _repositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
              _repositoryContext.Set<T>().Remove(entity);
        }
    }
}
