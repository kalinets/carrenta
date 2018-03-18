using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carrenta.Controllers
{
  public class UserController : Controller
  {
    // GET: User
    //public ActionResult Index()
    //{
    //  return View();
    //}

    [Authorize(Users = "ukalinets@gmail.com")]
    public ActionResult UserList()
    {
      var context = new IdentityDbContext();
      var users = context.Users.ToList();
      ViewBag.DBUsers = users;
      return View(users);
    }
  }
}