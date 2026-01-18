using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult GetWishedItems()
        {
            return Ok(_context.WishedItems);
        }

        [HttpGet("{id}")]
        public IActionResult GetWishedItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.WishedItems.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
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
