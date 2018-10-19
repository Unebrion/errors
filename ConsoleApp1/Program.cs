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

        public void getTime()
        {

        }

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

            
            //for (int i = 0; i <= sq.Count - 1; i++)
            //{

            //    if (i == (sq.Count - 1))
            //    {
            //        Console.WriteLine(sq[i].InnerText);
            //        Console.WriteLine("end of array, take this time and subtract");
            //    }
            //    else
            //    {
            //        if (sq[i].InnerText == "true" && sq[i + 1].InnerText == "false" )
            //        {
            //            // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

            //            Console.WriteLine("went from true to false");
            //        }
                    
            //        else if (sq[i].InnerText == "false" && sq[i + 1].InnerText == "true" )
            //        {
            //            // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
            //            Console.WriteLine("crassssh");
            //        }
            //    }
               
            //}
            
        }

        //private static string getString()
        //{
        //    return "doggies";
        //}
    }
}
