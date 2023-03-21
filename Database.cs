using FinancialPortal.Accounts;
using FinancialPortal.DatabasePages;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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

            //ObservableCollection<User> users = new ObservableCollection<User>();
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            
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
                            id = datareader.GetInt32(0);
                            Name = datareader.GetValue(1).ToString();
                            Surname = datareader.GetValue(2).ToString();

                            
                            User u = new User(id, Name, Surname);
                            Controller.UserListObservable.Add(u);

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }//selects max UserIndex value from User Table
        public int DataBaseUserMax()
        {

            //ObservableCollection<User> users = new ObservableCollection<User>();
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
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






                        }

                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return maxId;


        }


        public void AddingUser(string Name, string Surname)
        {//needs to put some class intoparametrs
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";


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



                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }
        public void updateUser(string parameter, string value, int id)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (parameter == "Name")
                    {
                        string command = "UPDATE [User] SET Name=@Name WHERE IdUser=@IdUser";

                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@Name", value);
                            sq.Parameters.AddWithValue("IdUser", id);
                            int line = sq.ExecuteNonQuery();

                        }
                    }
                    if (parameter == "Surname")
                    {
                        string command = "UPDATE [User] SET Surname=@Surname WHERE IdUser=@IdUser";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@Surname", value);
                            sq.Parameters.AddWithValue("@IdUser", id);
                            int line = sq.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        MessageBox.Show("User Not found");
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private int maxIdAccount()
        {
            //ObservableCollection<User> users = new ObservableCollection<User>();
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            int maxId = -1;
            bool maxIdBool=false;
            try { 
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try { 
                    connection.Open();
                    sql = "SELECT MAX(AccountId) FROM [Account]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        datareader = command.ExecuteReader();
                        while (datareader.Read())
                        {
                            maxId = datareader.GetInt32(0)+1;

                        }

                    }
                    }
                    catch(Exception e)
                    {
                        maxIdBool = true;
                        MessageBox.Show(e.Message);
                    }


                }
                if (maxIdBool == true)
                {
                    maxId = 0;
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }


                

            return maxId;

        }

        public void AddingAccount(string Name, float moneyStatus, int UserId)
        {

            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            // Retrieve the max AccountId value from the Account table
            int accountId = maxIdAccount();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert a new record into the Account table with the provided Name, UserId, and accountId values
                    string command = "BEGIN TRANSACTION; INSERT INTO [Account]( Name, UserId) VALUES( @Name, @UserId); INSERT INTO [MoneyStatus](Money,idAccount) VALUES(@Money,@idAccount); COMMIT TRANSACTION";
                    using (SqlCommand sq = new SqlCommand(command, connection))
                    {
                        sq.Parameters.AddWithValue("@idAccount", accountId);
                        sq.Parameters.AddWithValue("@Name", Name);
                        sq.Parameters.AddWithValue("@UserId", UserId);
                        sq.Parameters.AddWithValue("@Money", moneyStatus);

                        int line = sq.ExecuteNonQuery();
                        MessageBox.Show(line.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updateMoney(int AccountId,float money)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                        connection.Open();
                    
                        string command = "UPDATE [MoneyStatus] SET Money=@Money WHERE idAccount=@idAccount";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@Money", money);
                            sq.Parameters.AddWithValue("@idAccount",AccountId);
                            int line = sq.ExecuteNonQuery();
                            MessageBox.Show(line.ToString());

                        }
                   

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public void readDatabaseAccount()
        {
            
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    sql = "SELECT [AccountId],[Name],[Money],[UserId] FROM dbo.Account JOIN dbo.MoneyStatus ON(Account.AccountId=MoneyStatus.idAccount)";
                    string Name;
                    double MoneyStatus;
                    int userId=0;
                    int accountId = 0;

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        datareader = command.ExecuteReader();
                        while (datareader.Read())
                        {
                            accountId = datareader.GetInt32(0);
                            Name = datareader.GetValue(1).ToString();
                            MoneyStatus = datareader.GetDouble(2);
                            userId = datareader.GetInt32(3);
                            Account account  = new Account(Name, (float)MoneyStatus, userId);
                            account.Index= accountId;
                            Controller.AccountListObservable.Add(account);
                            account.fromCollectionToString();



                        }

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateAccount(string parameter, string value, int id,int userid)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =1mXp.159; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (parameter == "Name")
                    {
                        string command = "UPDATE [Account] SET Name=@Name WHERE AccountId=@AccountId";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@Name", value);
                            sq.Parameters.AddWithValue("@AccountId", id);
                            int line = sq.ExecuteNonQuery();
                            MessageBox.Show(line.ToString());
                        }
                    }
                    if (parameter == "User")
                    {
                        string command = "UPDATE [Account] SET UserId=@UserId WHERE AccountId=@AccountId";
                        using (SqlCommand sq = new SqlCommand(command, connection))
                        {
                            sq.Parameters.AddWithValue("@UserId", userid);
                            sq.Parameters.AddWithValue("@AccountId", id);
                            int line = sq.ExecuteNonQuery();
                            MessageBox.Show(line.ToString());

                        }
                    }
                    
                   
                    


                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
    
}