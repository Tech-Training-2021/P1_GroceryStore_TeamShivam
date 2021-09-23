using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NatureFresh.Models
{
    public class Users
    {
        private const string emailRegex = @"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})";

        [System.Web.Mvc.HiddenInput]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Name Cannot Be Blank")]
        [StringLength(maximumLength: 20, ErrorMessage = "Name Should be between 2 to 20 characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username Cannot Be Blank")]
        [StringLength(maximumLength: 20, ErrorMessage = "Username Should be between 3 to 20 characters", MinimumLength = 3)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Mobile Cannot Be Blank")]
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        [StringLength(maximumLength: 10, ErrorMessage = "Mobile no. Should be 10 Digits", MinimumLength = 10)]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email Cannot Be Blank")]
        [RegularExpression(emailRegex, ErrorMessage = "Your email address is not in a valid format. Example of correct format: joe.example@example.org")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Cannot Be Blank")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, ErrorMessage = "Password Should be between 5 to 20 characters", MinimumLength = 5)]      
        public string Password {get;set; }
        public int? Roles = 1;

        //Add UserAddress

        public int UsrAddId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Address1 Cannot Be Blank")]
        public string Address1 { get; set; }

        [Required(ErrorMessage = "Address2 Cannot Be Blank")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Address3 Cannot Be Blank")]
        public string Address3 { get; set; }

        [Required(ErrorMessage = "Pincode Cannot Be Blank")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "City Cannot Be Blank")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Cannot Be Blank")]
        public string State { get; set; }

    }
}