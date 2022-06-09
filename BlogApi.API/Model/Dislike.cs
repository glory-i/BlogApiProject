using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Model
{
    public class Dislike
    {

        public int Id { get; set; }
        public int PostId { get; set; }

        public string Username { get; set; }
    }
}
