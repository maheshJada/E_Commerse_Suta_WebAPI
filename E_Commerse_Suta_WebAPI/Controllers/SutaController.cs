using Microsoft.AspNetCore.Mvc;
using SutaWebAPI_Model;
using SutawebAPI_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerse_Suta_WebAPI.Controllers
{
    public class SutaController : ControllerBase
    {
        private readonly ISutaService _sutaService;
        public SutaController(ISutaService sutaService)
        {
            _sutaService = sutaService;
        }
        public IEnumerable<Suta> GetSutaDetails()
        {
            return _sutaService.GetSutaDetails();
        }
       
        [HttpPost, Route("api/signup")]
        public IEnumerable<Suta> InsertCustomerDetails(Suta inserteddata)
        {
            if (_sutaService.InsertCustomerDetails(inserteddata))
            {
                return _sutaService.GetSutaDetails();
            }

            return Enumerable.Empty<Suta>();
        }


        [HttpPost, Route("api/login")]

        public bool LoginCustomer(string Name, string Password)
        {
            if (_sutaService.LoginCustomer(Name,Password))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
       

        [HttpPatch, Route("api/ForgotPassword")]

        public bool ForgotttPassword(ForgotClass forgotClass)
        {
            if (_sutaService.ForgotPassword(forgotClass))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [HttpGet, Route("api/Products")]
        public IEnumerable<products> ProductIDGreterZero()
        {
            return _sutaService.ProductIDGreterZero();
        }


        [HttpGet, Route("api/Products/ProductIdFound")]
        public IEnumerable<products> ProductIdFound(int ID)
        {
            return _sutaService.ProductIdFound(ID);
        }


        [HttpPut, Route("api/ProductAdd")]
        public bool productsBuy(products EnterValidData)
        {
            if (_sutaService.productsBuy(EnterValidData))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
       
        [HttpPost, Route("api/ProductComapare/:id")]
        public IEnumerable<products> GetProducts(int ID)
        {
            return _sutaService.ProductDeatils(ID);
        }


        [HttpDelete, Route("api/ProductsDelete/:Id")]
        public bool DeleteProductBuy(int Id)
        {
            if (_sutaService.DeleteProductBuy(Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet, Route("api/CategoryData")]
        public IEnumerable<Category> CategoryData()
        {
            return _sutaService.CategoryData();
        }

        [HttpPut, Route("api/categoryAdd")]
        public bool CategoryAdd(Category EnterValidData)
        {
            if (_sutaService.CategoryAdd(EnterValidData))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        [HttpGet, Route("api/Category/catogoryIdFound")]
        public IEnumerable<Category> categoryNameFound(string CatagoryName)
        {
            return _sutaService.categoryNameFound(CatagoryName);
        }

        [HttpPatch, Route("api/categoryUpdate")]
        public bool categoryUpdate(CaregaryUpdateClass updated)
        {
            if (_sutaService.categoryUpdate(updated))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
