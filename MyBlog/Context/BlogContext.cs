﻿using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Context
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
    }
}
