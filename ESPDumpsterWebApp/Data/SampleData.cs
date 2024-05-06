using ESPDumpsterWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ESPDumpsterWebApp.Data;

public class SampleData
{
    private static IConfiguration _configuration;

    public SampleData(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public static async Task CreateDefaultOrgs(IServiceProvider serviceProvider)
    {
        var _context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        if (!_context.OrganisationViewModel.Any())
        {
            _context.OrganisationViewModel.AddRange(
                new OrganisationModel()
                {
                    Name = "IntelligentCity Lab",
                    OrgsTag = "ICL"
                },
                new OrganisationModel()
                {
                    Name = "ФГБОУ ВО СПбГАУ",
                    OrgsTag = "SPBGAU"
                },
                new OrganisationModel()
                {
                    Name = "НИУ ИТМО",
                    OrgsTag = "ITMO"
                },
                new OrganisationModel()
                {
                    Name = "СПбГУТ",
                    OrgsTag = "SUT"
                }
            );

            await _context.SaveChangesAsync();
        }
    }

    public static async Task CreateDefaultData(IServiceProvider serviceProvider)
    {
        var _context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        if (!_context.ESPPostViewModel.Any())
        {
            _context.ESPPostViewModel.AddRange(
                new ESPPostModel() // ESP-01
                {
                    ESPName = "ESP-01",
                    Level = 30,
                    LevelString = SetLevelString(30),
                    LevelStringColor = SetLevelStringColor(30),
                    OrgsTag = "ICL",
                    TimeStamp = DateTime.Now
                },
                new ESPPostModel() // ESP-02
                {
                    ESPName = "ESP-02",
                    Level = 90,
                    LevelString = SetLevelString(90),
                    LevelStringColor = SetLevelStringColor(90),
                    OrgsTag = "SPBGAU",
                    TimeStamp = DateTime.Now
                },
                new ESPPostModel() // ESP-03
                {
                    ESPName = "ESP-03",
                    Level = 40,
                    LevelString = SetLevelString(40),
                    LevelStringColor = SetLevelStringColor(40),
                    OrgsTag = "ITMO",
                    TimeStamp = DateTime.Now
                },
                new ESPPostModel() // ESP-04
                {
                    ESPName = "ESP-04",
                    Level = 60,
                    LevelString = SetLevelString(60),
                    LevelStringColor = SetLevelStringColor(60),
                    OrgsTag = "SUT",
                    TimeStamp = DateTime.Now
                }
            );

            await _context.SaveChangesAsync();
        }
    }

    private static string SetLevelString(int level)
    {
        string levelString;

        if (level > 60)
        {
            levelString = "High";
        }
        else if (level > 30)
        {
            levelString = "Medium";
        }
        else
        {
            levelString = "Low";
        }
        return levelString;
    }

    private static string SetLevelStringColor(int level)
    {
        string levelStringColor;

        // Assuming Level is an integer. Convert it to int if it's string.
        if (level > 60)
        {
            levelStringColor = "danger";
        }
        else if (level > 30)
        {
            levelStringColor = "warning";
        }
        else
        {
            levelStringColor = "secondary";
        }

        return levelStringColor;
    }

}

