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

        public static void Main(string[] args)
        {
            bool DEBUG = true;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../../test_set.xml");

                buttonState button_state = new buttonState(xmlDoc);
                button_state.scan_xml();
               
                scriptBuilder sb = new scriptBuilder();
                sb.output_file();

                Console.ReadLine();
                    

            }
            catch (FileNotFoundException ex)
            {                
                Console.Write("Exception occured: {0}", ex.Message);
                throw;
            }



        }

   
    }//program
}
