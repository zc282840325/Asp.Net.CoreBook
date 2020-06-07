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
    public class BookModelController : ControllerBase
    {
        private readonly ILogger<BookModelController> _logger;
        private readonly IMapper _mapper;
        public IBookModelRepository _BookModellRepository { get; set; }

        public BookModelController(ILogger<BookModelController> logger, IBookModelRepository BookModelRepository, IMapper mapper)
        {
            _logger = logger;
            _BookModellRepository = BookModelRepository;
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
            var blogList = await _BookModellRepository.Query();

            var blogResources = _mapper.Map<List<BookModel>, IEnumerable<BookModelDto>>(blogList);

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
            var BookModel = await _BookModellRepository.QueryById(id);

            var StaffResources = _mapper.Map<BookModel, BookModelDto>(BookModel);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<BookModelDto> Add(BookModel staff)
        {

            _BookModellRepository.Add(staff);
            return new MessageModel<BookModelDto>()
            {
                msg = "添加成功",
                success = true
            };

        }

        /// <summary>
        ///  修改一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public MessageModel<BookModelDto> Update(BookModel dto)
        {
            _BookModellRepository.Update(dto);

            return new MessageModel<BookModelDto>()
            {
                msg = "修改成功",
                success = true
            };
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public MessageModel<BookModelDto> Delete(int id)
        {
            _BookModellRepository.DeleteById(id);

            return new MessageModel<BookModelDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}