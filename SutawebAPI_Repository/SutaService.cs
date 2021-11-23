using SutaWebAPI_Common;
using SutaWebAPI_Common.Exceptions;
using SutaWebAPI_Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using SutawebAPI_Repository;


namespace SutawebAPI_Repository
{
   
        //Here i wrote the Query for the Student Operations
        public class SutaService : ISutaService
        {
            private SqlConnection _connection;
            private SqlCommand _command;

            public SutaService()
            {
                _connection = new SqlConnection(ApplicationContext.ConnectionString);
            }

        public bool DeleteProductBuy(int ProductRating)
        {
            bool delete = false;
            try
            {
                using (_command = new SqlCommand("delete from products  where ProductRating ='" + ProductRating + "'", _connection))
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

        public bool InsertCustomerDetails(Suta Cust_deatils)
            {
                bool insert = false;
                try
                {
                    using (_command = new SqlCommand("insert into Users values('" + Cust_deatils.Name + "','" + Cust_deatils.Email + "','" + Cust_deatils.PhoneNumber + "','" + Cust_deatils.Gender + "','" + Cust_deatils.Password + "')", _connection))
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
        public bool LoginCustomer(string Name,string Password)
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



        public bool productsBuy(products _product)
        {
            bool insert = false;
            try
            {
                using (_command = new SqlCommand("insert into products values('" + _product.ProductName + "','" + _product.ProductCost+ "','" + _product.ProductRating + "')", _connection))
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

        public IEnumerable<Suta> GetSutaDetails()
            {
                List<Suta> _students = new List<Suta>();

                try
                {
                    using (_command = new SqlCommand("SELECT * FROM Users", _connection))
                    {
                        if (_connection.State == System.Data.ConnectionState.Closed)
                            _connection.Open();

                        SqlDataReader reader = _command.ExecuteReader();

                        while (reader?.Read() ?? false)
                            _students.Add(new Suta() {  Name = reader.GetString(0), Email = reader.GetString(1), PhoneNumber = reader.GetInt32(2), Gender = reader.GetString(3), Password = reader.GetString(4)});
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

                return _students;
            }
        }
}
