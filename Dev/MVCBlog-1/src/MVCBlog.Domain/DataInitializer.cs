namespace MVCBlog.Domain
{
    using MVCBlog.Domain.Entities;
    using System;
    using System.Collections.Generic;

    public static class DataInitializer
    {
        public static List<Post> CreateFakePosts()
        {
            var firstPost = new Post()
            {
                Id = 1,
                Title = "Welcome to MVC",
                Slug = "welcome-to-MVC",
                Author = "jperez",
                Text = "Hi! Welcome to MVC!",
                Date = new DateTime(2016, 01, 01)
            };
            var secondPost = new Post() { Id = 2, Title = "Second post", Slug = "second-post", Author = "jperez", Text = "This is my second post :)", Date = new DateTime(2016, 01, 10) };
            var thirdPost = new Post() { Id = 3, Title = "Another post", Slug = "another-post", Author = "jperez", Text = "Wow, this is my third post!", Date = new DateTime(2016, 03, 15) };
            var posts = new List<Post>
            {
                firstPost,
                secondPost,
                thirdPost,
            };
            for (int i = 4; i < 10; i++)
            {
                posts.Add(new Post() { Id = i, Title = $"Post number {i}", Slug = $"post-number-{i}", Author = "jperez", Text = $"Text of post #{i}", Date = new DateTime(2016, 06, 01).AddDays(i) });
            }

            firstPost.Comments.Add(new Comment { Id = 1, Post = firstPost, Author = "robertJ", DatePublished = firstPost.Date.AddDays(1), Text = "awesome post..." });

            secondPost.Comments.Add(new Comment { Id = 2, Post = secondPost, Author = "jamesK", DatePublished = secondPost.Date.AddDays(2), Text = "keep on going..." });
            secondPost.Comments.Add(new Comment { Id = 3, Post = secondPost, Author = "robertJ", DatePublished = secondPost.Date.AddDays(3), Text = "really helpfull..." });

            thirdPost.Comments.Add(new Comment { Id = 4, Post = thirdPost, Author = "robertJ", DatePublished = thirdPost.Date.AddDays(1), Text = "working on it..." });
            thirdPost.Comments.Add(new Comment { Id = 5, Post = thirdPost, Author = "albertM", DatePublished = thirdPost.Date.AddDays(2), Text = "can you give me another example?" });
            thirdPost.Comments.Add(new Comment { Id = 6, Post = thirdPost, Author = "johnD", DatePublished = thirdPost.Date.AddDays(3), Text = "awesome post..." });

            return posts;
        }
    }
}
