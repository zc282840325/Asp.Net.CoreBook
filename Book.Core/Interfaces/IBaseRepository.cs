using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Book.Core.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity model);
        void DeleteById(int id);
        void Update(TEntity model);
        Task<List<TEntity>> Query();
        Task<TEntity> QueryById(int objId);

    }
}
