using Book.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Book.Core.IRepository.IBaseRepository;


namespace  Book.Core.IRepository
{
   public interface IBookModelRepository : IBaseRepository<Entities.BookModel>
    {
    }
}
