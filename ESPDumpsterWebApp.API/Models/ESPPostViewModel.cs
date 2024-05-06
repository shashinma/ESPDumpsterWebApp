namespace ESPDumpsterWebAppAPI.Models;

public class ESPPostAPIModel
{
    public int Id { get; set; }
    public string ESPName { get; set; }
    public int Level { get; set; }
    public string? LevelString { get; set; }
    public string? LevelStringColor { get; set; }
    public string OrgsTag { get; set; }
    public DateTime? TimeStamp { get; set; }
}
