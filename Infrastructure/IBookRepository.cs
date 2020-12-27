using NetCoreSwagger.DTO;
using NetCoreSwagger.Models;

namespace NetCoreSwagger.Infrastructure
{
    public interface IBookRepository: IBookStoreBaseRepository<Book>
    {
         Book AddAuthorToBook(BookDto bookDto);
    }
}