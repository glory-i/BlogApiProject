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
    public class SubCommentController : ControllerBase
    {
        private ISubCommentServices _subCommentServices;

        public SubCommentController(ISubCommentServices subCommentServices)
        {
            _subCommentServices = subCommentServices;
        }

        [HttpPost("addsubcomment")]
        public ViewSubCommentDTO addSubComment(CreateSubCommentDTO createSubCommentDTO)
        {
            return _subCommentServices.AddSubComment(createSubCommentDTO, User.Identity.Name);
        }

        [HttpGet("getsubcomments")]
        public IEnumerable<ViewSubCommentDTO> viewSubComments(int mainCommentId)
        {
            //return _mainCommentServices.AddMainComment(createCommentDTO, User.Identity.Name);
            //return _mainCommentServices.ViewMainComments(postid);
            return _subCommentServices.ViewSubComments(mainCommentId);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        //[Route("updatepost")]
        public IActionResult DeleteSubComment(int id)
        {

            _subCommentServices.DeleteSubComment(id);
            return Ok();

        }

    }
}
