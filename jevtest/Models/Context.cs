﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jevtest.Models
{
    public class Context:DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=MSI; database=jevo; integrated security=true") ;
        }

        public DbSet<Users> MyUsers { get; set; }
    }
}
