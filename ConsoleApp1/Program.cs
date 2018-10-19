using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;



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
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("square.xml");
            XmlNodeList sq = xmlDoc.GetElementsByTagName("Square");
            XmlNodeList time = xmlDoc.GetElementsByTagName("ReportTimeStamp");
            Button[] buttonTime = new Button[time.Count];


            buttonState bs = new buttonState(xmlDoc);

            bs.Square();
           // bs.Triangle();
           
            
        }

   
    }//program
}
