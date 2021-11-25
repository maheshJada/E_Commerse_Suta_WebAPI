using SutaWebAPI_Common;
using SutaWebAPI_Common.Exceptions;
using SutaWebAPI_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using SutawebAPI_Repository;


namespace SutawebAPI_Repository
{
    public class SutaService : ISutaService
    {
        private SqlConnection _connection;
        private SqlCommand _command;

        public SutaService()
        {
            _connection = new SqlConnection(ApplicationContext.ConnectionString);
        }

        /// <summary>
        ///     This Method is for insert the details for registration
        /// </summary>
        /// <param name="Cust_deatils"></param>
        /// <returns>inserted data</returns>
        public bool InsertCustomerDetails(Suta Cust_deatils)
        {
            bool insert = false;
            try
            {
                using (_command = new SqlCommand("insert into Users values('" + Cust_deatils.Name + "','" + Cust_deatils.Email + "','" + Cust_deatils.PhoneNumber + "','" + Cust_deatils.Gender + "','" + Cust_deatils.Password + "','" + Cust_deatils.Cartlitems + "','" + Cust_deatils.Address + "','" + Cust_deatils.Pincode + "','" + Cust_deatils.state + "')", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    insert = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return insert;
        }
      
        /// <summary>
        /// This Method is used for login 
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <returns>It will open the website</returns>
        public bool LoginCustomer(string Name, string Password)
        {
            bool IsLogin = false;
            try
            {
                using (_command = new SqlCommand(" select * from Users where Name='" + Name + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader dr = _command.ExecuteReader();
                    while (dr.Read())
                    {
                        if (Password.Equals(dr["Password"]))


                            IsLogin = true;
                    }
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return IsLogin;

        }
       
        /// <summary>
        /// This Method is for chenge the password if we forgot the password
        /// </summary>
        /// <param name="forgotClass"></param>
        /// <returns>It will change the password</returns>
        public bool ForgotPassword(ForgotClass forgotClass)
        {
            bool update = false;
            try
            {
                using (_command = new SqlCommand("update Users set Password ='" + forgotClass.Password + "' WHERE Email= '" + forgotClass.Email + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    update = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return update;
        }
      
        /// <summary>
        /// This Method is used to display all products
        /// </summary>
        /// <returns>It will display all the product</returns>
        public IEnumerable<products> ProductIDGreterZero()
        {
            List<products> _GetSuta = new List<products>();

            try
            {
                using (_command = new SqlCommand("select  * from products  ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _GetSuta.Add(new products() { ProductName = reader.GetString(1), OriginalPrice = reader.GetInt32(2), OfferPrice = reader.GetInt32(3), CategaryID = reader.GetInt32(4), Image = reader.GetString(5), Quantity = reader.GetInt32(6) });
                }
            }
            catch (Exception e1)
            {
                throw new SutaException(e1.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _GetSuta;
        }

        /// <summary>
        /// This Metod is for check the product based on productid
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>It will find the particular product</returns>
        public IEnumerable<products> ProductIdFound(int Id)
        {
            List<products> _GetSuta = new List<products>();

            try
            {
                using (_command = new SqlCommand("select  * from products where Id ='" + Id + "'  ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _GetSuta.Add(new products() { ProductName = reader.GetString(1), OriginalPrice = reader.GetInt32(2), OfferPrice = reader.GetInt32(3), CategaryID = reader.GetInt32(4), Image = reader.GetString(5), Quantity = reader.GetInt32(6) });
                }
            }
            catch (Exception e1)
            {
                throw new SutaException(e1.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _GetSuta;
        }
      
        /// <summary>
        /// This Method is used for insert the product to products table
        /// </summary>
        /// <param name="_product"></param>
        /// <returns>it will display what we are inserted products</returns>
        public bool productsBuy(products _product)
        {
            bool insert = false;
            try
            {
                using (_command = new SqlCommand("insert into products values('" + _product.ProductName + "','" + _product.OriginalPrice + "','" + _product.OfferPrice + "','" + _product.CategaryID + "','" + _product.Image + "','" + _product.Quantity + "')", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    insert = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return insert;
        }

        /// <summary>
        /// This Method is for insert the details for registration
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>It will returns the Register candidate deatils</returns>
        public IEnumerable<products> ProductDeatils(int Id)
        {
            List<products> _GetSuta = new List<products>();

            try
            {
                using (_command = new SqlCommand("select  * from products where OriginalPrice > OfferPrice AND Id ='" + Id + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _GetSuta.Add(new products() { ProductName = reader.GetString(1), OriginalPrice = reader.GetInt32(2), OfferPrice = reader.GetInt32(3), CategaryID = reader.GetInt32(4), Image = reader.GetString(5), Quantity = reader.GetInt32(6) });
                }
            }
            catch (Exception e1)
            {
                throw new SutaException(e1.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _GetSuta;
        }
        /// <summary>
        /// This Method is used for delete the product
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Delete the product based on id</returns>
        public bool DeleteProductBuy(int Id)
        {
            bool delete = false;
            try
            {
                using (_command = new SqlCommand("delete from products  where Id ='" + Id + "'", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    delete = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return delete;
        }

        //<summary>
        // This Metod is for display the CategoryData
        // </summary>
        // <returns>It will return the product Details</returns>
        public IEnumerable<Category> CategoryData()
        {
            List<Category> _GetSuta = new List<Category>();

            try
            {
                using (_command = new SqlCommand("select  * from catagory  ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _GetSuta.Add(new Category() { CatagoryName = reader.GetString(1), Catagoryimage = reader.GetString(2) });
                }
            }
            catch (Exception e1)
            {
                throw new SutaException(e1.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _GetSuta;
        }



        /// <summary>
        ///This method is used for add the Category to the database
        /// </summary>
        /// <param name="Category_Details"></param>
        /// <returns>It will returns the Added category data</returns>
        public bool CategoryAdd(Category Category_Details)
        {
            bool insert = false;
            try
            {
                using (_command = new SqlCommand("insert into catagory values('" + Category_Details.CatagoryName + "','" + Category_Details.Catagoryimage + "')", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    insert = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return insert;
        }

        /// <summary>
        /// This method is used for check the CategoryName
        /// </summary>
        /// <param name="CatagoryName"></param>
        /// <returns>It will returns CatagoryName based on id </returns>

        public IEnumerable<Category> categoryNameFound(string CatagoryName)
        {
            List<Category> _GetSuta = new List<Category>();

            try
            {
                using (_command = new SqlCommand("select  * from catagory where CatagoryName ='" + CatagoryName + "'  ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _GetSuta.Add(new Category() { CatagoryName = reader.GetString(1), Catagoryimage = reader.GetString(2) });
                }
            }
            catch (Exception e1)
            {
                throw new SutaException(e1.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _GetSuta;
        }

        /// <summary>
        /// This method is used for update the Category details
        /// </summary>
        /// <param name="updated"></param>
        /// <returns>It will return updated data</returns>
        public bool categoryUpdate(CaregaryUpdateClass updated)
        {
            bool update = false;
            try
            {
                using (_command = new SqlCommand("update catagory set CatagoryName ='" + updated.CatagoryName + "' WHERE Id= '" + updated.id + "' ", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    update = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return update;
        }

        /// <summary>
        /// This method is used for insert the Category details
        /// </summary>
        /// <param name="Categary_details"></param>
        /// <returns>It will return insertd Category data</returns>
        public bool CatagoryInsert(products Categary_details)
        {
            bool insert = false;
            try
            {
                using (_command = new SqlCommand("insert into Category values('" + Categary_details.CategaryID+ "')", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    _command.ExecuteNonQuery();

                    insert = true;
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                _connection.Close();
            }
            return insert;
        }

        /// <summary>
        /// This method is used for display the users table data
        /// </summary>
        /// <returns>It will returns the users data</returns>
        public IEnumerable<Suta> GetSutaDetails()
        {
            List<Suta> _GetSuta = new List<Suta>();

            try
            {
                using (_command = new SqlCommand("select  * from Users", _connection))
                {
                    if (_connection.State == System.Data.ConnectionState.Closed)
                        _connection.Open();

                    SqlDataReader reader = _command.ExecuteReader();

                    while (reader?.Read() ?? false)
                        _GetSuta.Add(new Suta() { Name = reader.GetString(0), Email = reader.GetString(1), PhoneNumber = reader.GetInt32(2), Gender = reader.GetString(3), Password = reader.GetString(4), Cartlitems = reader.GetInt32(5), Address = reader.GetString(6), Pincode = reader.GetInt32(7), state = reader.GetString(8) });
                }
            }
            catch (Exception e)
            {
                throw new SutaException(e.Message);
            }
            finally
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                    _connection.Close();
            }

            return _GetSuta;
        }


        //public IEnumerable<products> Category()
        //{
        //    List<products> _GetSuta = new List<products>();

        //    try
        //    {
        //        using (_command = new SqlCommand("select * from Category full outer join products on products.CategaryID = Category.CategaryID ", _connection))
        //        {
        //            if (_connection.State == System.Data.ConnectionState.Closed)
        //                    _connection.Open();

        //        SqlDataReader reader = _command.ExecuteReader();

        //        while (reader?.Read() ?? false)
        //            _GetSuta.Add(new products() { ProductName = reader.GetString(2), OriginalPrice = reader.GetInt32(3), OfferPrice = reader.GetInt32(4), CategaryID = reader.GetInt32(5), Image = reader.GetString(6), Quantity = reader.GetInt32(7) });
        //    }
        //    }
        //    catch (Exception e1)
        //    {
        //        throw new SutaException(e1.Message);
        //    }
        //    finally
        //    {
        //        if (_connection.State == System.Data.ConnectionState.Open)
        //            _connection.Close();
        //    }

        //    return _GetSuta;
        //}


    } 
}
