using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Resources;
using Microsoft.Extensions.Logging;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDamagedController : ControllerBase
    {
        private readonly ILogger<BookDamagedController> _logger;
        private readonly IMapper _mapper;
        public IBookDamagedRepository _BookDamagedRepository { get; set; }

        public BookDamagedController(ILogger<BookDamagedController> logger, IBookDamagedRepository BookDamagedRepository, IMapper mapper)
        {
            _logger = logger;
            _BookDamagedRepository = BookDamagedRepository;
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
            var blogList = await _BookDamagedRepository.Query();

            var blogResources = _mapper.Map<List<BookDamaged>, IEnumerable<BookDamagedDto>>(blogList);

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
            var blogList = await _BookDamagedRepository.QueryById(id);

            var StaffResources = _mapper.Map<BookDamaged, BookDamagedDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<BookDamagedDto> Add(BookDamaged staff)
        {
            _BookDamagedRepository.Add(staff);
            return new MessageModel<BookDamagedDto>()
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
        public MessageModel<BookDamagedDto> Update(BookDamaged dto)
        {
            _BookDamagedRepository.Update(dto);

            return new MessageModel<BookDamagedDto>()
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
        public MessageModel<BookDamagedDto> Delete(int id)
        {
            _BookDamagedRepository.DeleteById(id);

            return new MessageModel<BookDamagedDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}