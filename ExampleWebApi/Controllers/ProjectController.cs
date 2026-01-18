using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ProjectController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _context.Projects
                .Select(p => new
                {
                    id = p.Id,
                    name = p.Name,
                    description = p.Description,
                    items = p.ProjectItems.Select(pi => new
                    {
                        itemId = pi.ItemId,
                        amount = pi.Amount

                    }),
                    groupIds = p.GroupProjects.Select(gp => gp.GroupId)
                })
                .ToListAsync();
            return Ok(projects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _context.Projects
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    id = p.Id,
                    name = p.Name,
                    description = p.Description,
                    items = p.ProjectItems.Select(pi => new
                    {
                        itemId = pi.ItemId,
                        amount = pi.Amount
                    }),
                    groupIds = p.GroupProjects.Select(gp => gp.GroupId)
                })
                .FirstOrDefaultAsync();

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var project = _mapper.Map<Project>(projectDto);
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpPost("{id:int}/addItems")]
        public async Task<IActionResult> AddItems(int id, [FromBody] AddItemsToProjectDto addItemsToProjectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound(new {message = "Project not found", projectId = id });
            }
            
            var selectedItems = await _context.Items.
                Where(i => addItemsToProjectDto.ItemIds.Contains(i.Id))
                .ToListAsync();
            if (selectedItems.Count() != addItemsToProjectDto.ItemIds.Count())
            {
                return NotFound(new {message = "One or more items not found"});
            }
            
            var existingItems = await _context.ProjectItems
                .Where(pi => pi.ProjectId == id && addItemsToProjectDto.ItemIds.Contains(pi.ItemId))
                .ToListAsync();
            if (existingItems.Any())
            {
                return BadRequest(new { message = "Items already exist on this project", itemIds = existingItems.Select(e => e.ItemId) });
            }
            
            var projectItems = selectedItems.Select(i => new ProjectItem { ProjectId = project.Id, ItemId = i.Id });
            await _context.ProjectItems.AddRangeAsync(projectItems);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            _mapper.Map(projectDto, project);
            
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects
                .Include(p => p.ProjectItems)
                .Include(p => p.GroupProjects)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
    }
}
