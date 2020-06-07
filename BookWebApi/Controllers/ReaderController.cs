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
    public class ReaderController : ControllerBase
    {
        private readonly ILogger<ReaderController> _logger;
        private readonly IMapper _mapper;
        public IReaderRepository _readerRepository { get; set; }

        public ReaderController(ILogger<ReaderController> logger, IReaderRepository readerRepository, IMapper mapper)
        {
            _logger = logger;
            _readerRepository = readerRepository;
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
            var blogList = await _readerRepository.Query();

            var blogResources = _mapper.Map<List<Reader>, IEnumerable<ReaderDto>>(blogList);

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
            var Reader = await _readerRepository.QueryById(id);

            var StaffResources = _mapper.Map<Reader, ReaderDto>(Reader);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<ReaderDto> Add(Reader staff)
        {

            _readerRepository.Add(staff);
            return new MessageModel<ReaderDto>()
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
        public MessageModel<ReaderDto> Update(Reader dto)
        {
            _readerRepository.Update(dto);

            return new MessageModel<ReaderDto>()
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
        public MessageModel<ReaderDto> Delete(int id)
        {
            _readerRepository.DeleteById(id);

            return new MessageModel<ReaderDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}