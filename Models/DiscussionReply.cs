namespace MunicipalSolutions.Models
{
 public class DiscussionReply
 {
    public int Id { get; set; }
    public int DiscussionPostId { get; set; }
    public string UserId { get; set; }
    public string Message { get; set; }
    public DateTime RepliedAt { get; set; } = DateTime.Now;
 }
}