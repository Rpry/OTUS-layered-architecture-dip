using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogic.Abstractions;
using BusinessLogic.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController: ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<CourseController> _logger;

        public CourseController(
            ICourseService service,
            ILogger<CourseController> logger,
            IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(_mapper.Map<CourseModel>(await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CourseModel courseModel)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CourseModel, CourseDto>(courseModel)));
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, CourseModel courseModel)
        {
            await _service.UpdateAsync(id, _mapper.Map<CourseDto>(courseModel));
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
        
        [HttpPost("list")]
        public async Task<IActionResult> GetListAsync(CourseFilterModel filterModel)
        {
            return Ok(_mapper.Map<List<CourseModel>>(await _service.GetPagedAsync(filterModel.Page, filterModel.ItemsPerPage)));
        }
    }
}