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
    public class DislikeController : ControllerBase
    {
        private IDislikeServices _dislikeServices;

        public DislikeController(IDislikeServices dislikeServices)
        {
            _dislikeServices = dislikeServices;
        }


        [HttpPost]
        public IActionResult DislikePost(int postid)
        {
            _dislikeServices.DislikePost(postid, User.Identity.Name);
            return Ok();
        }


        [HttpPost("removedislike")]
        public IActionResult RemoveDislike(int postid)
        {
            _dislikeServices.RemoveDislike(postid, User.Identity.Name);
            return Ok();
        }

    }
}
