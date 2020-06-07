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
    public class LibraryController : ControllerBase
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly IMapper _mapper;
        public ILibraryRepository _libraryRepository { get; set; }

        public LibraryController(ILogger<LibraryController> logger, ILibraryRepository libraryRepository, IMapper mapper)
        {
            _logger = logger;
            _libraryRepository = libraryRepository;
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
            var blogList = await _libraryRepository.Query();

            var blogResources = _mapper.Map<List<Library>, IEnumerable<LibraryDto>>(blogList);

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
            var Library = await _libraryRepository.QueryById(id);

            var StaffResources = _mapper.Map<Library, LibraryDto>(Library);

            return Ok(StaffResources);
        }

        /// <summary>
        ///  添加一条数据
        /// </summary>
        /// <returns></returns>
        [Route("Add")]
        [HttpPost]
        public MessageModel<LibraryDto> Add(Library staff)
        {

            _libraryRepository.Add(staff);
            return new MessageModel<LibraryDto>()
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
        public MessageModel<LibraryDto> Update(Library dto)
        {
            _libraryRepository.Update(dto);

            return new MessageModel<LibraryDto>()
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
        public MessageModel<LibraryDto> Delete(int id)
        {
            _libraryRepository.DeleteById(id);

            return new MessageModel<LibraryDto>()
            {
                msg = "删除成功",
                success = true
            };
        }
    }
}