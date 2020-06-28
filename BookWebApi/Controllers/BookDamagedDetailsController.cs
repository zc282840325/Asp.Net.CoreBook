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
using Microsoft.AspNetCore.Authorization;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDamagedDetailsDetailsController : ControllerBase
    {
        private readonly ILogger<BookDamagedDetailsDetailsController> _logger;
        private readonly IMapper _mapper;
        public IBookDamagedDetailsRepository _BookDamagedDetailsRepository { get; set; }

        public BookDamagedDetailsDetailsController(ILogger<BookDamagedDetailsDetailsController> logger, IBookDamagedDetailsRepository BookDamagedDetailsRepository, IMapper mapper)
        {
            _logger = logger;
            _BookDamagedDetailsRepository = BookDamagedDetailsRepository;
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
            var blogList = await _BookDamagedDetailsRepository.Query();

            var blogResources = _mapper.Map<List<BookDamagedDetails>, IEnumerable<BookDamagedDetailsDto>>(blogList);

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
            var blogList = await _BookDamagedDetailsRepository.QueryById(id);

            var StaffResources = _mapper.Map<BookDamagedDetails, BookDamagedDetailsDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<BookDamagedDetailsDto> Add(BookDamagedDetails staff)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _BookDamagedDetailsRepository.Add(staff);
                    result = true;
                  msg = "添加成功";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookDamagedDetailsDto>()
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
        public async Task<MessageModel<BookDamagedDetailsDto>> UpdateAsync(BookDamagedDetails dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                     _BookDamagedDetailsRepository.Update(dto);
                    result = true;
                    msg = "修改成功";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookDamagedDetailsDto>()
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
        public async Task<MessageModel<BookDamagedDetailsDto>> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                      _BookDamagedDetailsRepository.DeleteById(id); 
                    result = true;
                     msg = "删除成功";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookDamagedDetailsDto>()
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
            var json = _BookDamagedDetailsRepository.Info(new BookDamagedDetails());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
    }
}