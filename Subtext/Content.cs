using System;

namespace SubTextCVSToJekyll.Subtext
{
    public class Content
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public int PostType { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public int BlogId { get; set; }
        public string Description { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Text { get; set; }
        public int FeedBackCount { get; set; }
        public int PostConfig { get; set; }
        public string EntryName { get; set; }
        public DateTime DateSyndicated { get; set; }
    }
}