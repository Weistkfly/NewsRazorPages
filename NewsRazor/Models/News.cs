using System;
using System.Collections.Generic;

#nullable disable

namespace NewsRazor.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
    }
}
