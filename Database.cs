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
            string  Name, Surname;
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
                    User u = new User(Id, Name, Surname);
                    users.Add(u);

                
            }
            
            }
            catch(Exception ex)
            {
                
            }
            return users;
        }
        public string AddingUser( string Name, string Surname)
        {
            DataBaseConnection();
            int line;
            try { 
            string command = "INSERT INTO [User](Name,Surname) VALUES(@Name,@Surname)";
                using (SqlCommand sq = new SqlCommand(command,connection)) {
           
                 sq.Parameters.AddWithValue("@Name",Name);
                 sq.Parameters.AddWithValue("@Surname",Surname);
                 line =sq.ExecuteNonQuery();
                   
                }
                return line.ToString();
                
            }
            catch(Exception e)
            {
                
                return e.Message;
            }

        }
        public void UpdateUser(string parameter)
        {

        }
        public string AddingAccount(string Name, string moneyStatus, string UserId)
        {
            DataBaseConnection();
            int line;
            try
            {
                string command = "INSERT INTO [Account](Name,MoneyStatus,UserId) VALUES(@Name,@MoneyStatus,@UserId)";
                using (SqlCommand sq = new SqlCommand(command, connection))
                {

                    sq.Parameters.AddWithValue("@Name", Name);
                    sq.Parameters.AddWithValue("@MoneyStatus",moneyStatus);
                    sq.Parameters.AddWithValue("@UserId", UserId);
                    line = sq.ExecuteNonQuery();

                }
                return line.ToString();

            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        public void UpdateAccount(string parameter)
        {

        }
    }
}
