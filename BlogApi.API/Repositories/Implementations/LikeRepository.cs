using BlogApi.API.Authentication;
using BlogApi.API.DatabaseRepository.Implementations;
using BlogApi.API.Model;
using BlogApi.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Repositories.Implementations
{
    public class LikeRepository : DatabaseRepository<Like>, ILikeRepository
    {
        private readonly ApplicationDbContext _context;
        public LikeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void LikePost(int postid, string username)
        {
            //throw new NotImplementedException();
            var new_post = _context.Posts.Find(postid);
            if (new_post == null)
            {
                throw new NullReferenceException();
            }


            var IsLike = _context.Likes.Where(l => l.PostId == postid && l.Username == username).Any();
            if (!IsLike)
            {
                
                Like new_like = new Like();
                new_like.PostId = postid;
                new_like.Username = username;
                _context.Likes.Add(new_like);


                new_post.Likes = new_post.Likes + 1;
                _context.Posts.Update(new_post);
                _context.SaveChanges();

            }
            else
            {

            }
        }

        public void RemoveLike(int postid, string username)
        {
            //throw new NotImplementedException();
            var new_post = _context.Posts.Find(postid);
            if (new_post == null)
            {
                throw new NullReferenceException();
            }


            var IsLike = _context.Likes.Where(l => l.PostId == postid && l.Username == username).Any();
            if (IsLike)
            {
                Like new_like = _context.Likes.FirstOrDefault(l => l.PostId == postid && l.Username == username);

                _context.Likes.Remove(new_like);
                new_post.Likes = new_post.Likes - 1;
                _context.Posts.Update(new_post);
                _context.SaveChanges();

            }
            else
            {

            }

        }

        public override void SaveChanges()
        {
            base.SaveChanges();

        }
    }
}
