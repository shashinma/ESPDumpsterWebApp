using ESPDumpsterWebApp.Models;
using ESPDumpsterWebApp.Data;
using ESPDumpsterWebApp.Models;
using ESPDumpsterWebAppAPI.Models;

namespace POSTerminal.Services;

public interface IOrganisationService
{
    List<OrganisationModel> GetOrganisationItems();
}

public class OrganisationService : IOrganisationService
{
    private readonly ApplicationDbContext _context;

    public OrganisationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<OrganisationModel> GetOrganisationItems()
    {
        return _context.OrganisationViewModel.ToList();
    }
}