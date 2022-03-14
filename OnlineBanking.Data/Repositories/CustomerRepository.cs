using Dapper;
using OnlineBanking.Data.Helpers;
using OnlineBanking.Data.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace OnlineBanking.Data.Repositories
{
    public class CustomerRepository
    {
        public static string OnlineBankingDB = SqlHelper.GetDatabase("OnlineBankingDB");

        public Customer GetCustomerByAccountNo(int customerAccNo)
        {
            string sp = "spGetCustomerAccountByAccountNo";

            try
            {
                using (var conn = new SqlConnection(OnlineBankingDB))
                {

                    var customer = conn.Query<Customer>(sp, new { CustomerAccNo = customerAccNo }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    Debug.WriteLine(customer);

                    return customer;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        public bool GetCustomerByLoginCredentials(int customerAccNo, string password)
        {
            string sp = "spGetCustomerAccountByAccountNo";

            try
            {
                using (var conn = new SqlConnection(OnlineBankingDB))
                {

                    var customerLogin = conn.Query<CustomerLogin>(sp, new { CustomerAccountNo = customerAccNo }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    Debug.WriteLine(customerLogin);

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
