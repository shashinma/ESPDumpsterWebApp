using ESPDumpsterWebAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ESPDumpsterWebAppAPI.Data;

public class ESPPostContext : DbContext
{
    public ESPPostContext(DbContextOptions<ESPPostContext> options)
        : base(options)
    { 
        Database.EnsureCreated();
    }
    
    public DbSet<ESPPostAPIModel> EspPostViewModel { get; set; }
}
