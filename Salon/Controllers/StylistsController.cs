using Microsoft.AspNetCore.Mvc;
using Salon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Salon.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly SalonContext _db;

    public SalonsController(SalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Salon> model = _db.Salons.ToList();
      model.Sort((x, y) => string.Compare(x.Type, y.Type));
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Salon salon)
    {
      _db.Salons.Add(salon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Salon thisSalon = _db.Salons.FirstOrDefault(salone => salone.SalonId == id);
      thisSalon.Clients = _db.Clients.Where(client => client.SalonId == id).ToList();
      return View(thisSalon);
    }

    public ActionResult Edit(int id)
    {
      var thisSalon = _db.Salons.FirstOrDefault(salon => salon.SalonId == id);
      return View(thisSalon);
    }

    [HttpPost]
    public ActionResult Edit(Salon salon)
    {
      _db.Entry(salon).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSalon = _db.Salons.FirstOrDefault(salon => salon.SalonId == id);
      return View(thisSalon);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSalon = _db.Salons.FirstOrDefault(salon => salon.SalonId == id);
      _db.Salons.Remove(thisSalon);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}