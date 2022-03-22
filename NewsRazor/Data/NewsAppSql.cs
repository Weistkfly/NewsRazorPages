using Microsoft.EntityFrameworkCore;
using NewsRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsRazor.Data
{
    public class NewsAppSql : INewsApp
    {
        private NewsAppContext NewsAppContext { get; }
        public NewsAppSql(NewsAppContext newsAppContext)
        {
            NewsAppContext = newsAppContext;
        }
        public async Task<IEnumerable<News>> GetNews()
        {
           return await NewsAppContext.News.ToListAsync();
        }
    }
}
