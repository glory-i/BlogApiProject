using BlogApi.API.DatabaseRepository.Interfaces;
using BlogApi.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Repositories.Interfaces
{
    public interface IDislikeRepository : IDatabaseRepository<Dislike>
    {

        void DislikePost(int postid, string username);
        void RemoveDislike(int postid, string username);

        void SaveChanges();
    }
}
