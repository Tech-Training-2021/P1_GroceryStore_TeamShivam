
using Data.Entities;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Data.Repo
{
    public class userRepo : IUserRepo
    {
        private  NatureFreshDB db;

        public userRepo(NatureFreshDB db)
        {
            this.db = db;
        }
        public int AddUser(User user)
        {
            db.Users.Add(user);
            Save();
            return db.Users.Local[0].Id;
        }
        public void AddUserAddress(UserAddress usrAddObj)
        {
            db.UserAddresses.Add(usrAddObj);
            Save();
        }

        public void getName(int id)
        {
            //var result = (from item in User select item.Role.Name WHERE item.Id == id);
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                Save();
            }
            else
                throw new ArgumentException("User not found");
        }

        public IEnumerable<User> GetUser()
        {
            return db.Users
                    //.Include("Role")
                    .ToList();
        }

        public void UpdateUser(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                //db.Users.Update();
                Save();
            }
            else
                throw new ArgumentException("User not found");

        }
        public void Save()
        {
            db.SaveChanges();
        }

        public User GetUserById(int id)
        {
            if (id > 0)
            {
                var usr = db.Users
                    //.Include("Role")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
                UserAddress tmp = usr.UserAddresses.FirstOrDefault();
                string tmp3 = tmp.State;
                var tmp2 = usr.UserAddresses.FirstOrDefault();
                if (usr != null)
                    return usr;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }

        }

        public UserAddress GetUserAddress(int id)
        {
            if (id > 0)
            {
                var usrAdddress = db.UserAddresses
                    .Where(uAdd => uAdd.Id == id)
                    .FirstOrDefault();
                if (usrAdddress != null)
                    return usrAdddress;
                else
                    return null;
            }
            else
            {
                throw new ArgumentException("Id cannot be less than 0");
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return db.Orders.ToList();

        }
        //public void UpdateUser(int id)
        //{
        //    throw new NotImplementedException();
        //}
        
    }
}
