using FinancialPortal.DatabasePages;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace FinancialPortal
{
    internal class Database
    {

        SqlDataReader datareader;
        string sql;
        public void DataBaseReadUser()
        {
            
            ObservableCollection<User> users = new ObservableCollection<User>();
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    sql = "SELECT IdUser,Name,Surname FROM [User]";
                    string Name, Surname;
                    int id;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        datareader = command.ExecuteReader();
                        while (datareader.Read())
                        {
                            id= datareader.GetInt32(0);
                            Name = datareader.GetValue(1).ToString();
                            Surname = datareader.GetValue(2).ToString();

                            MessageBox.Show(id+Name + Surname);
                            User u = new User(id, Name, Surname);
                            users.Add(u);

                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


<<<<<<< HEAD
        }//selects max UserIndex value from User Table
        public int DataBaseUserMax()
        {

            //ObservableCollection<User> users = new ObservableCollection<User>();
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            int maxId = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    sql = "SELECT MAX(IdUser) FROM [User]";
                    
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        datareader = command.ExecuteReader();
                        while (datareader.Read())
                        {
                            maxId = datareader.GetInt32(0);
                           

                            
                            
=======
        }
>>>>>>> parent of 9ad45b3 (Update,Insert,Select user working)


        public void AddingUser(int index, string Name, string Surname)
        {//needs to put some class intoparametrs
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

           
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO [User] (Name, Surname) VALUES (@Name, @Surname)";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        // Add parameters to the SqlCommand object
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Surname", Surname);

                        // Execute the SQL command
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the command executed successfully
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("User added successfully");
                        }
                        else
                        {
                            Console.WriteLine("User was not added");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
        public string updateUser(string parameter, string value, int id)
        {
<<<<<<< HEAD
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
=======
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password ={ your_password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
>>>>>>> parent of 9ad45b3 (Update,Insert,Select user working)

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {

                
                if (parameter == "Name")
                {
                    string command = "UPDATE [User] SET Name=@Name WHERE UserId=@UserId";
                    using (SqlCommand sq = new SqlCommand(command, connection))
                    {
                        sq.Parameters.AddWithValue("@Name", value);
                        sq.Parameters.AddWithValue("UserId", id);
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

            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }/*
        public string AddingAccount(string Name, string moneyStatus, string UserId, string Type)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password ={ your_password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            int line;
            try
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                {

                
                string command = "INSERT INTO [Account](Name,MoneyStatus,UserId,Type) VALUES(@Name,@MoneyStatus,@UserId,@Type)";
                using (SqlCommand sq = new SqlCommand(command, connection))
                {

                    sq.Parameters.AddWithValue("@Name", Name);
                    sq.Parameters.AddWithValue("@MoneyStatus",moneyStatus);
                    sq.Parameters.AddWithValue("@UserId", UserId);
                    sq.Parameters.AddWithValue("@Type", Type);
                    line = sq.ExecuteNonQuery();

                }
                return line.ToString();

            }
            }
            catch (Exception e)
            {

                return e.Message;
            }
            
        }
        public string UpdateAccount(string parameter, string value, int id)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password ={ your_password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    if (parameter == "Name")
                    {
                        string command = "UPDATE [Account] SET Name=@Name WHERE UserId=@UserId";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@Name", value);
                            sq.Parameters.AddWithValue("UserId", id);
                            int line = sq.ExecuteNonQuery();
                            return line.ToString();
                        }
                    }
                    if (parameter == "User")
                    {
                        string command = "UPDATE [Account] SET User=@User WHERE UserId=@UserId";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@User", value);
                            sq.Parameters.AddWithValue("UserId", id);
                            int line = sq.ExecuteNonQuery();
                            return line.ToString();

                        }
                    }
                    if (parameter == "Type")
                    {
                        string command = "UPDATE [Account] SET Type=@Type WHERE UserId=@UserId";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@Type", value);
                            sq.Parameters.AddWithValue("UserId", id);
                            int line = sq.ExecuteNonQuery();
                            return line.ToString();

                        }
                    }
                    if (parameter == "MoneyStatus")
                    {
                        string command = "UPDATE [Account] SET MoneyStatus=@MoneyStatus WHERE UserId=@UserId";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@MoneyStatus", value);
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
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }*/
    }
}