using System;
using System.Collections.Generic;

namespace MunicipalSolutions.Models
{
    public class DiscussionPost
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; } = DateTime.Now;

        public List<DiscussionReply> Replies { get; set; } = new();
        
    }
}