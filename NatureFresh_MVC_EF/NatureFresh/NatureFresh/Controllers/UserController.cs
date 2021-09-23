using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Entities;
using Data.Repo;
using System.Web.Mvc;
using NatureFresh.Models;
using System.Net;

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

        public ActionResult Index()
        {

            return View();
            //var usr = repo.GetUser();
            //var data = new List<NatureFresh.Models.Users>();
            //foreach (var p in usr)
            //{
            //    data.Add(Mapper.Map(p));
            //}
            //return View(data);
        }

        public ActionResult GetUserById(int id)
        {
            id = Convert.ToInt32(Session["UserID"]);
            var usr = repo.GetUserById(id);

            return View("UserProfile",usr);
        }

        public ActionResult GetUserByUsername(string uname)
        {
            uname = Session["UsernameSS"].ToString();

            NatureFresh.Models.Users usr = Mapper.Map(repo.GetUserByUname(uname));
            NatureFresh.Models.UserAddress tmp = usr.useraddress.FirstOrDefault();

            usr.Address1 = tmp.Address1;
            usr.Address2 = tmp.Address2;
            usr.Address3 = tmp.Address3;
            usr.City = tmp.City;
            usr.State = tmp.State;
            usr.Pincode = tmp.Pincode;
            return View("UserProfile", usr);

        }

        public ActionResult GetUserAddress(int id)
        {
            var userAdd = repo.GetUserAddress(id);
            //return View("userAddress",Mapper.Map(userAdd));
            return View("userAddress", userAdd);
        }

        public ActionResult DeleteUser()
        {
            string username = Session["UsernameSS"].ToString();
            var res = db.Users.Where(x => x.Username == username).FirstOrDefault();
            var orderRes = db.Orders.Where(x => x.Users == res.Id);
            var cartRes = db.Carts.Where(x => x.CustomerId == res.Id);
            var outletRes = db.Outlets.Where(x => x.Users == res.Id);
            var addressRes = db.UserAddresses.Where(x => x.UserId == res.Id);

            if (orderRes != null)
            {
                db.Orders.RemoveRange(orderRes);
                db.SaveChanges();
            }
            if (cartRes != null)
            {
                db.Carts.RemoveRange(cartRes);
                db.SaveChanges();
            }
            if (outletRes != null)
            {
                db.Outlets.RemoveRange(outletRes);
                db.SaveChanges();
            }
            if (addressRes != null)
            {
                db.UserAddresses.RemoveRange(addressRes);
                db.SaveChanges();
            }
            if (res != null)
            {
                db.Users.Remove(res);
                Logout();
                db.SaveChanges();
            }
            return View("register");
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
                Session["UserID"] = id;
                objRegModel.UserId = id;
                repo.AddUserAddress(Mapper.DbAddressMapView(objRegModel));
                repo.Save();
                Session["UsernameSS"] = objRegModel.Username.ToString();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = repo.GetUserById(id);
            return View(Mapper.MapUVM(user));
        }

        [HttpPost]
        public ActionResult Edit(Users UsersObj)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateUser(Mapper.MapMVU(UsersObj));
                Session["UserID"] = UsersObj.Id;
                Session["UsernameSS"] = UsersObj.Username;
                return RedirectToAction("Index");
            }
            return View(UsersObj);
        }

        public ActionResult EditAddress(int id)
        {
            var user = repo.GetUserById(id);
            return View(Mapper.ModelAddressEntity(user));
        }

        [HttpPost]
        public ActionResult EditAddress(NatureFresh.Models.UserAddress UsersObj)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateUser(Mapper.EntityAddressModel(UsersObj));
                Session["UserID"] = UsersObj.Id;
                Session["UsernameSS"] = UsersObj.Username;
                return RedirectToAction("Index");
            }
            return View(UsersObj);
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