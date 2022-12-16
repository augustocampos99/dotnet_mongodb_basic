using BasicMogodb.Entities;
using BasicMogodb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicMogodb.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService = new BookService();

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            var result = await _bookService.Create(book);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAll(5);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            var result = await _bookService.GetOne(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Book book, string id)
        {
            var result = await _bookService.Update(book, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await _bookService.Remove(id);
            return Ok(result);
        }

    }
}
