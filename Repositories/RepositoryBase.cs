using Escola.Data;
using Escola.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace Escola.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _AppDbContext;
        private readonly DbSet<TEntity> _DbSet;

        public RepositoryBase(ApplicationDbContext db)
        {
            _DbSet = db.Set<TEntity>();
            _AppDbContext = db;
        }

        public void Add(TEntity obj)
        {
            try
            {
                _DbSet.Add(obj);
                _AppDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _DbSet.Remove(Get(id));
                _AppDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TEntity> GetAll()
        {
            try
            {
                return _DbSet.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TEntity Get(int id)
        {
            try
            {
                return _DbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                _DbSet.Update(obj);
                _AppDbContext.SaveChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
