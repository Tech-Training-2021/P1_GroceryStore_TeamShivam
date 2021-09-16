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
        public void AddUser(User user)
        {
            db.Users.Add(user);
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


        //public void UpdateUser(int id)
        //{
        //    throw new NotImplementedException();
        //}
        
    }
}
