using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstApp.Web.Controllers
{
    public class Post {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }

    public class BlogController : Controller
    {
        public List<Post> Posts { get; set; }

        public BlogController()
        {
            Posts = new List<Post>()
            {
                new Post() { PostId=11, Description="Descripcion post 11", Title ="Post 11"  },
                new Post() { PostId=12, Description="Descripcion post 11", Title ="Post 12"  },
                new Post() { PostId=13, Description="Descripcion post 11", Title ="Post 13"  },
                new Post() { PostId=14, Description="Descripcion post 11", Title ="Post 14"  }
            };
        }

        // GET: Blog
        public ActionResult Index()
        {
            return View(Posts);
        }

        



    }
}