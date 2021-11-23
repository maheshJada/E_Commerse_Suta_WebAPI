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
        public int Cartlitems { get; set; }
        public string Address { get; set; }
        public int Pincode { get; set; }
        public string state { get; set; }


    }
    public class products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OriginalPrice { get; set; }
        public int OfferPrice { get; set; }
        public int CategaryID { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
    }

    public class ForgotClass
    {

        public string Email { get; set; }
        public string Password { get; set; }
        
    }

}
