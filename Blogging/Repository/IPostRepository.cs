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
        IEnumerable<Post> GetAll(string userId);
        IQueryable GetAllByCategoryId(int categoryId);
        //IEnumerable<Post> GetAllByTagIds(int tagId);
        IQueryable GetAll();
        Post Get(int id);
       
        Post Add(Post post);
        bool Update(Post post);
        bool Delete(int id);
    }
}
