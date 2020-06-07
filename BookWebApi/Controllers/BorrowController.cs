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
    public class BorrowController : ControllerBase
    {

        private readonly ILogger<BorrowController> _logger;
        private readonly IMapper _mapper;
        public IBorrowRepository _BorrowRepository { get; set; }

        public BorrowController(ILogger<BorrowController> logger, IBorrowRepository BorrowRepository, IMapper mapper)
        {
            _logger = logger;
            _BorrowRepository = BorrowRepository;
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
            var blogList = await _BorrowRepository.Query();

            var blogResources = _mapper.Map<List<Borrow>, IEnumerable<BorrowDto>>(blogList);

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
            var blogList = await _BorrowRepository.QueryById(id);

            var StaffResources = _mapper.Map<Borrow, BorrowDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<BorrowDto> Add(Borrow staff)
        {
            _BorrowRepository.Add(staff);
            return new MessageModel<BorrowDto>()
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
        public MessageModel<BorrowDto> Update(Borrow dto)
        {
            _BorrowRepository.Update(dto);

            return new MessageModel<BorrowDto>()
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
        public MessageModel<BorrowDto> Delete(int id)
        {
            _BorrowRepository.DeleteById(id);

            return new MessageModel<BorrowDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}