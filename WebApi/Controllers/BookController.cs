using BookStore.Library.Models;
using BookStore.Library.Services.CommandServices;
using BookStore.Library.Services.QueryServices;
using BookStore.WebApi.ApiRequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookModelQueryService _bookQueryService;
        private readonly IBookModelCommandService _bookCommandService;

        public BookController(IBookModelQueryService bookQueryService, IBookModelCommandService bookCommandService)
        {
            _bookQueryService = bookQueryService;
            _bookCommandService = bookCommandService;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var output = await _bookQueryService.GetAsync();
            return Ok(output);
        }

        // GET: api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var output = await _bookQueryService.GetAsync(id);
            return output is not null ? Ok(output) : NotFound();
        }

        // POST: api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookApiRequestModel value)
        {
            Guid guid = new();

            BookModel book = new()
            {
                Id = guid,
                Title = value.Title,
                Author = value.Author,
                PageCount = value.PageCount,
                Price = value.Price,
                PublishedDate = value.PublishedDate
            };

            var output = await _bookCommandService.CreateAsync(book);

            return Ok(output);
        }
    }
}
