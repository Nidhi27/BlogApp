using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Blogging.Repository;
using System.Collections;
using Blogging.Models;

namespace Blogging.Controllers
{
    public class CategoryController : ApiController
    {
        private static ICategoryRepository repository = new CategoryRepository();

        ApplicationDbContext db = new ApplicationDbContext();
        // api/Get
        public IEnumerable GetAllCategory()
        {

            return repository.GetAll();
        }

        public Category PostCategories(Category category)
        {

            return repository.Add(category);
        }

        public IEnumerable PutCategory(int id, Category category)
        {
            category.Id = id;
            if (repository.Update(category))
            {
                return repository.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool DeleteCategory(int id)
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
