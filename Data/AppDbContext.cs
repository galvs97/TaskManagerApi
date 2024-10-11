using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Data.Models;

namespace TaskManagerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TbTask> tbTask { get; set; }
    }
}