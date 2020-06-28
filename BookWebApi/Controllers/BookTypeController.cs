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
using Book.Comment.GlobalVars;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Permission")]
    public class BookTypeController : ControllerBase
    {
        private readonly ILogger<BookTypeController> _logger;
        private readonly IMapper _mapper;
        public IBookTypeRepository _BookTypelRepository { get; set; }

        public BookTypeController(ILogger<BookTypeController> logger, IBookTypeRepository BookTypeRepository, IMapper mapper)
        {
            _logger = logger;
            _BookTypelRepository = BookTypeRepository;
            _mapper = mapper;
        }
        /// <summary>
        ///  获取全部列表
        /// </summary>
        /// <returns></returns>
        /// 
        [Route("GetAllAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogList = await _BookTypelRepository.Query();

            var blogResources = _mapper.Map<List<BookType>, IEnumerable<BookTypeDto>>(blogList);

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
            var BookType = await _BookTypelRepository.QueryById(id);

            var StaffResources = _mapper.Map<BookType, BookTypeDto>(BookType);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<BookTypeDto> Add(BookType staff)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                  _BookTypelRepository.Add(staff);
                    msg = "添加成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookTypeDto>()
            {
                msg = msg,
                success = result

            };
        }

        /// <summary>
        ///  修改一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public MessageModel<BookTypeDto> UpdateAsync(BookType dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                     _BookTypelRepository.Update(dto);
                    msg = "修改成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookTypeDto>()
            {
                msg = msg,
                success = result

            };
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public MessageModel<BookTypeDto> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                   _BookTypelRepository.DeleteById(id);
                    msg = "删除成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookTypeDto>()
            {
                msg = msg,
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
            var json = _BookTypelRepository.Info(new BookType());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }

    }
}