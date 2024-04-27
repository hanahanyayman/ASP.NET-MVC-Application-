using Final_Project.Models;
using Final_Project.Models.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        Company Db=new Company();
        public IActionResult Index()
        {
            return View(Db.Products.ToList());
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.cards = Db.Cards.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult New(Product pro)
        {
            if (ModelState.IsValid == true)
            // if(emp.Name != null && emp.Salary > 3000)
            {
                try
                {
                    // throw new Exception("My Message");
                    Db.Add(pro);
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Name", ex.Message);

                }

            }
            //else
            //{
            ViewBag.cards = Db.Cards.ToList();
            return View("New", pro);
            // }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.cards = Db.Cards.ToList();
            return View(Db.Products.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Product pro, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                Product OldPro = Db.Products.FirstOrDefault(E => E.Id == id);
                OldPro.Name = pro.Name;
                OldPro.Quantity = pro.Quantity;
               // OldPro.CardId = pro.CardId;
                OldPro.Image = pro.Image;
                //Db.Employees.Update(emp);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cards = Db.Cards.ToList();

            return View("Edit", pro);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            return View(Db.Products.Find(id));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product p= Db.Products.FirstOrDefault(S=>S.Id==id);
            Db.Products.Remove(p);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult RequestProduct()
        {
            return View(Db.ProductsCards.ToList());
        }
        [HttpPost]
        public IActionResult RequestProduct(ProductsCard pro)
        {
            if (ModelState.IsValid)
            {
                Product OldPro = Db.Products.FirstOrDefault(E => E.Id == pro.Id);
                if (pro.Quatity <=pro.RemainingQuatity)
                {
                    OldPro.Quantity =pro.RemainingQuatity-pro.Quatity;
                    pro.RemainingQuatity=OldPro.Quantity;
                    pro.isValid = true;
                }
                else if(pro.Quatity == 0|| pro.RemainingQuatity==0)
                {
                    pro.isValid = false;
                    OldPro.Quantity = 0;
                }
                else
                {
                    pro.Quatity = OldPro.Quantity;
                    OldPro.Quantity = pro.RemainingQuatity = 0;
                    pro.isValid = false;
                }
                Db.SaveChanges();
                return RedirectToAction("RequestProduct", Db.ProductsCards.ToList());
            }
            //ViewBag.requests = Db.ProductsCards.ToList();
            return View("RequestProduct", Db.ProductsCards.ToList());
        }
    }
}
