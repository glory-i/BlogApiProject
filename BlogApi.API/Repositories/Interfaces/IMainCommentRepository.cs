using BlogApi.API.DatabaseRepository.Interfaces;
using BlogApi.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Repositories.Interfaces
{
    public interface IMainCommentRepository: IDatabaseRepository<MainComment>
    {
        MainComment AddMainComment(int postid, string username, string message);

        IEnumerable<MainComment> ViewMainComments(int postid);

        void DeleteMainComment(int id);
        void SaveChanges();
    }
}
