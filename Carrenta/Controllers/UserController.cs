using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Carrenta.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

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

    // GET: Car/Edit/5
    //[Authorize(Users = "ukalinets@gmail.com")]
    //[HttpGet]
    //public ActionResult Edit(int userId)
    //{
    //  using (var db = new ApplicationDbContext())
    //  {
    //    var user = db.Users.Find(userId);
    //    return View(user);
    //  }
    //}

    // POST: Car/Edit/6
    //[Authorize(Users = "ukalinets@gmail.com")]
    //[HttpPost]
    //public ActionResult Edit()
    //{
    //  using (var db = new ApplicationDbContext())
    //  {
    //    db.Entry(User).State = EntityState.Modified;
    //    db.SaveChanges();
    //    return RedirectToAction("UserList");
    //  }
    //}

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteUser(string userId)
    {
      using (var db = new ApplicationDbContext())
      {
        var user = db.Users.Find(userId);
        db.Users.Remove(user);
        db.SaveChanges();
        return RedirectToAction("UserList");
      }
    }

    // [HttpPost]
    public void DeleteAcc(string userId)
    {
      using (var db = new ApplicationDbContext())
      {
        var user = db.Users.Find(userId);
        db.Users.Remove(user);
        db.SaveChanges();
      }
    }
  }
}