using Dapper;
using OnlineBanking.Data.Helpers;
using OnlineBanking.Data.Models;
using OnlineBanking.Data.ViewModels;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OnlineBanking.Data.Services
{
    public class UserDatabaseService
    {
        public static string OnlineBankingDB = SqlHelper.GetDatabase("OnlineBankingDB");

        public bool CreateCustomer(RegisterViewModel model)
        {
            string sp = "spCreateCustomer";

            try
            {
                using(var conn = new SqlConnection(OnlineBankingDB))
                {
                    var customer = conn.Execute(sp, new { Firstname = model.Firstname, 
                        Middlenames = model.Middlenames, Surname = model.Surname, Email = model.Email, DOB = model.DOB, 
                        Address = model.Address, Postcode = model.Postcode, Password = model.Password }, commandType: CommandType.StoredProcedure);

                    Debug.WriteLine(customer);

                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return false;
        }
    }
}
