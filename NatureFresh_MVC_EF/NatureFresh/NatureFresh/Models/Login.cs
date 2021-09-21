using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NatureFresh.Models
{
    public class Login
    {
        [ForeignKey("CustId")]
        public int? CustId { get; set; }
        [Required(ErrorMessage = "Username Cannot Be Blank")]
        public string Username { get; set; }
        //

        [Required(ErrorMessage = "Password Cannot Be Blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}