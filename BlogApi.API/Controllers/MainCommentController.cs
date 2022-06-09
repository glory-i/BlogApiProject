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
    public class MainCommentController : ControllerBase
    {
        private IMainCommentServices _mainCommentServices;

        public MainCommentController(IMainCommentServices mainCommentServices)
        {
            _mainCommentServices = mainCommentServices;
        }

        [HttpPost("addmaincomment")]
        public ViewCommentDTO addMainComment(CreateCommentDTO createCommentDTO)
        {
            return _mainCommentServices.AddMainComment(createCommentDTO, User.Identity.Name);
        }

        [HttpGet("getmaincomments")]
        public IEnumerable<ViewCommentDTO> viewMainComments(int postid)
        {
            //return _mainCommentServices.AddMainComment(createCommentDTO, User.Identity.Name);
            return _mainCommentServices.ViewMainComments(postid);
        }



        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        //[Route("updatepost")]
        public IActionResult DeleteMainComment(int id)
        {

            _mainCommentServices.DeleteMainComment(id);
            return Ok();

        }
    }
}
