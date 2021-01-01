using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogVer2;

namespace BlogVer2.Data
{
    public class BlogVer2Context : DbContext
    {
        public BlogVer2Context (DbContextOptions<BlogVer2Context> options)
            : base(options)
        {
        }

        public DbSet<BlogVer2.Post> Post { get; set; }

        public DbSet<BlogVer2.Tag> Tag { get; set; }

        public DbSet<BlogVer2.User> User { get; set; }
    }
}
