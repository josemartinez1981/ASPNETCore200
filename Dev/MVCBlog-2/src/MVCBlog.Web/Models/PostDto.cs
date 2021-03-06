﻿namespace MVCBlog.Web.Models
{
    using System;
    using System.Collections.Generic;

    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
