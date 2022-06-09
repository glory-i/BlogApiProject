using BlogApi.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Interfaces
{
    public interface ISubCommentServices
    {

        void DeleteSubComment(int id);
        IEnumerable<ViewSubCommentDTO> ViewSubComments(int mainCommentId);
        ViewSubCommentDTO AddSubComment(CreateSubCommentDTO createSubCommentDTO, string username);
    }
}
