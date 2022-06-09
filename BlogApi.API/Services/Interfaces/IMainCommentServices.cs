using BlogApi.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Interfaces
{
    public interface IMainCommentServices
    {
        ViewCommentDTO AddMainComment(CreateCommentDTO createCommentDTO, string username);

        IEnumerable<ViewCommentDTO> ViewMainComments(int postid);

        void DeleteMainComment(int id);


    }
}
