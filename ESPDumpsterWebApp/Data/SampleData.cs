using ESPDumpsterWebApp.Models;

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
        var context = serviceProvider.GetRequiredService<ApplicationDbContext>();

        if (!context.OrganisationViewModel.Any())
        {
            context.OrganisationViewModel.AddRange(
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

            await context.SaveChangesAsync();
        }
    }
}