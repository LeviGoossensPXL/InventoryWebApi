using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.DTOs.Responses;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoidItemController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public VoidItemController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            this._context = context;
            this._mapper = mapper;
            this._environment = environment;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.VoidItems
                .Include(item => item.ProjectItems)
                .ToList();
            
            var dtoList = items.Select(item => new ItemResponseDto
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Type = item.Type,
                Description = item.Description,
                ProjectItemIds = item.ProjectItems
                    .Select(pi => pi.ProjectId)
                    .ToList()
            }).ToList();
            
            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.VoidItems
                .Include(item => item.ProjectItems)
                .FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(new ItemResponseDto
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Type = item.Type,
                Description = item.Description,
                ProjectItemIds = item.ProjectItems.Select(pi => pi.ProjectId).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemDto itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _mapper.Map<VoidItem>(itemDTO);
            _context.VoidItems.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        [HttpPut]
        public IActionResult UpdateItem(int id, [FromBody] ItemDto itemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.VoidItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _mapper.Map(itemDTO, item);
            _context.SaveChanges();
            return Ok(item);
        }

        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.VoidItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.VoidItems.Remove(item);
            _context.SaveChanges();
            return Ok(new { id = id });
        }
    }
}
