using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.EntityFramWork.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Book.Core.IRepository;
using Microsoft.AspNetCore.Authorization;

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
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                  _BookStorageDetailslRepository.Add(staff);
                    msg = "添加成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookStorageDetailsDto>()
            {
                msg = msg,
                success = result
            };
        }

        /// <summary>
        ///  修改一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Update")]
        [HttpPost]
        public MessageModel<BookStorageDetailsDto> UpdateAsync(BookStorageDetails dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _BookStorageDetailslRepository.Update(dto);
                    msg = "修改成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookStorageDetailsDto>()
            {
                msg = msg,
                success = result

            };
        }
        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public MessageModel<BookStorageDetailsDto> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                   _BookStorageDetailslRepository.DeleteById(id);
                    msg = "删除成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BookStorageDetailsDto>()
            {
                msg = msg,
                success = result

            };
        }
        /// <summary>
        ///  获取中英文对应字段
        /// </summary>
        /// <returns></returns>
        [Route("Info")]
        [HttpGet]
        [AllowAnonymous]
        public MessageModel<string> Info()
        {
            var json = _BookStorageDetailslRepository.Info(new BookStorageDetails());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
    }
}