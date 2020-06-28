using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Resources;
using BookWebApi.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Book.Core.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sysUserInfoController : ControllerBase
    {
        private readonly ILogger<sysUserInfoController> _logger;
        private readonly IMapper _mapper;
        public ISysUserInfoRepository _sysUserInfoRepository { get; set; }

        public sysUserInfoController(ILogger<sysUserInfoController> logger, ISysUserInfoRepository sysUserInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _sysUserInfoRepository = sysUserInfoRepository;
            _mapper = mapper;
        }
        /// <summary>
        ///  获取列表
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetAllAsync")]
        [HttpPost]
        public async Task<MessageModel<List<sysUserInfoDto>>> GetAllAsync([FromBody]PagingModel model)
        {
            var blogList = await _sysUserInfoRepository.Query();
            var query =blogList.Skip(model.page * model.limit).Take(model.limit).ToList();
            var blogResources = _mapper.Map<List<sysUserInfo>, IEnumerable<sysUserInfoDto>>(query);

            return new MessageModel<List<sysUserInfoDto>>()
            {
                msg = "",
                success = true,
                status=200,
                count= blogResources.Count(),
                response =(List<sysUserInfoDto>)blogResources
            };
        }

        /// <summary>
        ///  获取一条数据
        /// </summary>
        /// <returns></returns>
        [Route("GetByIdAsync")]
        [HttpPost]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blogList = await _sysUserInfoRepository.QueryById(id);

            var StaffResources = _mapper.Map<sysUserInfo, sysUserInfoDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<sysUserInfoDto> Add(sysUserInfo staff)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    staff.uCreateTime = DateTime.Now;
                    staff.tdIsDelete = false;
                    staff.IsReportLoss = 0;
                    staff.uUpdateTime = DateTime.Now;
                    staff.uErrorCount = 0;
                    staff.uLastErrTime = DateTime.Now;
                    staff.Borrows = 0;
                    staff.Borroweds = 0;
                    staff.UnpaidFine = 0d;
                    _sysUserInfoRepository.Add(staff);
                    result = true;
                    msg = "添加成功";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<sysUserInfoDto>()
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
        public MessageModel<sysUserInfoDto> UpdateAsync(sysUserInfo dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _sysUserInfoRepository.Update(dto);
                    msg = "修改成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<sysUserInfoDto>()
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
        public MessageModel<sysUserInfoDto> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _sysUserInfoRepository.DeleteById(id);
                    msg = "删除成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<sysUserInfoDto>()
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
            var json = _sysUserInfoRepository.Info(new sysUserInfo());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
    
    }
}