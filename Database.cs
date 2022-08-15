using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPortal
{
    internal class Database
    {
        SqlConnection connection;
        public void DataBaseConnection()
        {
            try {
            
            string connectionString = Properties.Settings.Default.DatabaseConnectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();

            
            }
            catch(Exception e)
            {
                
            }
        }
        public List<User> DataBaseReadUser(string comText)
        {
            List<User> users = new List<User>();
            try { 
            SqlDataReader datareader;
            string  Name, Surname, Account;
            int Id;

            SqlCommand command = new SqlCommand();
            command.CommandText = comText;
            command.Connection = connection;
            datareader = command.ExecuteReader();
            while (datareader.Read())
            {
                    Id = int.Parse(datareader["Id"].ToString());
                    Name= datareader["Name"].ToString();
                    Surname = datareader["Surname"].ToString();
                    Account = datareader["Account"].ToString();
                    User u = new User(Id, Name, Surname, Account);
                    users.Add(u);

                
            }
            
            }
            catch(Exception ex)
            {
                
            }
            return users;
        }
    }
}
