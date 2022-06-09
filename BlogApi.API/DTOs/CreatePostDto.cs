using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.DTOs
{
    public class CreatePostDto
    {
        
        public string Title { get; set; }
        public string Body { get; set; }

        public string Description { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }

        //public string Title { get; set; } = "";

    }
}
