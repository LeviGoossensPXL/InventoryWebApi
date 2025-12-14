using AutoMapper;
using ExampleWebApi.Domain.DTOs;
using ExampleWebApi.Domain.Entities;
using ExampleWebApi.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ItemController : ApiControllerBase
    {
        private readonly ExampleDbContext context;
        private readonly IMapper mapper;

        public ItemController(ExampleDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult List()
        {
            return Ok(context.Items);
        }

        [HttpGet("")]
        [AllowAnonymous]
        public IActionResult One()
        {
            return Ok(context.Items);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(ItemDTO itemDTO)
        {
            if (ModelState.IsValid)
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
            return Created();
        }

        [HttpPatch]
        [AllowAnonymous]
        public IActionResult Update(ItemDTO itemDTO)
        {
            if (ModelState.IsValid)
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
            return Created();
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                context.Items.Add(item);
                context.SaveChanges();
            }
            return Created();
        }
    }
}
