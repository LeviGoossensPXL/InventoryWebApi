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
    public class OwnedItemController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public OwnedItemController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            this._context = context;
            this._mapper = mapper;
            this._environment = environment;
        }

        [HttpGet]
        public IActionResult GetOwnedItems()
        {
            var dtos = _context.OwnedItems
                .AsNoTracking()
                .Select(o => new OwnedItemResponseDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Brand = o.Brand,
                    Type = o.Type,
                    Description = o.Description,
                    OwnerId = o.OwnerId,
                    Price = o.Price,
                    ImageUrl = o.ImageUrl,
                    AcquiredAt = o.AcquiredAt,
                    Notes = o.Notes,
                    GroupIds = o.GroupOwnedItems.Select(g => g.GroupId).ToList()
                })
                .ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetOwnedItem(int id)
        {
            var dto = _context.OwnedItems
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new OwnedItemResponseDto
                {
                    Id = o.Id,
                    Name = o.Name,
                    Brand = o.Brand,
                    Type = o.Type,
                    Description = o.Description,
                    OwnerId = o.OwnerId,
                    
                    Price = o.Price,
                    ImageUrl = o.ImageUrl,
                    AcquiredAt = o.AcquiredAt,
                    Notes = o.Notes,
                    GroupIds = o.GroupOwnedItems.Select(g => g.GroupId).ToList()
                })
                .FirstOrDefault();

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddOwnedItem([FromBody] OwnedItemDto ownedItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownedItem = _mapper.Map<OwnedItem>(ownedItemDto);
            _context.OwnedItems.Add(ownedItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOwnedItem), new { id = ownedItem.Id }, ownedItem);
        }

        [HttpPut]
        public IActionResult UpdateOwnedItem(int id, [FromBody] OwnedItemDto ownedItemDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownedItem = _context.OwnedItems.FirstOrDefault(i => i.Id == id);
            if (ownedItem == null)
            {
                return NotFound();
            }
            _mapper.Map(ownedItemDto, ownedItem);
            _context.SaveChanges();
            return Ok(ownedItem);
        }

        [HttpDelete]
        public IActionResult DeleteOwnedItem(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ownedItem = _context.OwnedItems.FirstOrDefault(i => i.Id == id);
            if (ownedItem == null)
            {
                return NotFound();
            }
            _context.OwnedItems.Remove(ownedItem);
            _context.SaveChanges();
            return Ok(new { id = id });
        }

        [HttpPost("{id:int}/image")]
        public async Task<IActionResult> UploadImage(int id, IFormFile image) // TODO use minio for a bucket
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("Image is required.");
            }
            var ownedItem = _context.OwnedItems.FirstOrDefault(i => i.Id == id);
            if (ownedItem == null)
            {
                throw new KeyNotFoundException($"OwnedItem with id {id} does not exist.");
            }
            using (MemoryStream ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                byte[] bytes = ms.ToArray();

                string ext = Path.GetExtension(image.FileName);

                // 1. Bestandsnaam genereren
                string fileName = $"{Guid.NewGuid()}.{ext.TrimStart('.')}";

                string imagesFolder = Path.Combine(_environment.WebRootPath, "images", "owned_items");
                // Zorg dat de folder bestaat
                Directory.CreateDirectory(imagesFolder);

                string filePath = Path.Combine(imagesFolder, fileName);

                // 2. File opslaan
                await System.IO.File.WriteAllBytesAsync(filePath, bytes);

                // 3. URL opslaan in database (voor de client)
                ownedItem.ImageUrl = $"{Request.Scheme}://{Request.Host}/images/owned_items/{fileName}";
                await _context.SaveChangesAsync();

                return Ok(ownedItem.ImageUrl);
            }
        }
    }
}
