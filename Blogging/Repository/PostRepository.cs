using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blogging.Models;

namespace Blogging.Repository
{
    public class PostRepository : IPostRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public IEnumerable<Post> GetAll()
        {
            // TO DO : Code to get the list of all the records in database

            return db.Posts;
        }

        public Post Get(int id)
        {
            // TO DO : Code to find a record in database
            return db.Posts.Find(id);
        }

        public IEnumerable<Post> GetPostCategory(int id)
        {
            var posts = db.Posts.Where(p => p.CategoryId == id).ToList();

            return posts;
        }

        //public Employee Add(Employee item)
        //{
        //    if (item == null)
        //    {
        //        throw new ArgumentNullException("item");
        //    }

        //    // TO DO : Code to save record into database
        //    db.Employees.Add(item);
        //    db.SaveChanges();
        //    return item;
        //}

        public Post Add(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            // TO DO : Code to save record into database
           
          var ol=   db.Posts.Add(post);
           // db.PostTagMappings
            db.SaveChanges();
            return post;
        }
        public bool Update(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            // TO DO : Code to update record into database
            var posts = db.Posts.Single(a => a.Id == post.Id);
            posts.Title = post.Title;
            posts.Content = post.Content;
            posts.PostedOn = post.PostedOn;
            posts.CategoryId = post.CategoryId;
            posts.TagIds = post.TagIds;
            posts.PostTagMapping = post.PostTagMapping.ToList();

            db.SaveChanges();

            return true;
        }


        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Post posts = db.Posts.Find(id);
            db.Posts.Remove(posts);
            db.SaveChanges();
            return true;
        }
    }
}