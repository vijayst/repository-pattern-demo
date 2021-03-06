﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternDemo.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(string connStr) : base(connStr) { }

        public virtual DbSet<Client> Clients { get; set; }
    }
}
