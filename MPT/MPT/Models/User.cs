using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPT.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string HasPassword { get; set; }
    }
}