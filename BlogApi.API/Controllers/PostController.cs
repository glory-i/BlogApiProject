using BlogApi.API.Authentication;
using BlogApi.API.DTOs;
using BlogApi.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.API.Controllers
{

    [Authorize(Roles = "User,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostServices _postServices;

        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        //[Route("updatepost")]
        public IActionResult DeletePost(int id)
        {
            
            _postServices.DeletePost(id);
            return Ok();

        }



        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("{id}")]
        //[Route("updatepost")]
        public ViewPostDTO UpdatePost(int id, CreatePostDto createPostDto)
        {
            return _postServices.EditPost(id, createPostDto);
        }



        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [Route("createpost")]
        public ViewPostDTO CreatePost(CreatePostDto createPostDto)
        {
            return _postServices.CreatePost(createPostDto);
        }


        [HttpGet("{id}")]
        public ViewPostDTO ViewPost(int id)
        {
            return _postServices.ViewPost(id, User.Identity.Name);
        }

        [HttpGet("getposts")]
        public IEnumerable<ViewPostDTO> GetPosts(int pageNumber, int pageSize, string category, string search)
        {
            return _postServices.GetAllPosts(pageNumber, pageSize, category, search);
            //return _postServices.ViewPost(id, User.Identity.Name);
        }



    }
}
