using backlog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Infrastructure.BacklogContext
{
    public class BacklogContextSqlServer : DbContext
    {
        public DbSet<Epic> Epics { get; set; }

        public DbSet<Feature> Features { get; set; }

        public DbSet<Sprint> Sprints { get; set; }

        public DbSet<Job> Jobs { get; set; }


        public BacklogContextSqlServer(DbContextOptions<BacklogContextSqlServer> options) : base(options)
        {

        }
    }
}
