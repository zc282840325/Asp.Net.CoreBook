using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.IRepository.IBaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        void DeleteById(int id);
        void Update(TEntity model);
        Task<List<TEntity>> Query();

        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> p);
        Task<TEntity> QueryById(int objId);
        string Info(TEntity entity);

        Task<bool> DeleteAsync(object objId);

        Task<bool> AddAsync(TEntity model);

        Task<bool> UpdateAsync(TEntity model);


        //Task<List<TEntity>> QueryPageAsync(Expression<Func<TEntity, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, Expression<Func<TEntity, IKey>> strOrderByFileds)
    }
 }
