using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinancialPortal
{
    internal class Files
    {
        public void WrittingPasswordEmail(string password,string email)//writes password, email from title into file
        {
            try
            {
                XmlDocument document = new XmlDocument();
                XmlElement root = document.CreateElement("Password");
                document.AppendChild(root);
                XmlElement emailChild = document.CreateElement("email");
                emailChild.InnerText = email;
                root.AppendChild(emailChild);
                XmlElement child = document.CreateElement("password");
                child.InnerText = password;
                root.AppendChild(child);
                
                document.Save("password.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in writting to file:" + e.Message);
            }


        }
        public void ReadingPasswordEmail()//reads password and email from file
        {
            int lineIndex = 0;
            string email = "";
            string password = "";
            try
            {

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load("password.xml");
                XmlElement root = xmlDocument.DocumentElement;
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node != null)//if it is first element =email, second element= password
                    {
                        if(lineIndex== 0)
                        {
                            email = node.InnerText;
                        }
                        if(lineIndex== 1)
                        {
                            password = node.InnerText;
                        }
                        lineIndex++;
                        
                    }
                }
                PasswordChecker.settedEmail= email;
                PasswordChecker.settedPassword=password;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Reading files:" + e.Message);
            }

            
        }
        //writting to file
        public void WrittingToFile(int value)
        {
            try { 
            XmlDocument document = new XmlDocument();
            XmlElement root = document.CreateElement("Loading");
            document.AppendChild(root);
            XmlElement child = document.CreateElement("Value");
            child.InnerText=value.ToString();
            root.AppendChild(child);
            document.Save("saving.xml");
            }
            catch(Exception e) {
                Console.WriteLine("Error in writting to file:"+e.Message);
            }


        }
        //reading from files
        public int ReadingFromFile()
        {
            int value=0;
            try
            {

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("saving.xml");
            XmlElement root = xmlDocument.DocumentElement;
            foreach (XmlNode node in root.ChildNodes)
            {
                if(node!=null)
                {
                    value = int.Parse(node.InnerText);
                }
            }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in Reading files:"+e.Message);
            }

            return value;
        }
    }
}
