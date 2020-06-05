using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BookEFSqt.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BookContext _dbContext;
        public BaseRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var mode = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(mode);
            _dbContext.SaveChanges();
        }

        [Obsolete]
        public async Task<List<TEntity>> Query()
        {
            return await _dbContext.Query<TEntity>().AsQueryable().ToListAsync();
        }


        public async Task<TEntity> QueryById(int objId)
        {
            return await _dbContext.FindAsync<TEntity>(objId);
        }

        public void Update(TEntity model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
        }
    }
}
