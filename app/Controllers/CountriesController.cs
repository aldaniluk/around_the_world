using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using app.Models;

namespace app.Controllers
{
    public class CountriesController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        //return list of all countries
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        //return all info(from differents tables) about country by id
        public ActionResult ShowCountry(int id)
        {
            return View(db.Countries.Find(id)); 
        }
    }
}