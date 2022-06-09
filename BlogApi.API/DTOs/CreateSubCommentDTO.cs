using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.DTOs
{
    public class CreateSubCommentDTO
    {

        public int MainCommentId { get; set; }
        public string Message { get; set; }
    }
}
