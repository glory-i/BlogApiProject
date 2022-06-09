using BlogApi.API.DTOs;
using BlogApi.API.Model;
using BlogApi.API.Repositories.Interfaces;
using BlogApi.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Implementations
{
    public class SubCommentServices: ISubCommentServices
    {
        private ISubCommentRepository _subCommentRepository;

        public SubCommentServices(ISubCommentRepository subCommentRepository)
        {
            _subCommentRepository = subCommentRepository;
        }

        public ViewSubCommentDTO AddSubComment(CreateSubCommentDTO createSubCommentDTO, string username)
        {
            //throw new NotImplementedException();
            var new_subComment = _subCommentRepository.AddSubComment(createSubCommentDTO.MainCommentId, username, createSubCommentDTO.Message);
            ViewSubCommentDTO viewSubCommentDTO = new ViewSubCommentDTO
            {
                PostId = new_subComment.PostId,
                Message = new_subComment.Message,
                Created = new_subComment.Created,
                Username = new_subComment.Username,
                MainCommentId = new_subComment.MainCommentId
                
            };
            return viewSubCommentDTO;

        }

        public void DeleteSubComment(int id)
        {
            // throw new NotImplementedException();
            var new_SubComment = _subCommentRepository.Get(id);
            if (new_SubComment != null)
            {
                _subCommentRepository.Remove(new_SubComment);
            }
            else
            {
                throw new NullReferenceException();
            }

        }

        public IEnumerable<ViewSubCommentDTO> ViewSubComments(int mainCommentId)
        {
            //throw new NotImplementedException();
            var list_of_SUBComments = _subCommentRepository.ViewSubComments(mainCommentId);
            List<ViewSubCommentDTO> viewSubCommentDTOs = new List<ViewSubCommentDTO>();
            foreach (SubComment m in list_of_SUBComments)
            {
                ViewSubCommentDTO viewSubCommentDTO = new ViewSubCommentDTO
                {
                    PostId = m.PostId,
                    Message = m.Message,
                    Created = m.Created,
                    Username = m.Username,
                    MainCommentId = m.MainCommentId
                };
                //viewCommentDTOs.Add(viewCommentDTO);
                viewSubCommentDTOs.Add(viewSubCommentDTO);
            }
            return viewSubCommentDTOs;
        }
    }
}
