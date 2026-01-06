using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    public class GroupController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public GroupController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult GetGroups()
        {
            return Ok(_context.Groups);
        }

        [HttpGet("{id}")]
        public IActionResult GetGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var group = _context.Groups.FirstOrDefault(i => i.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);
        }

        [HttpPost]
        public IActionResult AddGroup([FromBody] GroupDTO groupDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var group = _mapper.Map<Group>(groupDTO);
            _context.Groups.Add(group);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGroup), new { id = group.Id }, group);
        }

        [HttpPut]
        public IActionResult UpdateGroup(int id, [FromBody] GroupDTO groupDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var group = _context.Groups.FirstOrDefault(i => i.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            _mapper.Map(groupDTO, group);
            _context.SaveChanges();
            return Ok(group);
        }

        [HttpDelete]
        public IActionResult DeleteGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var group = _context.Groups.FirstOrDefault(i => i.Id == id);
            if (group == null)
            {
                return NotFound();
            }
            _context.Groups.Remove(group);
            _context.SaveChanges();
            return Ok(new { id = id });
        }
    }
}
