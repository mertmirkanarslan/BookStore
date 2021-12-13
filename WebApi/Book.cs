using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //burada attribute olarak Id propunun auto incremented olarak identity oldu�unu belirtmi� olduk.
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}