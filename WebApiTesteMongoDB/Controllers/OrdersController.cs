using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ECommerce;
using Services;

namespace WebApiTesteMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService _booksService;

        public OrdersController(OrdersService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<Order>> Get() =>
            await _booksService.GetAsync();


        [HttpGet("GetFiltroProduto")]
        public async Task<List<Order>> GetFilroProduto() =>
            await _booksService.GetFiltroAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> Get(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }


        [HttpPost]
        public async Task<IActionResult> Post(Order newBook)
        {
            await _booksService.CreateAsync(newBook);

            return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Order updatedBook)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedBook.Id = book.Id;

            await _booksService.UpdateAsync(id, updatedBook);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _booksService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _booksService.RemoveAsync(id);

            return NoContent();
        }
    }
}
