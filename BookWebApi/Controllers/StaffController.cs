using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.Interfaces;
using BookEFSqt.Infrastructure.Resources;
using BookWebApi.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IMapper _mapper;
        public IStaffRepository _staffRepository { get; set; }

        public StaffController(ILogger<StaffController> logger, IStaffRepository staffRepository, IMapper mapper)
        {
            _logger = logger;
            _staffRepository = staffRepository;
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
            var blogList = await _staffRepository.Query();

            var blogResources = _mapper.Map<List<Staff>, IEnumerable<StaffDto>>(blogList);

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
            var Staff = await _staffRepository.QueryById(id);

            var StaffResources = _mapper.Map<Staff, StaffDto>(Staff);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<StaffDto> Add(Staff staff)
        {

            _staffRepository.Add(staff);
            return new MessageModel<StaffDto>()
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
        public MessageModel<StaffDto> Update(Staff dto)
        {
            _staffRepository.Update(dto);

            return new MessageModel<StaffDto>()
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
        public MessageModel<StaffDto> Delete(int id)
        {
           _staffRepository.DeleteById(id);

            return new MessageModel<StaffDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
 
    }
}