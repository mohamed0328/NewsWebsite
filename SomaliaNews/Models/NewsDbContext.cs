using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SomaliaNews.Models
{
    public class NewsDbContext :DbContext
    {
        public NewsDbContext() : base("newsConnection")
        {

        }

        public DbSet<News> News { get; set; }

    }
}