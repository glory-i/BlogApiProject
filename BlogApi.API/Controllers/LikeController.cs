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
    public class LikeController : ControllerBase
    {
        private ILikeServices _likeServices;

        public LikeController(ILikeServices likeservices)
        {
            _likeServices = likeservices;
        }

        [HttpPost]
        public IActionResult LikePost(int postid) 
        {
            _likeServices.LikePost(postid, User.Identity.Name);
            return Ok();
        }

        
        [HttpPost("removelike")]
        public IActionResult RemoveLike(int postid)
        {
            _likeServices.RemoveLike(postid, User.Identity.Name);
            return Ok();
        }
        
    }
}
