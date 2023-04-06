using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestInternSiliconStack.Data;
using TestInternSiliconStack.Models.Author;
using TestInternSiliconStack.Models.Book;

namespace TestInternSiliconStack.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks(int? authorId, byte? rating, int? publishYear)
        {
            try
            {

                var response = _context.Books.Include(x => x.Author).AsQueryable();
                if (authorId.HasValue)
                {
                    response = response.Where(x => x.AuthorId == authorId);
                }
                if (rating.HasValue)
                {
                    response = response.Where(x => x.Rating == rating);
                }
                if (publishYear.HasValue)
                {
                    response = response.Where(x => x.PublishYear == publishYear);
                }
                return Ok(response.Select(x => new BookViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Topic = x.Topic,
                    AuthorName = x.Author.Name,
                    PublishYear = x.PublishYear,
                    Price = x.Price,
                    Rating = x.Rating,

                }).ToList());

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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBook(int id)
        {
            try
            {
                var checkBook = _context.Books!.Include(x => x.Author).SingleOrDefault(b => b.Id == id);
                if (checkBook == null)
                {
                    return NotFound(new
                    {

                    });
                }

                var response = new DetailBookViewModel
                {
                    Id = checkBook.Id,
                    Title = checkBook.Title,
                    Price = checkBook.Price,
                    Rating = checkBook.Rating,
                    Topic = checkBook.Topic,
                    PublishYear = checkBook.PublishYear,
                    Author = new AuthorViewModel
                    {
                        Id = checkBook.Author.Id,
                        Name = checkBook.Author.Name,
                        Female = checkBook.Author.Female,
                        BornYear = checkBook.Author.Born,
                        DiedYear = checkBook.Author.Died,
                        Age = Author.getAge(checkBook.Author.Born, checkBook.Author.Died),
                    }
                };
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
        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookModel model)
        {
            try
            {
                var checkAuthor = _context.Authors!.SingleOrDefault(b => b.Id == model.AuthorId);
                if (checkAuthor == null)
                {
                    return BadRequest(new
                    {
                        Message = "Author is not found"
                    });

                }
                var checkBookName = _context.Books!.SingleOrDefault(b => b.Title == model.Title);
                if (checkBookName != null)
                {
                    return BadRequest(new
                    {
                        Message = "There are already other items in the database with the same name"
                    });
                }
                Book book = new Book();
                book.AuthorId = model.AuthorId;
                book.PublishYear = model.PublishYear;
                book.Price = model.Price;
                book.Title = model.Title;
                book.Topic = model.Topic;
                book.Rating = model.Rating;
                _context.Books.Add(book);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, new { });
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(UpdateBookModel model, int id)
        {
            try
            {
                var checkAuthor = _context.Authors!.SingleOrDefault(b => b.Id == model.AuthorId);
                if (checkAuthor == null)
                {
                    return BadRequest(new
                    {
                        Message = "Author is not found"
                    });

                }
                var checkBookName = _context.Books!.SingleOrDefault(b => b.Title == model.Title);
                if (checkBookName != null)
                {
                    return BadRequest(new
                    {
                        Message = "There are already other items in the database with the same name"
                    });
                }
                var checkBookExist = _context.Books!.Include(x => x.Author).SingleOrDefault(b => b.Id == id);
                if (checkBookExist == null)
                {
                    return NotFound(new
                    {
                        Message = "Book is not Found"
                    });
                }
                checkBookExist.AuthorId = model.AuthorId;
                checkBookExist.PublishYear = model.PublishYear;
                checkBookExist.Price = model.Price;
                checkBookExist.Title = model.Title;
                checkBookExist.Topic = model.Topic;
                checkBookExist.Rating = model.Rating;
                _context.Books.Update(checkBookExist);
                _context.SaveChanges();
                var response = new DetailBookViewModel
                {
                    Id = checkBookExist.Id,
                    Title = checkBookExist.Title,
                    Price = checkBookExist.Price,
                    Rating = checkBookExist.Rating,
                    Topic = checkBookExist.Topic,
                    PublishYear = checkBookExist.PublishYear,
                    Author = new AuthorViewModel
                    {
                        Id = checkBookExist.Author.Id,
                        Name = checkBookExist.Author.Name,
                        Female = checkBookExist.Author.Female,
                        BornYear = checkBookExist.Author.Born,
                        DiedYear = checkBookExist.Author.Died,
                        Age = Author.getAge(checkBookExist.Author.Born, checkBookExist.Author.Died),
                    }
                };
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var checkBookExist = _context.Books!.Include(x => x.Author).SingleOrDefault(b => b.Id == id);
                if (checkBookExist == null)
                {
                    return NotFound(new
                    {
                        Message = "Book is not Found"
                    });
                }

                _context.Books.Remove(checkBookExist);
                _context.SaveChanges();
                return Ok(new { });
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
