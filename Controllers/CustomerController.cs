using Final_Project.Models;
using Final_Project.Models.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Linq;
using System.Security.Claims;

namespace Final_Project.Controllers
{
    public class CustomerController : Controller
    {
        Company Db = new Company();
      
        public IActionResult TestQuentity(int Quatity, int RemainingQuatity)
        {
            //Your Own Logic
            if (Quatity <= RemainingQuatity)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult Products()
        {
            return View(Db.Products.ToList());
        }
        [HttpGet]
        public IActionResult AddToCard()
        {
            ViewBag.cards=Db.Cards.ToList();
            ViewBag.products=Db.Products.ToList();
            ViewBag.remainQuentity=Db.Products.Select(s=> s.Quantity).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddToCard(ProductsCard p)
        {
            if (ModelState.IsValid == true)
            {
                //try
                //{
                    Db.Add(p);
                    Db.SaveChanges();
                    return RedirectToAction("Products");
                //}
                //catch (Exception ex)
                //{
                //   // ModelState.AddModelError("Name", ex.Message);
                //}
            }
            ViewBag.cards = Db.Cards.ToList();
            ViewBag.products = Db.Products.ToList();
            ViewBag.remainQuentity = Db.Products.Select(s => s.Quantity).ToList();
            return View("AddToCard");
        }
        [HttpGet]
        public IActionResult ShowMyCards()
        {
            return View(Db.ProductsCards.ToList());
        }
        [Authorize]
        public IActionResult ShowProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = Db.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(userId));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
            // return View(Db.Users.Find(id));
        }
        [Authorize]
        public IActionResult Edit()
        {
            ViewBag.cards = Db.Cards.ToList();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = Db.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(userId));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
            //return View(Db.Users.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(User user, [FromRoute] int id)
        {

            if (ModelState.IsValid)
            {
                User OldUser = Db.Users.FirstOrDefault(E => E.Id == id);
                OldUser.Name = user.Name;
                OldUser.Age = user.Age;
                //OldUser.CardId = user.CardId;
                OldUser.Image = user.Image;
                Db.SaveChanges();
                return RedirectToAction("ShowProfile");
            }
            ViewBag.cards = Db.Cards.ToList();
            return View("Edit", user);
        }
        [Authorize]
        public IActionResult Details()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = Db.Users.FirstOrDefault(u => u.Id == Convert.ToInt32(userId));
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
            // return View(Db.Users.Find(id));
        }
        [HttpGet]
        public IActionResult DetailsProduct(int id)
        {
            return View(Db.Products.Find(id));
        }
        [HttpGet]
        public IActionResult DeleteFromCard(int id)
        {
            ProductsCard p = Db.ProductsCards.FirstOrDefault(S => S.Id == id);
            Db.ProductsCards.Remove(p);
            Db.SaveChanges();
            return RedirectToAction("ShowMyCards");
        }
    }
}
