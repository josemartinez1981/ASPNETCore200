namespace MVCBlog.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public IList<Comment> Comments { get; set; }

        public Post()
        {
            this.Comments = new List<Comment>();
        }
    }
}
