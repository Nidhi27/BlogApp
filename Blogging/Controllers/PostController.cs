using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blogging.Models;
using Blogging.Repository;
using System.Collections;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Blogging.Controllers
{
    public class PostController : ApiController
    {
        private static IPostRepository repository = new PostRepository();

        ApplicationDbContext db = new ApplicationDbContext();
        // api/Get
        public IEnumerable GetAllPost()
        {
         return repository.GetAll().ToList();
         }

        [Route("GetPostCategory")]
        public IEnumerable GetPostCategory(int id)
        {
            return repository.GetPostCategory(id).ToList();
        }

        public Post PostPosts(Post post)
        {
          //  var sdsd=HttpContext.Current.User.Identity.Name;
         
          //var bghg = db.Users.FirstOrDefault(x => x.UserName == sdsd);
          //  post.UserId = bghg.Id;
            return repository.Add(post);
        }

        

        public IEnumerable PutPost(int id, Post post)
        {
            post.Id = id;
            if (repository.Update(post))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool DeletePost(int id)
        {
            if (repository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
