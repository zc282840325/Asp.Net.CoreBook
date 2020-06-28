using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.EntityFramWork.Resources;
using Microsoft.Extensions.Logging;
using Book.Core.IRepository;
using Book.Core.Model;
using Microsoft.AspNetCore.Authorization;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly ILogger<UserRoleController> _logger;
        private readonly IMapper _mapper;
        public IUserRoleRepository _UserRoleRepository { get; set; }

        public UserRoleController(ILogger<UserRoleController> logger, IUserRoleRepository UserRoleRepository, IMapper mapper)
        {
            _logger = logger;
            _UserRoleRepository = UserRoleRepository;
            _mapper = mapper;
        }
        /// <summary>
        ///  获取列表
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetAllAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogList = await _UserRoleRepository.Query();

            var blogResources = _mapper.Map<List<UserRole>, IEnumerable<UserRoleDto>>(blogList);

            return Ok(blogResources);
        }

        /// <summary>
        ///  获取一条数据
        /// </summary>
        /// <returns></returns>
        [Route("GetByIdAsync")]
        [HttpGet]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blogList = await _UserRoleRepository.QueryById(id);

            var StaffResources = _mapper.Map<UserRole, UserRoleDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<UserRoleDto> Add(UserRole staff)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _UserRoleRepository.Add(staff);
                    result = true;
                    msg = "添加成功";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<UserRoleDto>()
            {
                msg = msg,
                success = result,
            };

        }

        /// <summary>
        ///  修改一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public MessageModel<UserRoleDto> UpdateAsync(UserRole dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _UserRoleRepository.Update(dto);
                    msg = "修改成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<UserRoleDto>()
            {
                msg = msg,
                success = result,
            };
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public MessageModel<UserRoleDto> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _UserRoleRepository.DeleteById(id);
                    msg = "删除成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<UserRoleDto>()
            {
                msg = msg,
                success = result,
            };
        }
        /// <summary>
        ///  获取中英文对应字段
        /// </summary>
        /// <returns></returns>
        [Route("Info")]
        [HttpGet]
        [AllowAnonymous]
        public MessageModel<string> Info()
        {
            var json = _UserRoleRepository.Info(new UserRole());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
    }
}