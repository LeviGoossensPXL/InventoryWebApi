using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController : ApiControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public UserController(ExampleDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _environment = environment;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_mapper.Map<IEnumerable<User>, IEnumerable<ResponseUserDTO>>(_context.Users.AsEnumerable()));
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ResponseUserDTO>(user));
        }

        // [HttpPost]
        // public IActionResult AddUser([FromBody] UserDTO userDTO)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     var user = _mapper.Map<User>(userDTO);
        //     _context.Users.Add(user);
        //     _context.SaveChanges();
        //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        // }

        // [HttpPut]
        // public IActionResult UpdateUser(Guid id, [FromBody] UserDTO userDTO)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return BadRequest(ModelState);
        //     }
        //     var user = _context.Users.FirstOrDefault(i => i.Id == id);
        //     if (user == null)
        //     {
        //         return NotFound();
        //     }
        //     _mapper.Map(userDTO, user);
        //     _context.SaveChanges();
        //     return Ok(user);
        // }

        [HttpDelete]
        public IActionResult DeleteUser(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _context.Users.FirstOrDefault(i => i.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok(new { id = id });
        }
    }
}
