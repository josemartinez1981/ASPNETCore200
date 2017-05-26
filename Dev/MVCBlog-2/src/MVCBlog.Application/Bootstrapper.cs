namespace MVCBlog.Application
{
    using Microsoft.Extensions.DependencyInjection;
    using MVCBlog.Application.Interfaces;
    using MVCBlog.Application.Services;

    public static class Bootstrapper
    {
        public static void AddMVCBlog(this IServiceCollection services)
        {
            services.AddSingleton<IPostsService, PostsService>();
        }
    }
}
