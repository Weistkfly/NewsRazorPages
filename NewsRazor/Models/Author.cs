using System;
using System.Collections.Generic;

#nullable disable

namespace NewsRazor.Models
{
    public partial class Author
    {
        public Author()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
