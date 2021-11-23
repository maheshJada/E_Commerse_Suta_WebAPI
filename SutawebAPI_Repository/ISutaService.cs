using SutaWebAPI_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SutaWebAPI_Common;

namespace SutawebAPI_Repository
{
    public interface ISutaService
    {
        IEnumerable<Suta> GetSutaDetails();
        bool InsertCustomerDetails(Suta Cust_deatils);
        bool LoginCustomer(string Name, string Password);
        bool productsBuy(products _product);
        bool ForgotPassword(ForgotClass forgotClass);
        bool DeleteProductBuy(int ProductRating);  
    }
}
