using Book.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Book.Core.IRepository.IBaseRepository;
using System.Threading.Tasks;

namespace  Book.Core.IRepository
{
   public interface IStaffRepository: IBaseRepository<Staff>
    {
    }
}
