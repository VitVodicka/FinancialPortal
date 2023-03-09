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
