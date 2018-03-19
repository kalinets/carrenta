using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Carrenta.Models;
using Microsoft.AspNet.Identity;

namespace Carrenta.Controllers
{
  public class OrderController : Controller
  {
    DataBaseContext db = new DataBaseContext();

    // GET: Order
    [Authorize]
    [HttpGet]
    public ActionResult Create(int carId)
    {
      ViewBag.userID = User.Identity.GetUserId();
      ViewBag.userEmail = User.Identity.GetUserName();
      ViewBag.CarID = carId;
      return View();
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(Order order)
    {
      order.carID = Convert.ToInt32(Request.Form["carID"]);
      order.userID = order.userID;
      order.dateStart = Convert.ToDateTime(Request.Form["datestart"]);
      order.dateEnd = Convert.ToDateTime(Request.Form["dateend"]);
      db.Orders.Add(order);
      db.SaveChanges();
      var userEmail = Request.Form["userEmail"];
      EmailService.SendEmailAsync(order, userEmail);
      return RedirectToAction("Index", "Home");
    }

    //[Authorize]
    //[HttpPost]
    //public async Task<ActionResult> SendMessage(Order order)
    //{
    //  EmailService emailService = new EmailService();
    //  await EmailService.SendEmailAsync(order);
    //  return RedirectToAction("Index", "Home");
    //}

    [Authorize(Users = "ukalinets@gmail.com")]
    public ActionResult OrdersList()
    {
      IEnumerable<Order> orders = db.Orders;
      ViewBag.Orders = orders;
      ViewBag.Message = "List of all placed orders";
      return View();
    }

    // GET: Car/Edit/5
    [Authorize(Users = "ukalinets@gmail.com")]
    [HttpGet]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return HttpNotFound();
      }
      Order order = db.Orders.Find(id);
      if (order != null)
      {
        return View(order);
      }
      return HttpNotFound();
    }

    // POST: Car/Edit/6
    [Authorize(Users = "ukalinets@gmail.com")]
    [HttpPost]
    public ActionResult Edit(Order order)
    {
      db.Entry(order).State = EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("OrdersList");
    }

    [Authorize(Users = "ukalinets@gmail.com")]
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Order order = db.Orders.Find(id);
      IEnumerable<Order> orders = db.Orders;
      ViewBag.Orders = orders;
      return View(order);
    }

    // POST: Car/Delete/5
    [Authorize(Users = "ukalinets@gmail.com")]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Order order = db.Orders.Find(id);
      db.Orders.Remove(order);
      db.SaveChanges();
      return RedirectToAction("OrdersList");
    }
  }
}