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
            var groups = _context.Groups
                .Include(g => g.GroupOwnedItems)
                .Include(g => g.GroupWishedItems)
                .Include(g => g.GroupProjects)
                .Include(g => g.GroupUsers)
                .ToList();

            var dtoList = groups.Select(g => new GroupResponseDto
            {
                Id = g.Id,
                Name = g.Name,
                Description = g.Description,
                OwnedItemIds = g.GroupOwnedItems.Select(goi => goi.OwnedItemId).ToList(),
                WishedItemIds = g.GroupWishedItems.Select(gwi => gwi.WishedItemId).ToList(),
                ProjectIds = g.GroupProjects.Select(gp => gp.ProjectId).ToList(),
                UserIds = g.GroupUsers.Select(gu => gu.UserId).ToList()
            }).ToList();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetGroup(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = _context.Groups
                .Include(g => g.GroupOwnedItems)
                .Include(g => g.GroupWishedItems)
                .Include(g => g.GroupProjects)
                .Include(g => g.GroupUsers)
                .FirstOrDefault(g => g.Id == id);

            if (group == null)
            {
                return NotFound();
            }

            var dto = new GroupResponseDto
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                OwnedItemIds = group.GroupOwnedItems.Select(goi => goi.OwnedItemId).ToList(),
                WishedItemIds = group.GroupWishedItems.Select(gwi => gwi.WishedItemId).ToList(),
                ProjectIds = group.GroupProjects.Select(gp => gp.ProjectId).ToList(),
                UserIds = group.GroupUsers.Select(gu => gu.UserId).ToList()
            };

            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddGroup([FromBody] GroupDto groupDTO)
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

        [HttpPost("{id:int}/addItems")]
        public async Task<IActionResult> AddItemsToGroup(int id, [FromBody] AddItemsToGroupDto addItemsToGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedGroup = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (selectedGroup == null)
            {
                return NotFound();
            }

            var selectedOwnedItems = _context.OwnedItems.Where(oi => addItemsToGroupDto.OwnedItemIds.Contains(oi.Id));
            if (selectedOwnedItems.Count() != addItemsToGroupDto.OwnedItemIds.Count())
            {
                return NotFound();
            }
            var groupOwnedItems = selectedOwnedItems.Select(oi => new GroupOwnedItem { GroupId = selectedGroup.Id, OwnedItemId = oi.Id });
            await _context.GroupOwnedItems.AddRangeAsync(groupOwnedItems);

            var selectedWishedItems = _context.WishedItems.Where(i => addItemsToGroupDto.WishedItemIds.Contains(i.Id));
            if (selectedWishedItems.Count() != addItemsToGroupDto.WishedItemIds.Count())
            {
                return NotFound();
            }
            var groupWishedItems = selectedWishedItems.Select(i => new GroupWishedItem { GroupId = selectedGroup.Id, WishedItemId = i.Id });
            await _context.GroupWishedItems.AddRangeAsync(groupWishedItems);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("{id:int}/addProjects")]
        public IActionResult AddProjectsToGroup(int id, [FromBody] AddProjectsToGroupDto addProjectsToGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedGroup = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (selectedGroup == null)
            {
                return NotFound();
            }
            var selectedProjects = _context.Projects.Where(i => addProjectsToGroupDto.ProjectIds.Contains(i.Id));
            if (selectedProjects.Count() != addProjectsToGroupDto.ProjectIds.Count())
            {
                return NotFound();
            }
            var groupProjects = selectedProjects.Select(i => new GroupProject { GroupId = selectedGroup.Id, ProjectId = i.Id });
            _context.GroupProjects.AddRangeAsync(groupProjects);

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("{id:int}/addUsers")]
        public IActionResult AddUsersToGroup(int id, [FromBody] AddUsersToGroupDto addUsersToGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedGroup = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (selectedGroup == null)
            {
                return NotFound();
            }
            var selectedUsers = _context.Users.Where(i => addUsersToGroupDto.UserIds.Contains(i.Id));
            if (selectedUsers.Count() != addUsersToGroupDto.UserIds.Count())
            {
                return NotFound();
            }
            var groupUsers = selectedUsers.Select(i => new GroupUser { GroupId = selectedGroup.Id, UserId = i.Id });
            _context.GroupUsers.AddRangeAsync(groupUsers);

            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGroup(int id, [FromBody] GroupDto groupDTO)
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
