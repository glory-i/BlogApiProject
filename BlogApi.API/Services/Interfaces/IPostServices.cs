using BlogApi.API.DTOs;
using BlogApi.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Interfaces
{
    public interface IPostServices
    {
        ViewPostDTO CreatePost(CreatePostDto createPostDto);
        ViewPostDTO EditPost(int id, CreatePostDto createPostDto);

        void DeletePost(int id);

        ViewPostDTO ViewPost(int id, string username);

        IEnumerable<ViewPostDTO> GetAllPosts(int pageNumber, int pageSize, string category, string search);
    }
}
