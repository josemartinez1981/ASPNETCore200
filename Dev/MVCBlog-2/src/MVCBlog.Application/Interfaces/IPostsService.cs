namespace MVCBlog.Application.Interfaces
{
    using MVCBlog.Domain.Entities;
    using System.Collections.Generic;

    public interface IPostsService
    {
        Post GetById(int id);
        
        IEnumerable<Post> GetLatestPostsOverview(int max);

        void AddComment(int postId, Comment comment);
    }
}
