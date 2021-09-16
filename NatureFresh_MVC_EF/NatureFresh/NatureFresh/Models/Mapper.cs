using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NatureFresh.Models
{
    public class Mapper
    {
        public static NatureFresh.Models.Users Map(Data.Entities.User user)
        {
            return new Users()
            {
                Id = user.Id,
                Name = user.Name,
                Mobile = user.Mobile,
                Username = user.Username,
                Password = user.Password,
                Roles = user.Roles
            };
        }
    }
}