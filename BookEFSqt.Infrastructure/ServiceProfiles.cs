using AutoMapper;
using AutoMapper.Configuration;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.EntityFramWork.Resources;
using Book.Core.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Book.Core.EntityFramWork
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
            CreateMap<ReaderType, ReaderTypeDto>();
            CreateMap<BookModel, BookModelDto>();
            CreateMap<FineBill, FineBillDto>();
            CreateMap<BookStorage, BookStorageDto>();
            CreateMap<BookStorageDetails, BookStorageDetailsDto>();
            CreateMap<BookDamaged, BookDamagedDto>();
            CreateMap<BookDamagedDetails, BookDamagedDetailsDto>();
            CreateMap<Borrow, BorrowDto>();

            CreateMap<Model.Module, ModuleDto>();
            CreateMap<ModulePermission, ModulePermissionDto>();
            CreateMap<Permission, PermissionDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<RoleModulePermission, RoleModulePermissionDto>();
            CreateMap<sysUserInfo, sysUserInfoDto>();
            CreateMap<UserRole, UserRoleDto>();

            CreateMap<Feature, FeatureDto>();
        }
    }
}
