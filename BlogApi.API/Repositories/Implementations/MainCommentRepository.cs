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
    public class MainCommentRepository : DatabaseRepository<MainComment>, IMainCommentRepository
    {
        private readonly ApplicationDbContext _context;
        public MainCommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public MainComment AddMainComment(int postid, string username, string message)
        {
            //throw new NotImplementedException();
            var post = _context.Posts.Find(postid);
            if (post != null)
            {
                //_context.MainComments.Add(mainComment);
                //return mainComment;
                MainComment mainComment = new MainComment
                {
                    PostId = post.Id,
                    Message = message,
                    Created = DateTime.Now,
                    Username = username
                };
                post.MainComments = post.MainComments ?? new List<MainComment>();
                post.MainComments.Add(mainComment);
                
                _context.Posts.Update(post);

                _context.SaveChanges();
                return mainComment;
            }
            else
            {
                throw new NullReferenceException();
            }
            //we battle from here tomorrow
            
        }

        public void DeleteMainComment(int id)
        {
            //throw new NotImplementedException();
            var main_comment = _context.MainComments.Find(id);
            if(main_comment!= null)
            {
                _context.MainComments.Remove(main_comment);
                var subcomments = _context.SubComments.Where(s => s.MainCommentId == id);
                foreach(SubComment s in subcomments)
                {
                    _context.SubComments.Remove(s);
                }
                _context.SaveChanges();
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public override void SaveChanges()
        {
            base.SaveChanges();

        }

        public IEnumerable<MainComment> ViewMainComments(int postid)
        {
            //throw new NotImplementedException();
            var new_post = _context.Posts.Find(postid);
            if(new_post!= null)
            {

                var query = _context.MainComments.Where(p => p.PostId == postid).ToList();
                return query;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
