namespace MVCBlog.Application.Services
{
    using System.Collections.Generic;
    using MVCBlog.Application.Interfaces;
    using MVCBlog.Domain.Entities;
    using MVCBlog.Domain;
    using System.Linq;
    using AutoMapper;
    using System;

    public class PostsService : IPostsService
    {
        private static List<Post> Posts { get; set; }

        

        public PostsService()
        {
            Posts = DataInitializer.CreateFakePosts();
        }

        public IEnumerable<Post> GetLatestPostsOverview(int max)
        {
            return Posts.Take(max);
        }

        public Post GetById(int id)
        {
            return Posts.FirstOrDefault(x => x.Id == id);
        }

        public void AddComment(int postId, Comment comment)
        {
            var post = Posts.FirstOrDefault(x => x.Id == postId);

            comment.Post = post;
            comment.DatePublished = DateTime.UtcNow;

            post.Comments.Add(comment);
        }
    }
}
