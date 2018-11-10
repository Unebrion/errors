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
            bool DEBUG = true;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../../test_set.xml");

                buttonState button_state = new buttonState(xmlDoc);
                button_state.scan_xml();





            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
                throw;
            }



        }

   
    }//program
}
