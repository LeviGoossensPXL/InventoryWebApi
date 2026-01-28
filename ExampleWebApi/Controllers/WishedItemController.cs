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
    [Authorize]
    public class WishedItemController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public WishedItemController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            this._context = context;
            this._mapper = mapper;
            this._environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetWishedItems()
        {
            var dtos = await _context.WishedItems
                .AsNoTracking()
                .Select(w => new WishedItemResponseDto
                {
                    Id = w.Id,
                    UserId = w.UserId,
                    Price = w.Price,
                    Priority = w.Priority,
                    GroupIds = w.GroupWishedItems.Select(g => g.GroupId).ToList()
                })
                .ToListAsync();

            return Ok(dtos);
        }

        // GET: api/WishedItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWishedItem(int id)
        {
            var dto = await _context.WishedItems
                .AsNoTracking()
                .Where(w => w.Id == id)
                .Select(w => new WishedItemResponseDto
                {
                    Id = w.Id,
                    UserId = w.UserId,
                    Price = w.Price,
                    Priority = w.Priority,
                    GroupIds = w.GroupWishedItems.Select(g => g.GroupId).ToList()
                })
                .FirstOrDefaultAsync();

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddWishedItem([FromBody] WishedItemDto wishedItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wishedItem = _mapper.Map<WishedItem>(wishedItemDto);
            _context.WishedItems.Add(wishedItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetWishedItem), new { id = wishedItem.Id }, wishedItem);
        }

        [HttpPut]
        public IActionResult UpdateWishedItem(int id, [FromBody] WishedItemDto wishedItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wishedItem = _context.WishedItems.FirstOrDefault(i => i.Id == id);
            if (wishedItem == null)
            {
                return NotFound();
            }
            _mapper.Map(wishedItemDto, wishedItem);
            _context.SaveChanges();
            return Ok(wishedItem);
        }

        [HttpDelete]
        public IActionResult DeleteWishedItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var wishedItem = _context.WishedItems.FirstOrDefault(i => i.Id == id);
            if (wishedItem == null)
            {
                return NotFound();
            }
            _context.WishedItems.Remove(wishedItem);
            _context.SaveChanges();
            return Ok(new { id = id });
        }
    }
}
