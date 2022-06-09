using BlogApi.API.Repositories.Interfaces;
using BlogApi.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Implementations
{
    public class LikeServices : ILikeServices
    {
        private ILikeRepository _likeRepository;

        public LikeServices(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public void LikePost(int postid, string username)
        {
            _likeRepository.LikePost(postid, username);
            //throw new NotImplementedException();
        }

        public void RemoveLike(int postid, string username)
        {
            _likeRepository.RemoveLike(postid, username);
           // throw new NotImplementedException();
        }
    }
}
