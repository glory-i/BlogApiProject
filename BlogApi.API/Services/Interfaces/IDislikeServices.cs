using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Interfaces
{
    public interface IDislikeServices
    {

        void DislikePost(int postid, string username);
        void RemoveDislike(int postid, string username);
    }
}
