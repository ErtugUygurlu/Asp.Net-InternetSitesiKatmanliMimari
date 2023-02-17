using DataEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<Author> author { get; set; }
        public DbSet<Article> article { get; set; }
    }
}
