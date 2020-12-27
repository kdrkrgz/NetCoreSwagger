using Microsoft.AspNetCore.Mvc;
using NetCoreSwagger.Models;
using NetCoreSwagger.DAL;
using NetCoreSwagger.Infrastructure;

namespace NetCoreSwagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository repository;
        public AuthorsController(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.GetAuthorsWithBooks());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Author author = repository.Get(id);
            if(author is null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post(Author authorDto)
        {
            Author author = authorDto;
            if(author is null) return BadRequest("Author object is null");
            if (!ModelState.IsValid) return BadRequest("Model is not valid");
            repository.Add(author);
            return CreatedAtAction(nameof(Post), new { id = author.Id }, author);
            // return Ok(authorDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Author authorDto)
        {
            Author author = repository.Get(id);
            if (author is null)
            {
                repository.Add(authorDto);
                // return Ok(authorDto);
                //return CreatedAtAction(nameof(Put), new { id = authorDto.Id }, authorDto);
                return CreatedAtRoute("Post", new {id = authorDto.Id}, authorDto);
            }

            repository.Update(authorDto);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {

            return NoContent();
        }
    }
}