﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NatureFresh.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Username { get; set; }
        public string Password {get;set; }
        public int? Roles = 1; 
    }
}