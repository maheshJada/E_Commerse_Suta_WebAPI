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
        bool ForgotPassword(ForgotClass forgotClass);
        bool productsBuy(products _product);
        IEnumerable<products> ProductDeatils(int ID);
        // bool ProductUpdate(products Product_details);
        IEnumerable<products> ProductIDGreterZero();
        IEnumerable<products> ProductIdFound(int Id);
        IEnumerable<products> Category(int CategaryID);

        

        bool DeleteProductBuy(int Id);  
    }
}
