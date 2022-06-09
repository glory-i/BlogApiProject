using BlogApi.API.DatabaseRepository.Interfaces;
using BlogApi.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Repositories.Interfaces
{
    public interface ISubCommentRepository: IDatabaseRepository<SubComment>
    {
        SubComment AddSubComment(int mainCommentId, string username, string message);
       // MainComment AddMainComment(int postid, string username, string message);
        void SaveChanges();

        IEnumerable<SubComment> ViewSubComments(int mainCommentid);
    }
}
