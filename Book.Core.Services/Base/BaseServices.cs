using Book.Core.IRepository.IBaseRepository;
using Book.Core.IServices.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Services.Base
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> BaseDal;//通过在子类的构造函数中注入，这里是基类，不用构造函数

        public void DeleteById(int id)
        {
            BaseDal.DeleteById(id);
        }

        public string Info(TEntity entity)
        {
           return BaseDal.Info(entity);
        }

        public async Task<List<TEntity>> Query()
        {
            return await BaseDal.Query();
        }

        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> p)
        {
            return await BaseDal.Query(p);
        }

        public async Task<TEntity> QueryById(int objId)
        {
            return await BaseDal.QueryById(objId);
        }

        public void Update(TEntity model)
        {
             BaseDal.Update(model);
        }
    }
}
