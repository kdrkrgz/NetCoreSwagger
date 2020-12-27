using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreSwagger.Models
{
    public class Book: BaseEntity
    {
        public string Name { get; set; }

        public string PageCount { get; set; }

        public string Language { get; set; }

        public string ISBN { get; set; }

        public Author Author { get; set; }

    }
}