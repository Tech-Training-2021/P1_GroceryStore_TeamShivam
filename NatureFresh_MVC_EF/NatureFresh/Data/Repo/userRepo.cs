
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

        public User UpdateUser(User user)
        {
            User UpdateUserAdd = (from u in db.Users
                               where u.Id == user.Id
                               select u).FirstOrDefault();
            UpdateUserAdd.Name = user.Name;
            UpdateUserAdd.Username = user.Username;
            UpdateUserAdd.Password = user.Password;
            UpdateUserAdd.Email = user.Email;
            UpdateUserAdd.Mobile = user.Mobile;
            Save();
            return user;
        }

        public UserAddress UpdateUserAddress(User user)
        {
            UserAddress UpdateUserAdd = (from u in db.UserAddresses
                               where u.Id == user.Id
                               select u).FirstOrDefault();
            foreach (var uadd in user.UserAddresses) {
                UpdateUserAdd.Address1 = uadd.Address1;
                UpdateUserAdd.Address2 = uadd.Address2;
                UpdateUserAdd.Address3 = uadd.Address3;
                UpdateUserAdd.City = uadd.City;
                UpdateUserAdd.State = uadd.State;
                UpdateUserAdd.Pincode = uadd.Pincode;
            };
            Save();
            return UpdateUserAdd;
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

        public User GetUserByUname(string username)
        {
            if (username != null)
            {
                var usr = db.Users
                    //.Include("Role")
                    .Where(p => p.Username == username)
                    .FirstOrDefault();
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
