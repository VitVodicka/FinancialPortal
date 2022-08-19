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
            DataBaseConnection();
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
        public string UpdateUser(string parameter, string value,int id)
        {
            DataBaseConnection();
            try
            {
                if(parameter == "Name")
                {
                    string command = "UPDATE [User] SET Name=@Name WHERE UserId=@UserId";
                    using(SqlCommand sq = new SqlCommand(command, connection))
                    {
                        sq.Parameters.AddWithValue("@Name",value);
                        sq.Parameters.AddWithValue("UserId",id);
                        int line = sq.ExecuteNonQuery();
                        return line.ToString();
                    }
                }
                if (parameter == "Surname")
                {
                    string command = "UPDATE [User] SET Surname=@Surname WHERE UserId=@UserId";
                    using (SqlCommand sq = new SqlCommand(command, connection))
                    {
                        sq.Parameters.AddWithValue("@Surname", value);
                        sq.Parameters.AddWithValue("UserId", id);
                        int line = sq.ExecuteNonQuery();
                        return line.ToString();

                    }
                }
                else
                {
                    return "Not found";
                }


            }
            catch(Exception e)
            {
                return e.Message;
            }
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
        public void UpdateAccount(string parameter, string value)
        {
            DataBaseConnection();
        }
    }
}
