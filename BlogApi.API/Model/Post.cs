using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public string Description { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }

        public DateTime Created { get; set; }
        //public string Title { get; set; } = "";

        //public ICollection<MainComment> MainComments { get; set; } 

        public List<MainComment> MainComments { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int NoOfViews { get; set; }

        public bool LikedByUser { get; set; } = false;
        public bool DislikedByUser { get; set; } = false;

        public bool ReadByUser { get; set; } = false;
        public string Family { get; set; }
    }
}
