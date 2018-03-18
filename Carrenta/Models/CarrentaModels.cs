using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Carrenta.Models
{
  public class Car
  {
    public int id { get; set; }
    public string brand { get; set; }
    public int year { get; set; }
    public string body { get; set; }
    public decimal price { get; set; }
    public byte[] imageData { get; set; }
    public string imageMimeType { get; set; }
  }

  public class Order
  {
    public int id { get; set; }
    public int carID { get; set; }
    public string userID { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd'\'MM'\'yyyy}", ApplyFormatInEditMode = true)]
    public DateTime dateStart { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd'\'MM'\'yyyy}", ApplyFormatInEditMode = true)]
    public DateTime dateEnd { get; set; }
  }

  public class DataBaseContext : DbContext
  {
    public DataBaseContext() : base("DefaultConnection") { }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Order> Orders { get; set; }
  }
}