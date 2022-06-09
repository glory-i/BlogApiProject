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
    public class SubCommentRepository : DatabaseRepository<SubComment>, ISubCommentRepository
    {
        private readonly ApplicationDbContext _context;
        public SubCommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public SubComment AddSubComment(int mainCommentId, string username, string message)
        {
            //throw new NotImplementedException();
            var new_mainComment = _context.MainComments.Find(mainCommentId);
            if (new_mainComment != null)
            {

                SubComment subComment = new SubComment();
                subComment.PostId = new_mainComment.PostId;
                subComment.Username = username;
                subComment.Message = message;
                subComment.Created = DateTime.Now;
                subComment.MainCommentId = mainCommentId;

                _context.SubComments.Add(subComment);
                new_mainComment.SubComments.Add(subComment);
                _context.MainComments.Update(new_mainComment);

                _context.SaveChanges();
                return subComment;

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

        public IEnumerable<SubComment> ViewSubComments(int mainCommentid)
        {
            //throw new NotImplementedException();
            var new_mainComment = _context.MainComments.Find(mainCommentid);
            if(new_mainComment!= null)
            {
                var query = _context.SubComments.Where(p => p.MainCommentId == mainCommentid).ToList();
                return query;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }
}
