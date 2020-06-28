using Book.Core.Entities;
using Book.Core.Repository.BaseRepository;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Database;
using Book.Core.Repository;
using System;
using System.Collections.Generic;
using Book.Core.EntityFramWork;
using System.Text;

namespace Book.Core.EntityFramWork.Resources
{
   public class PublishingHouseRepository : BaseRepository<PublishingHouse>, IPublishingHouseRepository
    {
        public PublishingHouseRepository(BookContext bookContext) : base(bookContext)
        {

        }
    }
}
