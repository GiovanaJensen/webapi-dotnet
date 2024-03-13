using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFirstWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){

        }

        public DbSet<Filme> Filmes {get; set;}
    }
}