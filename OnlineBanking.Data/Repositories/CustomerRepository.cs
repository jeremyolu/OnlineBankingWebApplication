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
        public static string OnlineBankingDB = SqlHelper.GetDatabase("OnlineBankingDBLive");

        public Customer GetCustomerByAccountNo(int customerNo)
        {
            string sp = "spGetCustomerAccountByAccountNo";

            try
            {
                using (var conn = new SqlConnection(OnlineBankingDB))
                {

                    var customer = conn.Query<Customer>(sp, new { CustomerAccNo = customerNo }, commandType: CommandType.StoredProcedure).FirstOrDefault();

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

        public CustomerLogin GetCustomerLogin(int customerNo)
        {
            string sp = "spGetCustomerLogin";

            try
            {
                using (var conn = new SqlConnection(OnlineBankingDB))
                {

                    var customerLogin = conn.Query<CustomerLogin>(sp, new { CustomerNo = customerNo }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    Debug.WriteLine(customerLogin);

                    return customerLogin;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }

}
