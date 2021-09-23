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
            List<UserAddress> address = new List<UserAddress>();
            UserAddress uAdd = new UserAddress();
            foreach (var temp in user.UserAddresses)
            {
                uAdd.Address1 = temp.Address1;
                uAdd.Address2 = temp.Address2;
                uAdd.Address3 = temp.Address3;
                uAdd.City = temp.City;
                uAdd.Pincode = temp.Pincode;
                uAdd.State = temp.State;
                address.Add(uAdd);
            }

            return new Users()
            {
                Id = user.Id,
                Name = user.Name,
                Mobile = user.Mobile,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                Roles = user.Roles,
                useraddress = address
            };
        }

        public static NatureFresh.Models.Users MapUVM(Data.Entities.User user)
        {
            return new NatureFresh.Models.Users()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                Mobile = user.Mobile,
                Email = user.Email
                
            };
        }

        public static Data.Entities.User MapMVU(NatureFresh.Models.Users user)
        {
            return new Data.Entities.User()
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                Password = user.Password,
                Mobile = user.Mobile,
                Email = user.Email
            };
        }

        public static NatureFresh.Models.UserAddress ModelAddressEntity(ICollection<Data.Entities.UserAddress> user)
        {
            //List<User>
            NatureFresh.Models.UserAddress obj = new NatureFresh.Models.UserAddress();
            foreach(var item in user)
            {
                obj.Id = item.Id;
                obj.Address1 = item.Address1;
                obj.Address2 = item.Address2;
                obj.Address3 = item.Address3;
                obj.Pincode = item.Pincode;
                obj.City = item.City;
                obj.State = item.State;
            }
            return obj;
        }

        public static Data.Entities.UserAddress EntityAddressModel(NatureFresh.Models.UserAddress user)
        {
            return new Data.Entities.UserAddress()
            {
                Id = user.Id,
                Address1 = user.Address1,
                Address2 = user.Address2,
                Address3 = user.Address3,
                City = user.City,
                State = user.State,
                Pincode = user.Pincode
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

        public static Data.Entities.User DbMapView(NatureFresh.Models.Users usr)
        {
            return new Data.Entities.User()
            {
                Id = usr.Id,
                Name = usr.Name,
                Username = usr.Username,
                Password = usr.Password,
                Mobile = usr.Mobile,
                Email = usr.Email,
                Roles = usr.Roles
            };
        }

        public static Data.Entities.UserAddress DbAddressMapView(NatureFresh.Models.Users RegCustAddressView)
        {
            return new Data.Entities.UserAddress()
            {
                Id =RegCustAddressView.UsrAddId,
                UserId = RegCustAddressView.UserId,
                Address1 = RegCustAddressView.Address1,
                Address2 = RegCustAddressView.Address2,
                Address3 = RegCustAddressView.Address3,
                Pincode = RegCustAddressView.Pincode,
                City = RegCustAddressView.City,
                State = RegCustAddressView.State
            };
        }

        public static Data.Entities.Cart DbCartMapView(NatureFresh.Models.CartModel CartModelObj)
        {
            return new Data.Entities.Cart()
            {
                Id = CartModelObj.Id,
                CustomerId = (int)CartModelObj.CustomerId,
                Quantity = (int)CartModelObj.Quantity,
                Weight = (int)CartModelObj.Weight,
                ItemId = (int)CartModelObj.ItemId
            };
        }

        public static NatureFresh.Models.Users TestMapper(Data.Entities.UserAddress usr)
        {
            return new NatureFresh.Models.Users()
            {
                Address1 = usr.Address1,
                Address2 = usr.Address2,
                Address3 = usr.Address3,
                City = usr.City,
                State = usr.State,
                Pincode = usr.Pincode,
            };
        }
    }
}