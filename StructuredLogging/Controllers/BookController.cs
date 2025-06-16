using LoggingDemo.DTOs;
using LoggingDemo.Models;
using LoggingDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LoggingDemo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly ILogger<BooksController> _logger;
    private readonly IBookRepository _repository;

    public BooksController(ILogger<BooksController> logger, IBookRepository repository)
    {
        _logger = logger;
        _repository = repository;

        // Constructed log
        _logger.LogInformation("BooksController instance created at {Time}", DateTime.UtcNow);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _repository.GetAllAsync();
        _logger.LogInformation("Retrieved all books: {@books}",books);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        if (book == null)
        {
            _logger.LogWarning("Book with Id {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("retrived book is: {@Book}", book);
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] BookDTO bookDto)
    {
        var book = new Book
        {
            Title = bookDto.Title,
            Author = bookDto.Author,
            YearPublished = bookDto.YearPublished
        };
        await _repository.AddAsync(book);
        _logger.LogInformation("Added new book {@Book}", book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(int id, [FromBody] BookDTO bookDto)
    {
        var existingBook = await _repository.GetByIdAsync(id);
        if (existingBook == null) return NotFound();

        existingBook.Title = bookDto.Title;
        existingBook.Author = bookDto.Author;
        existingBook.YearPublished = bookDto.YearPublished;

        await _repository.UpdateAsync(existingBook);
        _logger.LogInformation("Updated book {@Book}", existingBook);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted) return NotFound();

        _logger.LogInformation("Deleted book with Id {Id}", id);
        return NoContent();
    }
}
