using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Database;
using BookEFSqt.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookEFSqt.Infrastructure.Resources
{
   public class PublishingHouseRepository : BaseRepository<PublishingHouse>, IPublishingHouseRepository
    {
        public PublishingHouseRepository(BookContext unitOfWork) : base(unitOfWork)
        {

        }
    }
}
