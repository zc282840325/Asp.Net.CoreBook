using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.IServices.Base
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        void DeleteById(int id);
        void Update(TEntity model);
        Task<List<TEntity>> Query();
        Task<TEntity> QueryById(int objId);
        string Info(TEntity entity);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> p);
    }
}
