using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Book.Comment;
using Book.Core.Entities;
using Book.Core.EntityFramWork.Resources;
using Microsoft.Extensions.Logging;
using Book.Core.IRepository;
using Microsoft.AspNetCore.Authorization;

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
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                   _BorrowRepository.Add(staff);
                    msg = "添加成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BorrowDto>()
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
        public async Task<MessageModel<BorrowDto>> UpdateAsync(Borrow dto)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                 _BorrowRepository.Update(dto);
                    msg = "修改成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BorrowDto>()
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
        public MessageModel<BorrowDto> DeleteAsync(int id)
        {
            bool result = false;
            string msg = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    _BorrowRepository.DeleteById(id);
                    msg = "删除成功";
                    result = true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }

            return new MessageModel<BorrowDto>()
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
            var json = _BorrowRepository.Info(new Borrow());

            return new MessageModel<string>()
            {
                msg = "获取成功",
                success = true,
                response = json
            };
        }
    }
}