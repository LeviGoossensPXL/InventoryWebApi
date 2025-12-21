using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
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
            return Ok(new { items = _context.Items });
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
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
            return Ok(new { item = item });
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemDTO itemDTO)
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
        public IActionResult UpdateItem(int id, [FromBody] ItemDTO itemDTO)
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
            return Ok(new { item = item });
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

        [HttpPost("{id:int}/image")]
        public async Task<IActionResult> UploadImage(int id, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("Image is required.");
            }
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException($"item with id {id} does not exist.");
            }
            using (MemoryStream ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                byte[] bytes = ms.ToArray();

                string ext = Path.GetExtension(image.FileName);

                // 1. Bestandsnaam genereren
                string fileName = $"{Guid.NewGuid()}.{ext.TrimStart('.')}";

                string imagesFolder = Path.Combine(_environment.WebRootPath, "images", "items");
                // Zorg dat de folder bestaat
                Directory.CreateDirectory(imagesFolder);

                string filePath = Path.Combine(imagesFolder, fileName);

                // 2. File opslaan
                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                // 3. URL opslaan in database (voor de client)
                item.Image = $"{Request.Scheme}://{Request.Host}/images/items/{fileName}";
                _context.SaveChanges();

                return Ok(item.Image);
            }
        }
    }
}
