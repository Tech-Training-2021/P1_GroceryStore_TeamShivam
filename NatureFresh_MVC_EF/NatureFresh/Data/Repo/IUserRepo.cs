using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Repo
{
    interface IUserRepo
    {
        IEnumerable<User> GetUser();
        //User GetUserById(int id);
        int AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(int id);
        //UserAddress GetUserAddress(int id);
        void Save();

    }


}
