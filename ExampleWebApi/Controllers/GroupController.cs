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

        [HttpPost("addItems")]
        public async Task<IActionResult> AddItemsToGroup([FromBody] AddItemsToGroupDto addItemsToGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedGroup = _context.Groups.FirstOrDefault(g => g.Id == addItemsToGroupDto.GroupId);
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

        [HttpPost("addProjects")]
        public IActionResult AddProjectsToGroup([FromBody] AddProjectsToGroupDto addProjectsToGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedGroup = _context.Groups.FirstOrDefault(g => g.Id == addProjectsToGroupDto.GroupId);
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

        [HttpPost("addUsers")]
        public IActionResult AddUsersToGroup([FromBody] AddUsersToGroupDto addUsersToGroupDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var selectedGroup = _context.Groups.FirstOrDefault(g => g.Id == addUsersToGroupDto.GroupId);
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
