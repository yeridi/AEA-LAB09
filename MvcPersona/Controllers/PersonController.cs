using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPersona.Models;

namespace MvcPersona.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {

            if (Session["People"] == null)
            {
                List<Person> people = new List<Person>();
                people.Add(new Person { ID = 01,FirstName = "Yeridi", LastName = "Huaman", BirthDay = DateTime.Now, IsTecsup = true});
                people.Add(new Person { ID = 02, FirstName = "Miguel", LastName = "Melgarejo", BirthDay = DateTime.Now, IsTecsup = false});
                Session["People"] = people;
            }

            return View(Session["People"]);
        }

        public ActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                if (Session["People"] == null)
                    Session["People"] = new List<Person>();
                // TODO: Add insert logic here
                ((List<Person>)Session["People"]).Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult Details(int id)
        {

            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }



        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            var model = ((List<Person>)Session["People"]).Where(x => x.ID == id).FirstOrDefault();

            return View(model);
        }


        [HttpPost]
        public ActionResult Delete(int id, Person model)
        {
            try { 
            
                ((List<Person>)Session["People"]).Remove(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}