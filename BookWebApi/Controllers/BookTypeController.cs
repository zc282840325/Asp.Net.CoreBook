using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookTypeController : ControllerBase
    {
        private readonly ILogger<BookTypeController> _logger;
        private readonly IMapper _mapper;
        public IBookTypeRepository _bookTypeRepository { get; set; }

        public BookTypeController(ILogger<BookTypeController> logger, IBookTypeRepository bookTypeRepository, IMapper mapper)
        {
            _logger = logger;
            _bookTypeRepository = bookTypeRepository;
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
            var blogList = await _bookTypeRepository.Query();

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
            var BookType = await _bookTypeRepository.QueryById(id);

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

            _bookTypeRepository.Add(staff);
            return new MessageModel<BookTypeDto>()
            {
                msg = "获取成功",
                success = true
            };

        }

        /// <summary>
        ///  修改一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public MessageModel<BookTypeDto> Update(BookType dto)
        {
            _bookTypeRepository.Update(dto);

            return new MessageModel<BookTypeDto>()
            {
                msg = "修改成功",
                success = true
            };
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <returns></returns>
        [Route("DeleteStaff")]
        [HttpDelete]
        public MessageModel<BookTypeDto> DeleteStaff(int id)
        {
            _bookTypeRepository.DeleteById(id);

            return new MessageModel<BookTypeDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}