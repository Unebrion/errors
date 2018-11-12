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
            var tempo = buttonState.state_output;



            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("../../../test_set.xml");

                buttonState button_state = new buttonState(xmlDoc);
                button_state.scan_xml();
                
                

                IList<buttonState> temp = new List<buttonState>();
                foreach (var button in temp)
                {
                   // Console.WriteLine(temp.);
                }
                

            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
                throw;
            }



        }

   
    }//program
}
