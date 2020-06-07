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

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FineBillController : ControllerBase
    {
        private readonly ILogger<FineBillController> _logger;
        private readonly IMapper _mapper;
        public IFineBillRepository _FineBilllRepository { get; set; }

        public FineBillController(ILogger<FineBillController> logger, IFineBillRepository FineBilllRepository, IMapper mapper)
        {
            _logger = logger;
            _FineBilllRepository = FineBilllRepository;
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
            var blogList = await _FineBilllRepository.Query();

            var blogResources = _mapper.Map<List<FineBill>, IEnumerable<FineBillDto>>(blogList);

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
            var blogList = await _FineBilllRepository.QueryById(id);

            var StaffResources = _mapper.Map<FineBill, FineBillDto>(blogList);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<FineBillDto> Add(FineBill staff)
        {
            _FineBilllRepository.Add(staff);
            return new MessageModel<FineBillDto>()
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
        public MessageModel<FineBillDto> Update(FineBill dto)
        {
            _FineBilllRepository.Update(dto);

            return new MessageModel<FineBillDto>()
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
        public MessageModel<FineBillDto> Delete(int id)
        {
            _FineBilllRepository.DeleteById(id);

            return new MessageModel<FineBillDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}