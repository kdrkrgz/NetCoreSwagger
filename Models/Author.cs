using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreSwagger.Models
{
    public class Author: BaseEntity
    {
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string Nationality { get; set; }

        public bool IsAlive { get; set; }
        
        public IEnumerable<Book> Books {get;set;}
    }
}