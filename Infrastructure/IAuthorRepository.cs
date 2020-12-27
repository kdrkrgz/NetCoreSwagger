using NetCoreSwagger.Models;
using System.Collections.Generic;

namespace NetCoreSwagger.Infrastructure
{
    public interface IAuthorRepository: IBookStoreBaseRepository<Author>
    {
         IEnumerable<Author> GetAuthorsWithBooks();
    }
}