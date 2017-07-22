using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogging.Models;

namespace Blogging.Repository
{
    interface IPostRepository
    {
        IEnumerable<Post> GetAll();
        Post Get(int id);
        IEnumerable<Post> GetPostCategory(int id);
        Post Add(Post post);
        bool Update(Post post);
        bool Delete(int id);
    }
}
