using ESPDumpsterWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ESPDumpsterWebApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<ESPPostModel> ESPPostViewModel { get; set; }
    public DbSet<OrganisationModel> OrganisationViewModel { get; set; }
}