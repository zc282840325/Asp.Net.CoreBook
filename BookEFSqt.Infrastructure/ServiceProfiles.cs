using AutoMapper;
using AutoMapper.Configuration;
using Book.Comment;
using Book.Core.Entities;
using BookEFSqt.Infrastructure.Resources;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookEFSqt.Infrastructure
{
    public class ServiceProfiles : Profile
    {
        public ServiceProfiles()
        {
            CreateMap<Staff, StaffDto>();
            CreateMap<PublishingHouse, PublishingHouseDto>();
            CreateMap<BookType, BookTypeDto>();
            CreateMap<ReaderType, ReaderTypeDto>();
            CreateMap<Library, LibraryDto>();
            CreateMap<Reader, ReaderDto>();
        }
    }
}
