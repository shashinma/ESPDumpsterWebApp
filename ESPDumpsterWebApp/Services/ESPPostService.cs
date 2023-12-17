using ESPDumpsterWebApp.Models;
using ESPDumpsterWebApp.Data;
using ESPDumpsterWebApp.Models;
using ESPDumpsterWebAppAPI.Models;

namespace POSTerminal.Services;

public interface IESPPostService
{
    List<ESPPostModel> GetPostItems();
}

public class ESPPostService : IESPPostService
{
    private readonly ApplicationDbContext _context;

    public ESPPostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<ESPPostModel> GetPostItems()
    {
        return _context.ESPPostViewModel.ToList();
    }
}