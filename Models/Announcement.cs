namespace MunicipalSolutions.Models;

public class Announcement
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public string? ImagePath { get; set; }  // allows optional image
    public DateTime PostedAt { get; set; } = DateTime.Now;
}