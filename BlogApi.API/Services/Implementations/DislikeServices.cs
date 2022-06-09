using BlogApi.API.Repositories.Interfaces;
using BlogApi.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Implementations
{
    public class DislikeServices : IDislikeServices
    {
        private IDislikeRepository _dislikeRepository;

        public DislikeServices(IDislikeRepository dislikeRepository)
        {
            _dislikeRepository = dislikeRepository;
        }

        public void DislikePost(int postid, string username)
        {
            //throw new NotImplementedException();
            _dislikeRepository.DislikePost(postid, username);
        }

        public void RemoveDislike(int postid, string username)
        {
            //throw new NotImplementedException();
            _dislikeRepository.RemoveDislike(postid, username);
        }
    }
}
