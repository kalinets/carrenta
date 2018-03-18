using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Carrenta.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Carrenta.Controllers
{
  [Authorize(Users = "ukalinets@gmail.com")]
  public class CarController : Controller
  {
    DataBaseContext db = new DataBaseContext();

    [AllowAnonymous]
    public ActionResult CarList()
    {
      // получаем из бд все объекты Car
      IEnumerable<Car> cars = db.Cars;
      // передаем все объекты в динамическое свойство Cars в ViewBag
      ViewBag.Cars = cars;
      // возвращаем представление
      ViewBag.Message = "List of all available cars";
      return View();
    }

    public ActionResult ManageCarList()
    {
      IEnumerable<Car> cars = db.Cars;
      ViewBag.Cars = cars;
      ViewBag.Message = "Manage all cars";
      return View();
    }
    
    [HttpGet]
    public ActionResult AddCar(int? id)
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult AddCar(Car car, HttpPostedFileBase carImage = null)
    {
      if (ModelState.IsValid)
      {
        car.brand = Request.Form["carName"];
        car.year = Convert.ToInt32(Request.Form["carYear"]);
        car.body = Request.Form["carBody"];
        car.price = Convert.ToDecimal(Request.Form["carPrice"]);
        // добавляем картинку в базу
        if (carImage != null)
        {
          car.imageMimeType = carImage.ContentType;
          car.imageData = new byte[carImage.ContentLength];
          carImage.InputStream.Read(car.imageData, 0, carImage.ContentLength);
        }
        db.Cars.Add(car);
        db.SaveChanges();
        return RedirectToAction("ManageCarList");
      }
      else
      {
        return RedirectToAction("ManageCarList");
      }
    }

    // GET: Car/Edit/5
    [HttpGet]
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return HttpNotFound();
      }
      Car car = db.Cars.Find(id);
      if (car != null)
      {
        return View(car);
      }
      return HttpNotFound();
    }

    // POST: Car/Edit/6
    [HttpPost]
    public ActionResult Edit(Car car)
    {
      db.Entry(car).State = EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("ManageCarList");
    }

    // GET: Car/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Car car = db.Cars.Find(id);
      if (car == null)
      {
      }
      IEnumerable<Car> cars = db.Cars;
      ViewBag.Cars = cars;
      return View(car);
    }

    // POST: Car/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Car car = db.Cars.Find(id);
      //IEnumerable<Order> orders = db.Orders.Where(o => o.carID == id);
      //db.Orders.RemoveRange(orders);
      //db.SaveChanges();
      db.Cars.Remove(car);
      // db.Entry(car).State = EntityState.Deleted;
      db.SaveChanges();
      return RedirectToAction("ManageCarList");
    }

    protected override void Dispose(bool disposing)
    {
      db.Dispose();
      base.Dispose(disposing);
    }
  }
}