using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestInternSiliconStack.Data;
using TestInternSiliconStack.Models.Author;

namespace TestInternSiliconStack.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var response = await _context.Authors.Select(x => new AuthorViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Female = x.Female,
                    BornYear = x.Born,
                    DiedYear = x.Died,
                    Age = Author.getAge(x.Born, x.Died),
                }).ToListAsync();
                return Ok(response);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Message = "Internal server error",
                });
                throw;
            }
        }
    }
}
