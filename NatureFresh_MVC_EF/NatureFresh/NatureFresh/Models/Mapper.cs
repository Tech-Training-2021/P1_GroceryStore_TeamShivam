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

        public static NatureFresh.Models.UserAddress Map(Data.Entities.UserAddress uAddress)
        {
            return new UserAddress()
            {
                Id = uAddress.Id,
                Address1 = uAddress.Address1,
                Address2 = uAddress.Address2,
                Address3 = uAddress.Address3,
                Pincode = uAddress.Pincode.ToString(),
                City = uAddress.City,
                State = uAddress.State
            };
        }
    }
}