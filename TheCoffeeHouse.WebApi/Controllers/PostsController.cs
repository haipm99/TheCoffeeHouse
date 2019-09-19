using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheCoffeehouse.Data.Models;
using TheCoffeehouse.Data.Models.Domains;
using TheCoffeehouse.Data.Models.Uow;
using TheCoffeehouse.Data.Models.View;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheCoffeeHouse.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        public PostsController(IUnitOfWork uow) : base(uow)
        {

        }

        //desc : get all Product
        // url : Posts/GetAll
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_uow.GetService<PostsDomains>().GetAll().Select(p => new
            {
                id = p.Id,
                title = p.Title,
                content = p.Content,
                postedDate = p.PostedDate,
                img = p.Img
            }));
        }

        //desc: Create new Post
        // url : Posts/Create
        [HttpPost("Create")]
        public IActionResult Create(PostsModelCreate model)
        {
            var repo = _uow.GetService<PostsDomains>();

            var newPost = new Posts
            {
                Id = Guid.NewGuid().ToString(),
                Title = model.title,
                Content = model.content,
                PostedDate = DateTime.Now,
                Img = model.img,
                UserId = model.userId,
            };
            repo.Create(newPost);
            _uow.SaveChanges();
            return Ok(newPost);
        }

        //desc : Get post by Id
        //url : Posts/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var repo = _uow.GetService<PostsDomains>();
            var post = repo.GetPostById(id);

            if(post != null)
            {
                var returnResult = new
                {
                    Id = post.Id,
                    Content = post.Content,
                    Title = post.Title,
                    Img = post.Img,
                    PostedDate = post.PostedDate,
                    UserId = post.UserId
                };
                return Ok(returnResult);
            }
            return NotFound("Empty Post.");
        }
        

        //desc : Delete Post
        //url :
        [HttpDelete("{id}")]
        public IActionResult DeleteById(string id)
        {
            var repo = _uow.GetService<PostsDomains>();

            var post = repo.GetPostById(id);
            if(post != null)
            {
                var returnResult = new
                {
                    Id = post.Id,
                    Content = post.Content,
                    Title = post.Title,
                    Img = post.Img,
                    PostedDate = post.PostedDate,
                    UserId = post.UserId
                };
                repo.Delete(post);
                _uow.SaveChanges();
                return Ok(returnResult);
            }
            return NotFound("Invalid id of Post.");
        }

        //desc : Update post
        //url :
        [HttpPatch("{id}")]
        public IActionResult Update(string id,PostsModelUpdate model)
        {
            var repo = _uow.GetService<PostsDomains>();

            var post = new Posts
            {
                Id = id,
                Title = model.title,
                Content = model.content,
                Img = model.img,
                PostedDate = DateTime.Now,
                UserId = model.userId
            };
            repo.Update(post);
            _uow.SaveChanges();
            return Ok(post);
        }
    }
}
