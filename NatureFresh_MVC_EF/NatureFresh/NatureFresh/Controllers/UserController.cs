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
            return View("index",Mapper.Map(usr));
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
            else if (db.Users.Any(x => x.Email == objRegModel.Email))
            {
                ViewBag.Notification = "This Email already exists";
                return View();
            }
            else if (ModelState.IsValid)
            {
                User objRegCust = new User();
                int id = repo.AddUser(Mapper.DbMapView(objRegModel));           //repo - db - regcustomers- local -[0].id
                objRegModel.UserId = id;
                repo.AddUserAddress(Mapper.DbAddressMapView(objRegModel));
                repo.Save();
                Session["UsernameSS"] = objRegModel.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            Login objLoginModel = new Login();
            return View(objLoginModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login objLoginModel)
        {
            var checkLogin = db.Users.Where(x => x.Username.Equals(objLoginModel.Username) && x.Password.Equals(objLoginModel.Password)).FirstOrDefault();

            if (checkLogin != null)
            {
                Session["UsernameSS"] = objLoginModel.Username.ToString();
                Session["UserId"] = checkLogin.Id;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Wrong Username or Password";
            }
            return View();
        }

        public void getName(int id)
        {

        }


        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}