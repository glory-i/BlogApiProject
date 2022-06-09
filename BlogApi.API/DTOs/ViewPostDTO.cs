using BlogApi.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.DTOs
{
    public class ViewPostDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public string Description { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }

        public DateTime Created { get; set; }
        //public string Title { get; set; } = "";

        public List<MainComment> MainComments { get; set; }

        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int NoOfViews { get; set; }

       
    }
}
