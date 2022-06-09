using BlogApi.API.DTOs;
using BlogApi.API.Repositories.Interfaces;
using BlogApi.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using BlogApi.API.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Implementations
{
    public class MainCommentServices: IMainCommentServices
    {
        private IMainCommentRepository _mainCommentRepository;

        public MainCommentServices(IMainCommentRepository mainCommentRepository)
        {
            _mainCommentRepository = mainCommentRepository;
        }

        public ViewCommentDTO AddMainComment(CreateCommentDTO createCommentDTO, string username)
        {
            //throw new NotImplementedException();
            var new_mainComment = _mainCommentRepository.AddMainComment(createCommentDTO.PostId, username, createCommentDTO.Message);
            ViewCommentDTO viewCommentDTO = new ViewCommentDTO
            {
                PostId = new_mainComment.PostId,
                Message = new_mainComment.Message,
                Created = new_mainComment.Created,
                Username = new_mainComment.Username
            };
            return viewCommentDTO;

        }

        public IEnumerable<ViewCommentDTO> ViewMainComments(int postid)
        {
            //throw new NotImplementedException();
            var list_of_mainComments = _mainCommentRepository.ViewMainComments(postid);
            List<ViewCommentDTO> viewCommentDTOs = new List<ViewCommentDTO>();
            foreach(MainComment m in list_of_mainComments)
            {
                ViewCommentDTO viewCommentDTO = new ViewCommentDTO
                {
                    PostId = m.PostId,
                    Message = m.Message,
                    Created = m.Created,
                    Username =m.Username
                };
                viewCommentDTOs.Add(viewCommentDTO);
            }
            return viewCommentDTOs;
        }

        public void DeleteMainComment(int id)
        {
            //var new_post = _postRepository.Get(id);
            _mainCommentRepository.DeleteMainComment(id);
        }

    }
}
