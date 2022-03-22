using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewsRazor.Data;
using NewsRazor.Models;

namespace NewsRazor.Pages
{
    public class NewsModel : PageModel
    {
        private readonly NewsAppContext _db;

        public List<News> News;
        private INewsApp NewsApp { get; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public NewsModel(INewsApp newsApp, NewsAppContext db)
        {
            NewsApp = newsApp;
            _db = db;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var news = await NewsApp.GetNews();
            if (!string.IsNullOrEmpty(SearchString))
            {
                news = news.Where(s => s.Title.Contains(SearchString));
            }
            news = news.OrderByDescending(x => x.Date);
            News = news.ToList();
            foreach (var item in News)
            {
                item.Author = _db.Authors.FirstOrDefault(u => u.Id == item.AuthorId);
                item.Category = _db.Categories.FirstOrDefault(u => u.Id == item.CategoryId);
            }
            return Page();
        }
    }
}
