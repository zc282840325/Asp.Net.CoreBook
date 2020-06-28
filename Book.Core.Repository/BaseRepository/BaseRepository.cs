using Book.Core.Entities;
using Book.Core.IRepository.IBaseRepository;
using Book.Core.EntityFramWork.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Book.Core.EntityFramWork;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Book.Core.Model;

namespace Book.Core.Repository.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        public IBaseRepository<TEntity> BaseDal;//通过在子类的构造函数中注入，这里是基类，不用构造函数
        public BookContext _dbContext;
        public BaseRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region 同步方法
        public void Add(TEntity model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }
        public void Update(TEntity model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
        }

        [Obsolete]
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> p)
        {
            return await _dbContext.Query<TEntity>().Where(p).AsQueryable().ToListAsync();
        }

        public void DeleteById(int id)
        {
            var mode = _dbContext.Find<TEntity>(id);
            _dbContext.Remove(mode);
            _dbContext.SaveChanges();
        }
        public string Info(TEntity entity)
        {
            var json = "[";
            Type t = entity.GetType();
            PropertyInfo[] pArray = t.GetProperties();
            int i = 0;
            Array.ForEach<PropertyInfo>(pArray, p =>
            {
                //中文名
                var displayName = p.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                //英文字段
                var name = p.Name;
                //字段
                var typename = p.PropertyType.Name;
             
                if (i == pArray.Length - 1)
                {
                    if (typename == "DateTime")
                    {
                        json += "{\"label\":\"" + displayName + "\",\"prop\":\"" + name + "\",\"type\":\"data\",\"format\":\"yyyy-MM-dd hh:mm:ss\",\"valueFormat\":\"yyyy-mm-dd hh:mm:ss\"}";
                    }
                    else
                    {
                        json += "{\"label\":\"" + displayName + "\",\"prop\":\"" + name + "\"}";
                    }
                }
                else
                {
                    if (typename == "DateTime")
                    {
                        json += "{\"label\":\"" + displayName + "\",\"prop\":\"" + name + "\",\"type\":\"data\",\"format\":\"yyyy-MM-dd hh:mm:ss\",\"valueFormat\":\"yyyy-mm-dd hh:mm:ss\"},";
                    }
                    else
                    {
                        json += "{\"label\":\"" + displayName + "\",\"prop\":\"" + name + "\"},";
                    }
                }
                i++;

            });
            json += "]";

            return json;
        }
        #endregion

        #region 异步方法
        public async Task<List<TEntity>> Query()
        {
            return await _dbContext.Query<TEntity>().AsQueryable().ToListAsync();
        }
        public async Task<TEntity> QueryById(int objId)
        {
            return await _dbContext.FindAsync<TEntity>(objId);
        }


        public async Task<bool> AddAsync(TEntity model)
        {
            await _dbContext.AddAsync<TEntity>(model);
            return await _dbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> UpdateAsync(TEntity model)
        {
             _dbContext.Update<TEntity>(model);
            return await _dbContext.SaveChangesAsync()>0;
        }

        public async Task<bool> DeleteAsync(object objId)
        {
          var model=await _dbContext.FindAsync<TEntity>(objId);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        #endregion


        //public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        //{
        //    return await BaseDal.Query(whereExpression);
        //}
    }
}
