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
    public class ModuleController : ControllerBase
    {
        private readonly ILogger<ModuleController> _logger;
        private readonly IMapper _mapper;
        public IModuleRepository _ModuleRepository { get; set; }

        public ModuleController(ILogger<ModuleController> logger, IModuleRepository ModuleRepository, IMapper mapper)
        {
            _logger = logger;
            _ModuleRepository = ModuleRepository;
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
            var blogList = await _ModuleRepository.Query();

            var blogResources = _mapper.Map<List<Module>, IEnumerable<ModuleDto>>(blogList);

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
            var blogList = await _ModuleRepository.QueryById(id);

            var StaffResources = _mapper.Map<Module, ModuleDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<ModuleDto> Add(Module staff)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _ModuleRepository.Add(staff);
                    result = true;
                    msg = "添加成功";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<ModuleDto>()
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
        public MessageModel<ModuleDto> UpdateAsync(Module dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _ModuleRepository.Update(dto);
                    msg = "修改成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<ModuleDto>()
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
        public MessageModel<ModuleDto> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _ModuleRepository.DeleteById(id);
                    msg = "删除成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<ModuleDto>()
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
            var json = _ModuleRepository.Info(new Module());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
    }
}