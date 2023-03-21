using FinancialPortal.Accounts;
using FinancialPortal.DatabasePages;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Security.Principal;
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
                MessageBox.Show("Add user"+ex.Message);
            }


        }//selects max UserIndex value from User Table
        public int DataBaseUserMax()
        {

             
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






                        }

                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("DatabaseUserMax"+ex.Message);
            }
            return maxId;


        }


        public void AddingUser(string Name, string Surname)
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
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

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
                MessageBox.Show("Update user "+e.Message);
            }

        }
        //max idAccount in database
        private int maxIdAccount()
        {
            
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
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
                        MessageBox.Show("maxIdAccount"+e.Message);
                    }


                }
                if (maxIdBool == true)
                {
                    maxId = 0;
                }
            }
            catch(Exception ex) {
                MessageBox.Show("maxIdAccount"+ex.Message);
            }


                

            return maxId;

        }

        public void AddingAccount(string Name, float moneyStatus, int UserId)
        {

            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

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
                        

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("maxIdAccount" + e.Message);
            }
        }

        public void updateMoney(int AccountId,float money)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string command = "INSERT INTO Moneystatus (idAccount, Money) VALUES (@idAccount, @Money)";
                    using (SqlCommand sq = new SqlCommand(command, connection))
                    {
                        sq.Parameters.AddWithValue("@idAccount", AccountId);
                        sq.Parameters.AddWithValue("@Money", money);
                        int line = sq.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            

        }
        //if the database cannot be connected then the program will shut down
        public bool canBeConnected()
        {
            bool canReturn;
            try
            {
                string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
                canReturn = true;
            }
            catch 
            {
                canReturn= false;
                MessageBox.Show("Cannot connect to database");
            }
            return canReturn;
        }
        public void readDatabaseAccount()
        {
            
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    sql = "SELECT [AccountId],[Name],[UserId] FROM dbo.Account";
                    string sqlMoneyStatus = "SELECT [idAccount],[Money] FROM dbo.MoneyStatus";
                    string Name;
                    double MoneyStatus;
                    int userId=0;
                    int accountId = 0;
                    SqlDataReader dataReaderMoney;
                    using (SqlCommand command = new SqlCommand(sql, connection))//read accountID,Name,UserID
                    {

                        datareader = command.ExecuteReader();
                        while (datareader.Read())
                        {
                            accountId = datareader.GetInt32(0);
                            
                            Name = datareader.GetValue(1).ToString();
                            
                            userId = datareader.GetInt32(2);
                            Account account  = new Account(Name, userId);
                            
                            account.Index= accountId;
                            Controller.AccountListObservable.Add(account);
                            
                            account.fromCollectionToString();



                        }
                        datareader.Close();
                        using (SqlCommand moneyCommand = new SqlCommand(sqlMoneyStatus, connection))//reads Money from MoneyStatus and adds it to AccountUserObservable
                        {
                            dataReaderMoney = moneyCommand.ExecuteReader();
                            while (dataReaderMoney.Read())
                            {
                                accountId= dataReaderMoney.GetInt32(0);
                                MoneyStatus = dataReaderMoney.GetDouble(1);
                                for(int i = 0;i<Controller.AccountListObservable.Count;i++)
                                {
                                    if (Controller.AccountListObservable[i].Index==accountId)
                                    {
                                        Controller.AccountListObservable[i].MoneyStatus.Add(MoneyStatus);
                                        Controller.AccountListObservable[i].Money = Controller.AccountListObservable[i].MoneyStatus.Last();
                                        Controller.AccountListObservable[i].fromCollectionToString();
                                    }
                                }
                                        
                                   
                                
                                
                            }
                            
                        }

                    }

                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show("readAccount"+ex.Message);
            }
        }

        public void UpdateAccount(string parameter, string value, int id,int userid)
        {
            string connectionString = "Server = tcp:blogserver.database.windows.net,1433; Initial Catalog = FinancialPortal; Persist Security Info = False; User ID = CloudSAea872b24; Password =; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

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
                            

                        }
                    }
                    
                   
                    


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Update Account"+e.Message);
            }
        }
    }
    
}