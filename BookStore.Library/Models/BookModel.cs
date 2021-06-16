using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Library.Models
{
    public class BookModel
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(1024)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(1024)")]
        public string Author { get; set; }

        public int PageCount { get; set; }
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        
        [Column(TypeName = "datetime2")]
        public DateTime PublishedDate { get; set; }
    }
}
