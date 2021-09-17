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
            return View("userAddress",Mapper.Map(userAdd));
        }


    }
}