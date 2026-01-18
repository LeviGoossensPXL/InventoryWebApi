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
    public class ItemController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ItemController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            this._context = context;
            this._mapper = mapper;
            this._environment = environment;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.Items
                .Include(item => item.OwnedItems)
                .Include(item => item.WishedItems)
                .Include(item => item.ProjectItems)
                .ToList();
            
            var dtoList = items.Select(item => new ItemResponseDto
            {
                Id = item.Id,
                Name = item.Name,
                Brand = item.Brand,
                Type = item.Type,
                Description = item.Description,
                OwnedItemIds = item.OwnedItems
                    .Select(oi => oi.Id)
                    .ToList(),
                WishedItemIds = item.WishedItems
                    .Select(wi => wi.Id)
                    .ToList(),
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
            var item = _context.Items
                .Include(item => item.OwnedItems)
                .Include(item => item.WishedItems)
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
                OwnedItemIds = item.OwnedItems.Select(oi => oi.Id).ToList(),
                WishedItemIds = item.WishedItems.Select(wi => wi.Id).ToList(),
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
            var item = _mapper.Map<Item>(itemDTO);
            _context.Items.Add(item);
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
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
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
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
            return Ok(new { id = id });
        }
    }
}
