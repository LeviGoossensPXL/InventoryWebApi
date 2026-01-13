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

        [HttpPost("addItems")]
        public IActionResult AddItemsToGroup([FromBody] AddItemsToGroupDTO addItemsToGroupDto)
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
            var selectedItems = _context.Items.Where(i => addItemsToGroupDto.ItemIds.Contains(i.Id));
            if (selectedItems.Count() != addItemsToGroupDto.ItemIds.Count())
            {
                return NotFound();
            }
            var groupItems = selectedItems.Select(i => new GroupItem { GroupId = selectedGroup.Id, ItemId = i.Id });
            _context.GroupItems.AddRangeAsync(groupItems);

            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("addProjects")]
        public IActionResult AddProjectsToGroup([FromBody] AddProjectsToGroupDTO addProjectsToGroupDto)
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
        public IActionResult AddUsersToGroup([FromBody] AddUsersToGroupDTO addUsersToGroupDto)
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
