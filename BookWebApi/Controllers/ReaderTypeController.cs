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
    public class ReaderTypeController : ControllerBase
    {
        private readonly ILogger<BookTypeController> _logger;
        private readonly IMapper _mapper;
        public IReaderTypeRepository _readTypeRepository { get; set; }

        public ReaderTypeController(ILogger<BookTypeController> logger, IReaderTypeRepository readTypeRepository, IMapper mapper)
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

            _readTypeRepository.Add(staff);
            return new MessageModel<ReaderTypeDto>()
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
        public MessageModel<ReaderTypeDto> Update(ReaderType dto)
        {
            _readTypeRepository.Update(dto);

            return new MessageModel<ReaderTypeDto>()
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
        public MessageModel<ReaderTypeDto> DeleteStaff(int id)
        {
            _readTypeRepository.DeleteById(id);

            return new MessageModel<ReaderTypeDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}