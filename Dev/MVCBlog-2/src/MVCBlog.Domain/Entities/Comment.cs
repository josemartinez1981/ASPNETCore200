﻿namespace MVCBlog.Domain.Entities
{
    using System;

    public class Comment
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime DatePublished { get; set; }
    }
}
