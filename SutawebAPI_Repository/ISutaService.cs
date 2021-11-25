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

        /// <summary>
        /// here i will perform the operations  
        /// 1.getsutadetails() will be registration
        /// 2.InsertCustomerDetails it will insert tha data
        /// 3.while we are opeining website it will ask login i.e LoginCustomer()
        /// 4.if we forgot the password then we will use ForgotPassword() to change the password
        /// 5.if we you want add the products to the product we use productsBuy()
        /// 6. productdeatils()  it will display whose product Original Price>offerprice
        /// 7.ProductIDGreterZero() will returns the who is greterthan id is zero it will diplay
        /// 8.ProductIdFound() it will display particular product based on productid
        /// 9.CategoryData() it will display whole data in ihe category table
        /// 10.categoryNameFound() it will display particular category based on CategoryName
        /// 11.categoryUpdate() if you want to change the name by using id we use this method
        /// </summary>
        IEnumerable<Suta> GetSutaDetails();
        bool InsertCustomerDetails(Suta Cust_deatils);
        bool LoginCustomer(string Name, string Password);
        bool ForgotPassword(ForgotClass forgotClass);
        bool productsBuy(products _product);
        IEnumerable<products> ProductDeatils(int ID);
        // bool ProductUpdate(products Product_details);
        IEnumerable<products> ProductIDGreterZero();
        IEnumerable<products> ProductIdFound(int Id);
        bool DeleteProductBuy(int Id);
        // IEnumerable<products> Category();
        IEnumerable<Category> CategoryData();

        //IEnumerable<Category> CategoryData();
        bool CategoryAdd(Category Category_Details);
        IEnumerable<Category> categoryNameFound(string CatagoryName);
        bool categoryUpdate(CaregaryUpdateClass updated); 
    }
}
