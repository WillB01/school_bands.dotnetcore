using System;

namespace FavoriteBand.Models
{
    public class ForumMessage
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTimeOffset PostAt { get; set; }
    }
}