using Microsoft.AspNetCore.Mvc;
using MyContactBook.Database.Repository;
using MyContactBook.Models;
using System;

namespace MyContactBook.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            try
            {
                var people = _repo.GetAllPeople();
                return View(people);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet("display")]
        public IActionResult Display(Person per)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var person = _repo.GetPerson(per.Id);
                    return View(person);
                }
                return View("Error");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet("edit")]
        public IActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View(new Person());
                }
                else
                {
                    var person = _repo.GetPerson((int)id);
                    return View(person);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpPost("edit")]
        public IActionResult Edit(Person person)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.UpdatePerson(person);
                    _repo.Save();
                    return RedirectToAction("index");
                }
                return View(person);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        [HttpGet("remove")]
        public IActionResult Remove(int id)
        {
            try
            {
                _repo.RemovePerson(id);
                _repo.Save();
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}