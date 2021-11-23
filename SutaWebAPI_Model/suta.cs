using System;
using SutaWebAPI_Common;
using SutaWebAPI_Model;

namespace SutaWebAPI_Model
{
    public class Suta
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

    }
    public class products
    {
     
        public string ProductName { get; set; }
        public string ProductRating { get; set; }
        public string ProductCost { get; set; }
    }

    public class ForgotClass
    {

        public string Email { get; set; }
        public string Password { get; set; }
        //public string ProductCost { get; set; }
    }

}
