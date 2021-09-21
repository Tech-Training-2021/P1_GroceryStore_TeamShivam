using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Entities;
using Data.Repo;
using System.Web.Mvc;
using NatureFresh.Models;

namespace NatureFresh.Controllers
{
    public class UserController : Controller
    {
        NatureFreshDB db = new NatureFreshDB();

        Data.Repo.userRepo repo;


        public UserController()
        {
            repo = new userRepo(new NatureFreshDB());

        }

        // GET: Adaa
        public ActionResult Index()
        {
            var usr = repo.GetUser();
            var data = new List<NatureFresh.Models.Users>();
            foreach (var p in usr)
            {
                data.Add(Mapper.Map(p));
            }
            return View(data);
        }

        public ActionResult GetUserById(int id)
        {
            var usr = repo.GetUserById(id);
            return View(Mapper.Map(usr));
        }

        public ActionResult GetUserAddress(int id)
        {
            var userAdd = repo.GetUserAddress(id);
            //return View("userAddress",Mapper.Map(userAdd));
            return View("userAddress", userAdd);
        }
        public ActionResult GetAllOrders()
        {
            var order = repo.GetAllOrders();
            var orders = new List<Data.Entities.Order>();
            foreach (var odr in order)
            {
                orders.Add(odr);
            }
            return View("allOrders",orders);
        }


        public ActionResult Register()
        {
            Users objRegModel = new Users();
            return View(objRegModel);
        }

        [HttpPost]
        public ActionResult Register(Users objRegModel)
        {
            if (db.Users.Any(x => x.Username == objRegModel.Username))
            {
                ViewBag.Notification = "This Account is already existed";
                return View();
            }
            else if (ModelState.IsValid)
            {
                User objRegCust = new User();
                int id = repo.AddUser(Mapper.DbMapView(objRegModel));           //repo - db - regcustomers- local -[0].id
                objRegModel.UserId = id;
                repo.AddUserAddress(Mapper.DbAddressMapView(objRegModel));
                repo.Save();

                Session["IdSS"] = objRegModel.Id.ToString();
                Session["UsernameSS"] = objRegModel.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            return View();

        }


    }
}