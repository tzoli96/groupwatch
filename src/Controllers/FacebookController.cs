// Controllers/FacebookController.cs
using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacebookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly FacebookService _facebookService;

        public FacebookController(ApplicationDbContext context, FacebookService facebookService)
        {
            _context = context;
            _facebookService = facebookService;
        }

        [HttpGet("group-posts/{groupId}")]
        public async Task<IActionResult> GetGroupPosts(string groupId)
        {
            var posts = await _facebookService.GetGroupPostsAsync(groupId);

            foreach (var post in posts)
            {
                var newPost = new Post
                {
                    PostId = post["id"].ToString(),
                    Message = post["message"]?.ToString() ?? string.Empty,
                    CreatedTime = DateTime.Parse(post["created_time"].ToString())
                };

                if (!_context.Posts.Any(p => p.PostId == newPost.PostId))
                {
                    _context.Posts.Add(newPost);
                    await _context.SaveChangesAsync();
                }
            }

            return Ok(posts);
        }
    }
}
