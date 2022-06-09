using BlogApi.API.DatabaseRepository.Interfaces;
using BlogApi.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Repositories.Interfaces
{
    public interface IPostRepository: IDatabaseRepository<Post>
    {

        void SaveChanges();
        Post ReadPost(int postid, string username);

        void DeletePost(int id);

        IEnumerable<Post> GetAllPosts(int pageNumber, int pageSize, string category, string search);
        Post CreatePost(string title, string body,string description, string tags, string category);
        Post UpdatePost(int id, string title, string body,string description, string tags, string category);

    }
}
