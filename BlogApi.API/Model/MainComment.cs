using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Model
{
    public class MainComment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }

        public string Username { get; set; }
        public List<SubComment> SubComments { get; set; }
    }
}
