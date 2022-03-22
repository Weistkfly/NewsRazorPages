using NewsRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsRazor.Data
{
    public interface INewsApp
    {
        Task<IEnumerable<News>> GetNews();
    }
}
