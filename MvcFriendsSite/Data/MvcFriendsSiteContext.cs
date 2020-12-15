using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFriendsSite.Models;

namespace MvcFriendsSite.Data
{
    public class MvcFriendsSiteContext : DbContext
    {
        public MvcFriendsSiteContext (DbContextOptions<MvcFriendsSiteContext> options)
            : base(options)
        {
        }


        public DbSet<MvcFriendsSite.Models.BlogPost> Blogs { get; set; }
    }
}
