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
    public class BookStorageController : ControllerBase
    {
            private readonly ILogger<BookStorageController> _logger;
            private readonly IMapper _mapper;
            public IBookStorageRepository _BookStoragelRepository { get; set; }

            public BookStorageController(ILogger<BookStorageController> logger, IBookStorageRepository BookStoragelRepository, IMapper mapper)
            {
                _logger = logger;
                _BookStoragelRepository = BookStoragelRepository;
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
                var blogList = await _BookStoragelRepository.Query();

                var blogResources = _mapper.Map<List<BookStorage>, IEnumerable<BookStorageDto>>(blogList);

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
                var blogList = await _BookStoragelRepository.QueryById(id);

                var StaffResources = _mapper.Map<BookStorage, BookStorageDto>(blogList);

                return Ok(StaffResources);
            }

            /// <summary>
            ///  添加一条数据
            /// </summary>
            /// <returns></returns>
            [Route("Add")]
            [HttpPost]
            public MessageModel<BookStorageDto> Add(BookStorage staff)
            {
                _BookStoragelRepository.Add(staff);
                return new MessageModel<BookStorageDto>()
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
            public MessageModel<BookStorageDto> Update(BookStorage dto)
            {
                _BookStoragelRepository.Update(dto);

                return new MessageModel<BookStorageDto>()
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
            public MessageModel<BookStorageDto> Delete(int id)
            {
                _BookStoragelRepository.DeleteById(id);

                return new MessageModel<BookStorageDto>()
                {
                    msg = "删除成功",
                    success = true
                };
            }
        }
}