using BlogApi.API.Authentication;
using BlogApi.API.DatabaseRepository.Implementations;
using BlogApi.API.Model;
using BlogApi.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogApi.API.Repositories.Implementations
{
    public class PostRepository : DatabaseRepository<Post>, IPostRepository
    {
        private readonly ApplicationDbContext _context;
        public PostRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Post CreatePost(string title, string body, string description, string tags, string category)
        {
            //throw new NotImplementedException();
            Post new_post = new Post
            {
                Title = title,
                Body = body,
                Description = description,
                Tags = tags,
                Category = category,
                Created = DateTime.Now,
                MainComments = new List<MainComment>(),
                Likes = 0,
                Dislikes = 0,
                NoOfViews = 0,
                LikedByUser = false,
                ReadByUser = false,
                DislikedByUser = false
            };
            _context.Posts.Add(new_post);
            _context.SaveChanges();
            return new_post;

        }

        public void DeletePost(int id)
        {
            // throw new NotImplementedException();
            var new_post = _context.Posts.Find(id);
            if(new_post != null)
            {
                _context.Posts.Remove(new_post);
                var maincomments = _context.MainComments.Where(m => m.PostId == id);
                var subcomments = _context.SubComments.Where(s => s.PostId == id);
                foreach(MainComment m in maincomments)
                {
                    _context.MainComments.Remove(m);
                }
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

        public IEnumerable<Post> GetAllPosts(int pageNumber, int pageSize, string category, string search)
        {
            //throw new NotImplementedException();
            var query = _context.Posts.AsQueryable();
            if (pageNumber < 1) { pageNumber = 1; }
            if (pageSize < 1) { pageSize = 5; }
            if (!String.IsNullOrEmpty(category))
            {
                query = query.Where(post => post.Category == category);
            }
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => (x.Title + x.Body + x.Description).Contains(search));

            }
            int skipamount = (pageNumber - 1) * pageSize;
            var list_of_posts = query.Skip(skipamount).Take(pageSize).ToList();
            return list_of_posts;



        }

        public Post ReadPost(int postid, string username)
        {
            //throw new NotImplementedException();
            var IsRead = _context.Reads.Where(r => r.PostId == postid && r.Username == username).Any();
            var query = _context.Posts.Include(x => x.MainComments);
            var new_post = query.FirstOrDefault(p => p.Id == postid);
            //.Find(postid);
            if (new_post == null)
            {
                throw new NullReferenceException();
                
            }
            if (!IsRead)
            {
                Read new_read = new Read();
                new_read.PostId = postid;
                new_read.Username = username;
                _context.Reads.Add(new_read);

                new_post.NoOfViews = new_post.NoOfViews + 1;
                _context.Posts.Update(new_post);

                _context.SaveChanges();
                
            }
            return new_post;
        }

        public override void SaveChanges()
        {
            base.SaveChanges();
            
            
        }

        public Post UpdatePost(int id, string title, string body, string description, string tags, string category)
        {
            //throw new NotImplementedException();
           var new_post =  _context.Posts.Find(id);
            if (new_post != null)
            {
                new_post.Title = title;
                new_post.Body = body;
                new_post.Description = description;
                new_post.Tags = tags;
                new_post.Category = category;
                _context.Posts.Update(new_post);
                _context.SaveChanges();

                return new_post;
            }
            else
            {
                throw new NullReferenceException();
            }

        }
    }
}
