using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MPT.Models
{
    public class User
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HasPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}