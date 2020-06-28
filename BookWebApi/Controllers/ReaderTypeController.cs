using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.IRepository;
using Book.Core.EntityFramWork.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderTypeController : ControllerBase
    {
        private readonly ILogger<BookModelController> _logger;
        private readonly IMapper _mapper;
        public IReaderTypeRepository _readTypeRepository { get; set; }

        public ReaderTypeController(ILogger<BookModelController> logger, IReaderTypeRepository readTypeRepository, IMapper mapper)
        {
            _logger = logger;
            _readTypeRepository = readTypeRepository;
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
            var blogList = await _readTypeRepository.Query();

            var blogResources = _mapper.Map<List<ReaderType>, IEnumerable<ReaderTypeDto>>(blogList);

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
            var ReaderType = await _readTypeRepository.QueryById(id);

            var StaffResources = _mapper.Map<ReaderType, ReaderTypeDto>(ReaderType);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<ReaderTypeDto> Add(ReaderType staff)
        {
            string message = string.Empty;
            bool result = false;
            try
            {
              
                if (ModelState.IsValid)
                {
                    _readTypeRepository.Add(staff);
                    message = "添加成功!";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message.ToString();
                result = false;
            }
        
          
          
            return new MessageModel<ReaderTypeDto>()
            {
                msg = message,
                success = result
            };

        }

        /// <summary>
        ///  修改一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public MessageModel<ReaderTypeDto> Update(ReaderType dto)
        {
            string message = string.Empty;
            bool result = false;
            try
            {
                if (ModelState.IsValid)
                {
                    _readTypeRepository.Update(dto);
                    message = "修改成功!";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
                message = ex.Message;
               
            }
         
            return new MessageModel<ReaderTypeDto>()
            {
                msg = message,
                success = result
            };
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public MessageModel<ReaderTypeDto> Delete(int id)
        {
            string message = string.Empty;
            bool result = false;
            try
            {
                _readTypeRepository.DeleteById(id);
                message = "";
                result = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }    
            return new MessageModel<ReaderTypeDto>()
            {
                msg = message,
                success = result
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
            var json = _readTypeRepository.Info(new ReaderType());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
 
    }
}