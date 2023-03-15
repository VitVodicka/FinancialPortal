﻿using FinancialPortal.DatabasePages;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
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

        SqlCommand command;
        SqlDataReader datareader;
        string sql;
        public void DataBaseReadUser()
        {
            //DataBaseConnection();
            //List<User> users = new List<User>();
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password ={ your_password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    sql = "SELECT Name,Surname FROM [User]";
                    string Name, Surname;
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {


                        datareader = command.ExecuteReader();
                        while (datareader.Read())
                        {
                            Name = datareader.GetValue(0).ToString();
                            Surname = datareader.GetValue(0).ToString();

                            MessageBox.Show(Name + Surname);

                        }
                    }

                }

            }
            catch (Exception ex)
            {

            }


        }


        public void AddingUser(int index, string Name, string Surname)
        {//needs to put some class intoparametrs
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password ={ your_password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

           
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
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password ={ your_password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

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