using NetCoreSwagger.Models;

namespace NetCoreSwagger.DTO
{
    public class BookDto: Book
    {
        public int? AuthorId { get; set; }
    }
}