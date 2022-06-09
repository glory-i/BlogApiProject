using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.DTOs
{
    public class ViewSubCommentDTO
    {

        public int MainCommentId { get; set; }
        public int PostId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

        public string Username { get; set; }
    }
}
