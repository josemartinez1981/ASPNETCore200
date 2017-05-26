using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Application.Interfaces;
using MVCBlog.Web.Models;
using System;
using System.Collections.Generic;

namespace MVCBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostsService postsService;

        private readonly IMapper mapper;

        public HomeController(IPostsService postsService, IMapper mapper)
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

        public IActionResult Index()
        {
            var posts = this.postsService.GetLatestPostsOverview(3);

            var result = this.mapper.Map<List<PostOverviewDto>>(posts);

            return View(result);
        }
    }
}
