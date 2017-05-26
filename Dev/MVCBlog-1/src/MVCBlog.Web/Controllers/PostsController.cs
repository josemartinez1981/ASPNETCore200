namespace MVCBlog.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MVCBlog.Web.Models;
    using MVCBlog.Application.Interfaces;
    using System;
    using AutoMapper;
    using MVCBlog.Domain.Entities;

    public class PostsController : Controller
    {
        private readonly IPostsService postsService;

        private readonly IMapper mapper;

        public PostsController(IPostsService postsService, IMapper mapper)
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

        [HttpGet]
        public IActionResult Index(int id)
        {
            var post = this.postsService.GetById(id);
            if (post == null)
            {
                return NotFound();
            }

            var result = this.mapper.Map<PostDto>(post);
            return View(result);
        }

        [HttpPost]
        public IActionResult AddComment(CommentDto commentDto)
        {
            var comment = this.mapper.Map<Comment>(commentDto);
            this.postsService.AddComment(commentDto.PostId, comment);

            return RedirectToAction("Index", new { id = commentDto.PostId });
        }
    }
}
