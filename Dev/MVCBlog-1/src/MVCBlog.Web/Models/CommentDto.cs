namespace MVCBlog.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        public string Text { get; set; }

        [Display(Name = "Date published")]
        public DateTime DatePublished { get; set; }
    }
}
