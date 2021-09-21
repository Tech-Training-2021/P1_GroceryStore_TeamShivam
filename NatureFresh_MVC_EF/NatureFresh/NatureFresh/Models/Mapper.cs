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

        public static NatureFresh.Models.GetAllOrders Map(Data.Entities.Order order)
        {
            return new GetAllOrders()
            {
                Id = order.Id,
                Users = (int)order.Users,
                Outlets = (int)order.Outlets,
                UsersAddress = (int)order.UsersAddress,
                Date = order.Date,
                TotalPrice = order.TotalPrice
            };
        }

        public static Data.Entities.User DbMapView(NatureFresh.Models.Users RegCustView)
        {
            return new Data.Entities.User()
            {
                Id = RegCustView.Id,
                Name = RegCustView.Name,
                Username = RegCustView.Username,
                Password = RegCustView.Password,
                Mobile = RegCustView.Mobile,
                Email = RegCustView.Email,
                Roles = RegCustView.Roles
            };
        }

        public static Data.Entities.UserAddress DbAddressMapView(NatureFresh.Models.Users RegCustAddressView)
        {
            return new Data.Entities.UserAddress()
            {
                Id = RegCustAddressView.UsrAddId,
                UserId = RegCustAddressView.UserId,
                Address1 = RegCustAddressView.Address1,
                Address2 = RegCustAddressView.Address2,
                Address3 = RegCustAddressView.Address3,
                Pincode = RegCustAddressView.Pincode,
                City = RegCustAddressView.City,
                State = RegCustAddressView.State
            };
        }
    }
}