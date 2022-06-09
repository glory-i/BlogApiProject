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
    public class PostServices : IPostServices
    {
        private readonly IPostRepository _postRepository;
        public PostServices(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        public void DeletePost(int id)
        {
            _postRepository.DeletePost(id);
        }


        public ViewPostDTO CreatePost(CreatePostDto createPostDto)
        {
            var new_post = _postRepository.CreatePost(createPostDto.Title, createPostDto.Body
                ,createPostDto.Description, createPostDto.Tags, createPostDto.Category);

            ViewPostDTO viewPostDTO = new ViewPostDTO
            {
                Title = new_post.Title,
                Body = new_post.Body,
                Description = new_post.Description,
                Tags = new_post.Tags,
                Category = new_post.Category,
                Created = new_post.Created,
                MainComments = new_post.MainComments,
                Likes = new_post.Likes,
                Dislikes = new_post.Dislikes,
                NoOfViews = new_post.NoOfViews
            };
            return viewPostDTO;

        }

        public ViewPostDTO EditPost(int id, CreatePostDto createPostDto)
        {
            //throw new NotImplementedException();

            //_postRepository.SaveChanges();
            var new_post = _postRepository.UpdatePost(id, createPostDto.Title, createPostDto.Body,
                createPostDto.Description, createPostDto.Tags, createPostDto.Category);

                ViewPostDTO viewPostDTO = new ViewPostDTO
                {

                    Title = new_post.Title,
                    Body = new_post.Body,
                    Description = new_post.Description,
                    Tags = new_post.Tags,
                    Category = new_post.Category,
                    MainComments = new_post.MainComments,
                    Created = new_post.Created,
                    Likes = new_post.Likes,
                    Dislikes = new_post.Dislikes,
                    NoOfViews = new_post.NoOfViews
                };
                return viewPostDTO;

        }

        public ViewPostDTO ViewPost(int id, string username)
        {
            //throw new NotImplementedException();
            Post my_post = _postRepository.ReadPost(id, username);
            ViewPostDTO viewPostDTO = new ViewPostDTO
            {

                Title = my_post.Title,
                Body = my_post.Body,
                Description = my_post.Description,
                Tags = my_post.Tags,
                Category = my_post.Category,
                Created = my_post.Created,
                MainComments = my_post.MainComments,
                Likes = my_post.Likes,
                Dislikes = my_post.Dislikes,
                NoOfViews = my_post.NoOfViews
            };
            return viewPostDTO;
        }

        public IEnumerable<ViewPostDTO> GetAllPosts(int pageNumber, int pageSize, string category, string search)
        {
            //throw new NotImplementedException();
            var myPosts = _postRepository.GetAllPosts(pageNumber, pageSize, category, search);
            List<ViewPostDTO> viewPostDTOs = new List<ViewPostDTO>();
            foreach(Post p in myPosts)
            {
                ViewPostDTO viewPostDTO = new ViewPostDTO 
                {
                    Title = p.Title,
                    Body = p.Body,
                    Description = p.Description,
                    Tags = p.Tags,
                    Category = p.Category,
                    Created = p.Created,
                    Likes = p.Likes,
                    Dislikes = p.Dislikes,
                    NoOfViews = p.NoOfViews
                };
                viewPostDTOs.Add(viewPostDTO);
            }
            return viewPostDTOs;
        }


        //throw new NotImplementedException();
    }
}


