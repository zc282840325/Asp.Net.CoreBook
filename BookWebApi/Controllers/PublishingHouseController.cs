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
    public class PublishingHouseController : ControllerBase
    {
        private readonly ILogger<StaffController> _logger;
        private readonly IMapper _mapper;
        public IPublishingHouseRepository _publishingHouseRepository { get; set; }

        public PublishingHouseController(ILogger<StaffController> logger, IPublishingHouseRepository publishingHouseRepository, IMapper mapper)
        {
            _logger = logger;
            _publishingHouseRepository = publishingHouseRepository;
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
            var blogList = await _publishingHouseRepository.Query();

            var blogResources = _mapper.Map<List<PublishingHouse>, IEnumerable<PublishingHouseDto>>(blogList);

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
            var PublishingHouse = await _publishingHouseRepository.QueryById(id);

            var StaffResources = _mapper.Map<PublishingHouse, PublishingHouseDto>(PublishingHouse);

            return Ok(StaffResources);
        }
        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<PublishingHouseDto> Add(PublishingHouse staff)
        {
            _publishingHouseRepository.Add(staff);
            return new MessageModel<PublishingHouseDto>()
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
        public MessageModel<PublishingHouseDto> Update(PublishingHouse dto)
        {
            _publishingHouseRepository.Update(dto);

            return new MessageModel<PublishingHouseDto>()
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
        public MessageModel<PublishingHouseDto> Delete(int id)
        {
            _publishingHouseRepository.DeleteById(id);

            return new MessageModel<PublishingHouseDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
   
    }
}