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
        User GetUserById(int id);
        void AddUser(User prd);
        void UpdateUser(int id);
        void DeleteUser(int id);
        void Save();

    }
}
