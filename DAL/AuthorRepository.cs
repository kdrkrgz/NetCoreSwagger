using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NetCoreSwagger.Infrastructure;
using NetCoreSwagger.Models;


namespace NetCoreSwagger.DAL
{
    public class AuthorRepository : BookStoreBaseRepository<Author>, IAuthorRepository
    {

        private readonly BookStoreDbContext context;

        public AuthorRepository(BookStoreDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Author> GetAuthorsWithBooks()
        {
            return context.Authors.Include(s => s.Books).ToList();
        }

        public Author GetAuthorWithBooks(int authorId){

            var author = context.Authors.Include(s => s.Books)
            .FirstOrDefault(x => x.Id == authorId);
            return author;
        }
        
    }
}