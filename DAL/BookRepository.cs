using System.Linq;
using NetCoreSwagger.DTO;
using NetCoreSwagger.Infrastructure;
using NetCoreSwagger.Models;

namespace NetCoreSwagger.DAL
{
    public class BookRepository : BookStoreBaseRepository<Book>, IBookRepository
    {
        private readonly BookStoreDbContext context;

        public BookRepository(BookStoreDbContext context) : base(context)
        {
            this.context = context;
        }

        public Book AddAuthorToBook(BookDto bookDto){
            Book book = new Book(){
                Id = bookDto.Id,
                Name = bookDto.Name,
                PageCount = bookDto.PageCount,
                Language = bookDto.Language,
                ISBN = bookDto.ISBN
            };
            if (bookDto.AuthorId != null)
                book.Author = context.Authors.FirstOrDefault(x => x.Id == bookDto.AuthorId);
            context.Add(book);
            context.SaveChanges();
            return book;
        }
    }
}