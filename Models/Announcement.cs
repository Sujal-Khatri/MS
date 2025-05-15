namespace MunicipalSolutions.Models
{
    public class Announcement
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime PostedAt { get; set; } = DateTime.Now;
}
}