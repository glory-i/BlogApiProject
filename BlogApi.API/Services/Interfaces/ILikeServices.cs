using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.API.Services.Interfaces
{
    public interface ILikeServices
    {
        void LikePost(int postid, string username);
        void RemoveLike(int postid, string username);

    }
}
