using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;

namespace DockerLearning.Models
{
    public class DbContextModel : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=mysqlcontainer;database=;user=root;password=123456", new MySqlServerVersion(new Version()));
        }
    }
}