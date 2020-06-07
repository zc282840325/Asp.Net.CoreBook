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
            _BookDamagedDetailsRepository.Add(staff);
            return new MessageModel<BookDamagedDetailsDto>()
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
        public MessageModel<BookDamagedDetailsDto> Update(BookDamagedDetails dto)
        {
            _BookDamagedDetailsRepository.Update(dto);

            return new MessageModel<BookDamagedDetailsDto>()
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
        public MessageModel<BookDamagedDetailsDto> Delete(int id)
        {
            _BookDamagedDetailsRepository.DeleteById(id);

            return new MessageModel<BookDamagedDetailsDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}