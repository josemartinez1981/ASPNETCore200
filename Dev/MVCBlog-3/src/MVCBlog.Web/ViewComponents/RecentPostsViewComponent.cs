using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Application.Interfaces;
using MVCBlog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBlog.Web.ViewComponents
{
    public class RecentPostsViewComponent : ViewComponent
    {
        private readonly IPostsService postsService;

        private readonly IMapper mapper;

        public RecentPostsViewComponent(IPostsService postsService, IMapper mapper)
        {
            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }

            if (postsService == null)
            {
                throw new ArgumentNullException(nameof(postsService));
            }

            this.mapper = mapper;
            this.postsService = postsService;
        }

        public IViewComponentResult Invoke(int numberOfPosts)
        {
            var posts = this.postsService.GetLatestPostsOverview(numberOfPosts);

            var result = this.mapper.Map<List<PostOverviewDto>>(posts);

            return View("Default", result);
        }
    }
}
