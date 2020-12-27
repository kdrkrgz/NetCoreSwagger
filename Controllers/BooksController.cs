using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCoreSwagger.DAL;
using NetCoreSwagger.DTO;
using NetCoreSwagger.Infrastructure;
using NetCoreSwagger.Models;

namespace NetCoreSwagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController: ControllerBase
    {
        private readonly IBookRepository repository;
        public BooksController(IBookRepository repository)
        {
            this.repository = repository;
        }

            [HttpGet]
            public IActionResult Get(){
                return Ok(repository.GetAll());
            }

            [HttpGet("{id}")]
            public IActionResult Get(int id){
                Book book = repository.Get(id);
                if (book is null) return NotFound();
                return Ok(book);
            }

            [HttpPost]
            public IActionResult Post(BookDto bookDto){
  
                    if(bookDto is null) return BadRequest("Book object is null");
                    if(!ModelState.IsValid) return BadRequest("Model is not valid");

                    Book book = repository.AddAuthorToBook(bookDto);
                    return CreatedAtAction(nameof(Post), new {id = book.Id}, book);
                    // return Ok(book);
            }

            [HttpPut("{id}")]
            public IActionResult Put(int id, Book bookDto)
            {
                Book book = repository.Get(id);

                if(book is null){
                    repository.Add(bookDto);
                    // return Ok(bookDto);
                    return CreatedAtRoute("Post", new {id = bookDto.Id}, bookDto);
                }

                repository.Update(bookDto);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult Delete(int id){
                var book = repository.Get(id);
                if (book is null) return NotFound();
                repository.Delete(id);
                return NoContent();
            }
    }
}