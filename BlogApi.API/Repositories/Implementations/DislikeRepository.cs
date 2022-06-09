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
    public class DislikeRepository: DatabaseRepository<Dislike>, IDislikeRepository
    {
        private readonly ApplicationDbContext _context;
        public DislikeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void DislikePost(int postid, string username)
        {
            //throw new NotImplementedException();
            var new_post = _context.Posts.Find(postid);
            if (new_post == null)
            {
                throw new NullReferenceException();
            }

            var IsDislike = _context.Dislikes.Where(l => l.PostId == postid && l.Username == username).Any();
            if (!IsDislike)
            {
                
                Dislike new_dislike = new Dislike();
                new_dislike.PostId = postid;
                new_dislike.Username = username;
                _context.Dislikes.Add(new_dislike);

                
                new_post.Dislikes = new_post.Dislikes + 1;
                _context.Posts.Update(new_post);
                _context.SaveChanges();

            }
            else
            {

            }
        }


        public void RemoveDislike(int postid, string username)
        {
            //throw new NotImplementedException();
            var new_post = _context.Posts.Find(postid);
            if (new_post == null)
            {
                throw new NullReferenceException();
            }

            var IsDislike = _context.Dislikes.Where(l => l.PostId == postid && l.Username == username).Any();
            if (IsDislike)
            {
                Dislike new_dislike = _context.Dislikes.FirstOrDefault(l => l.PostId == postid && l.Username == username);
                _context.Dislikes.Remove(new_dislike);
                new_post.Dislikes = new_post.Dislikes - 1;
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
