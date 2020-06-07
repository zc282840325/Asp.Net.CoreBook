using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class BookStorageDetailsController : ControllerBase
    {
        private readonly ILogger<BookStorageDetailsController> _logger;
        private readonly IMapper _mapper;
        public IBookStorageDetailsRepository _BookStorageDetailslRepository { get; set; }

        public BookStorageDetailsController(ILogger<BookStorageDetailsController> logger, IBookStorageDetailsRepository BookStorageDetailslRepository, IMapper mapper)
        {
            _logger = logger;
            _BookStorageDetailslRepository = BookStorageDetailslRepository;
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
            var blogList = await _BookStorageDetailslRepository.Query();

            var blogResources = _mapper.Map<List<BookStorageDetails>, IEnumerable<BookStorageDetailsDto>>(blogList);

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
            var blogList = await _BookStorageDetailslRepository.QueryById(id);

            var StaffResources = _mapper.Map<BookStorageDetails, BookStorageDetailsDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<BookStorageDetailsDto> Add(BookStorageDetails staff)
        {
            _BookStorageDetailslRepository.Add(staff);
            return new MessageModel<BookStorageDetailsDto>()
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
        public MessageModel<BookStorageDetailsDto> Update(BookStorageDetails dto)
        {
            _BookStorageDetailslRepository.Update(dto);

            return new MessageModel<BookStorageDetailsDto>()
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
        public MessageModel<BookStorageDetailsDto> Delete(int id)
        {
            _BookStorageDetailslRepository.DeleteById(id);

            return new MessageModel<BookStorageDetailsDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}