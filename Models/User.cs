using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebProject.Models
{
    public class User
    {
        public int Uid { get; set; }
        public string Uname { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
        public int MyProperty { get; set; }
    }
}
