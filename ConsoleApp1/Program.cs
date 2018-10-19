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


        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("square1.xml");

            XmlNodeList sq = xmlDoc.GetElementsByTagName("Square");
            XmlNodeList time = xmlDoc.GetElementsByTagName("ReportTimeStamp");

            int test4 = time.Count;
            int test5 = xmlDoc.GetElementsByTagName("Square").Count +1;
            int test6 = 6;
            
            
            Button[] buttonTime = new Button[time.Count];
            Double[] timeDifference = new Double[time.Count];
            String[] stringArray = new string[time.Count];
            int[] intArray = new int[time.Count];
            Double[] doubleArray = new Double[time.Count];


            // List<Double> timeChanges = new List<Double>();

            //DateTime testing = new DateTime();
            //testing = DateTime.Now.ToLongTimeString();

            //String testo = time.ToString();
            //testo = time[1].InnerText.Substring(17,10);
            //testo = time[1].InnerText.Split(':')[1];
            //testo = testo.Split('.')[0];
            // Console.WriteLine(testo);

            //Console.WriteLine(testing);


            //String test1 = "10.3497815";
            //Console.WriteLine(Double.Parse(test1));

            //String test2 = "2018-10-03T14:35:11.3059684Z";
            //Console.WriteLine(Double.Parse(test2.Substring(17,9)));

            Console.WriteLine( test5);
            Console.WriteLine(test4);
            Console.WriteLine("sq.count is: ",sq.Count);
            Console.WriteLine(test6);

            for (int i = 0; i <= sq.Count - 1; i++)
            {


                if (i == (sq.Count - 1))
                {
                    Console.WriteLine(sq[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (sq[i].InnerText == "true" && sq[i + 1].InnerText == "false" )
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }
                    //&& sq[i + 1].InnerText == "true"
                    else if (sq[i].InnerText == "false" && sq[i + 1].InnerText == "true" )
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }




                //if (sq[i].InnerText == "false" && sq[i + 1].InnerText != "false")
                //if (sq[i].InnerText == "false" && sq[i + 1].InnerText !="false")

                //{
                //    Console.WriteLine("went from false to true");
                //Console.WriteLine(time[i].InnerText.Substring(17, 9));
                // Console.WriteLine(sq.);

                //    //String test3 = "";
                //    //test3 = time[i].InnerText.Substring(17, 8);
                //    //Console.WriteLine(Double.Parse(test3));

                //    //Console.WriteLine(Double.Parse(time[i].InnerText.Substring(17, 8)));
                //    //Console.WriteLine(Decimal.Parse(time[i].InnerText.Substring(17, 9)));
                //    //timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                //Console.WriteLine(timeDifference[i]);

                //    //timeChanges.Add(i);
                //    //Console.WriteLine("crash");

                //}

                // if (sq[i].InnerText == "true" && sq[i + 1].InnerText != "true")
                //if (sq[i].InnerText == "true")



                //if (sq[i].InnerText == "true" && sq[i + 1].InnerText == "false" && sq.Count > i)
                //{
                //    // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                //    Console.WriteLine("went from true to false");
                //}
                ////&& sq[i + 1].InnerText == "true"
                //if (sq[i].InnerText == "false" && sq[i + 1].InnerText == "true" && i < sq.Count-1)
                //{
                //    // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                //    Console.WriteLine("crassssh");
                //}




                //if (sq[i].InnerText == "false" && sq.Count > i && sq[i + 1].InnerText != "false" && sq.Count > i)
                //{
                //    Console.WriteLine("went from false to true");
                //}

                //  buttonTime[i].isPressed = sq[i].InnerText;
                // buttonTime[i].timePressed = time[i].InnerText.Substring(17, 8);
                // Console.WriteLine(decimal.Parse(buttonTime[i].timePressed));
                //Console.WriteLine(buttonTime[i].isPressed);
                // Console.WriteLine("Time difference is: ", timeDifference[i+1] - timeDifference[i]);

                //timeDifference[i] = i;
                // Console.WriteLine("time difference at I: ", timeDifference[i]);

            }

            //testing = default(DateTime).Add(testing.TimeOfDay);

            //for (int i = 0; i < sq.Count; i++)
            //{
            //    if (sq[i].InnerText.Length > 0)
            //    {
            //        Console.WriteLine(sq[i].InnerText);
            //        Console.WriteLine(time[i].InnerText);

            //        testo = testo.Split('.')[0];
            //        Console.WriteLine(testo);

            //        Console.WriteLine(testing);
            //    }
            //}

            //DateTime x = new DateTime(date);
            //Console.WriteLine(getString());

            //Console.WriteLine(timeDifference[0]);

            //timeDifference[0] = 10;
            //Console.WriteLine("array has: {0}", timeDifference[0]);

            //intArray[0] = 10;
            //Console.WriteLine(intArray[0]);

            //doubleArray[0] = 55.555;
            //Console.WriteLine(doubleArray[0]);

            //stringArray[0] = "asss";
            //Console.WriteLine(stringArray[0]);

            //Console.WriteLine("Press enter to close...");
            //Console.ReadLine();


        }

        //private static string getString()
        //{
        //    return "doggies";
        //}
    }
}
