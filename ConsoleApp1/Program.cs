using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;



namespace ConsoleApp1
{
    class Program
    {

        public DateTime ReportTimeStamp { get; set; }

        struct Button
        {
            public String isPressed;
            public String timePressed;
        }


        public static void Main(string[] args)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../test_set.xml");
                Console.Write(xmlDoc);
                XmlNodeList sq = xmlDoc.GetElementsByTagName("Square");
                XmlNodeList time = xmlDoc.GetElementsByTagName("ReportTimeStamp");

                buttonState bs = new buttonState(xmlDoc);
                bs.Square(0);
                bs.trim_Array();
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
                throw;
            }



        }

   
    }//program
}
