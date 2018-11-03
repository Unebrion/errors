using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace ConsoleApp1
{
    class buttonState
    {
        //declare class-local var
        //constant super array, will be fed into generic method later
        //this never changes, so doesnt need to be in constructor
        const string SQUARE     = "SQUARE";
        const string CIRCLE     = "CIRCLE";
        const string TRIANGLE   = "TRIANGLE";
        const string CROSS      = "CROSS";
        const string DPAD_UP    = "DPAD_UP";
        const string DPAD_DOWN  = "DPAD_DOWN";
        const string DPAD_LEFT  = "DPAD_LEFT";
        const string DPAD_RIGHT = "DPAD_RIGHT";
        string[] super_array    = { SQUARE,
                                    CIRCLE,
                                    TRIANGLE,
                                    CROSS,
                                    DPAD_UP,
                                    DPAD_DOWN,
                                    DPAD_LEFT,
                                    DPAD_RIGHT
                                  };
        
        //probably better way to do this? could load into an array if wanted
        XmlDocument xmlDoc = new XmlDocument();
        XmlNodeList  square_nodelist,
                     triangle_nodelist,
                     cross_nodelist,
                     circle_nodelist,
                     dpad_up_nodelist,
                     dpad_right_nodelist,
                     dpad_down_nodelist,
                     dpad_left_nodelist,
                     timestamp_nodelist;            
        Button[] timeCalc;
        Button[] trimmedCalc;



        struct Button
        {
            public String isPressed;
            public String timePressed;          
            public String Sq_Bool;
            public Double sq_Time;            
        }

        //default constructor
        public buttonState()
        {
            try
            {
                //cr,ci,tr,l1,r1,du,dr,dDo,dl;
                Console.WriteLine("Enter file path:");
                xmlDoc.Load(Console.ReadLine());
                timestamp_nodelist = xmlDoc.GetElementsByTagName("ReportTimeStamp");
                timeCalc = new Button[xmlDoc.GetElementsByTagName("Square").Count];
                //timeCalcList = new List<Button>();
                square_nodelist = xmlDoc.GetElementsByTagName("Square");
                cross_nodelist = xmlDoc.GetElementsByTagName("Cross");
                circle_nodelist = xmlDoc.GetElementsByTagName("Circle");
                triangle_nodelist = xmlDoc.GetElementsByTagName("Triangle");
                l1 = xmlDoc.GetElementsByTagName("L1");
                r1 = xmlDoc.GetElementsByTagName("R1");
                dpad_up_nodelist = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist = xmlDoc.GetElementsByTagName("DPad_Left");
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
            }
        }

        //overload constructor
        public buttonState(XmlDocument xml)
        {
            try
            {
                //cr,ci,tr,l1,r1,du,dr,dDo,dl;
                xmlDoc = xml;
                timestamp_nodelist = xmlDoc.GetElementsByTagName("ReportTimeStamp");
                timeCalc = new Button[xmlDoc.GetElementsByTagName("Square").Count];
                //timeCalcList = new List<Button>();
                square_nodelist = xmlDoc.GetElementsByTagName("Square");
                cross_nodelist = xmlDoc.GetElementsByTagName("Cross");
                circle_nodelist = xmlDoc.GetElementsByTagName("Circle");
                triangle_nodelist = xmlDoc.GetElementsByTagName("Triangle");
                l1 = xmlDoc.GetElementsByTagName("L1");
                r1 = xmlDoc.GetElementsByTagName("R1");
                dpad_up_nodelist = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist = xmlDoc.GetElementsByTagName("DPad_Left");
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
            }
        }

        public void Square(int ct)
        {
            // XmlNodeList sq = xmlDoc.GetElementsByTagName("Square");
            //timeCalcList.Add();
           int counter = ct;
            for (int i = 0; i <= square_nodelist.Count - 1; i++)
            {

                if (i == (square_nodelist.Count - 1))
                {
                    Console.WriteLine();
                    //  Console.WriteLine(sq[i].InnerText);
                    //  Console.WriteLine("end of array, take this time and subtract");    
                    //timeCalcList.Add(sq[i].InnerText);
                    //timeCalcList.Add(sq[i].InnerText);                  
                    timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
                    timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17,8));     
                  //  Console.WriteLine("if i == sq.count -1");
                   // Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
                    counter++;
                }

                else
                {
                    if (square_nodelist[i].InnerText == "true" && square_nodelist[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine();
                        Console.WriteLine("went from true to false");
                        timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
                        timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
                        Console.WriteLine("if square is true");
                        Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
                        counter++;
                    }

                    else if (square_nodelist[i].InnerText == "false" && square_nodelist[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        //Console.WriteLine("crassssh");
                        Console.WriteLine();
                        timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
                        timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
                        Console.WriteLine("if square is false");
                        Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
                        Console.WriteLine("attempting to print length of time calc: {0}",timeCalc.Length);
                        //  Console.WriteLine("print out timeclock.sq_bool: {0}",timeCalc[i].Sq_Bool);
                        counter++;
                    }//else if
                }//else
            }//for loop

            //this does the time calculation 
            for (int i = 0; i <= timeCalc.Length - 1; i++)
            {
                if (i == (timeCalc.Length - 1))
                {
                    Console.WriteLine("last entry I think");
                }

                else
                {
                    if (timeCalc[i].Sq_Bool == "true" && timeCalc[i + 1].Sq_Bool == "false")
                    {
                        Double x = timeCalc[i + 1].sq_Time - timeCalc[i].sq_Time;
                        Console.WriteLine("attempting the math: {0}", x);
                    }

                    //this isn't necessary I don't think
                    else
                    {
                       // Console.WriteLine("do I ever see this?");
                    }//nested else
                }//else
            }//for loop

        }//square

        public void Calc()
        {
            int count = 0;
            for (int i = 0; i < timeCalc.Length - 1; i++)
            {
                Square(count);
                count++;
            }

            Console.WriteLine("timecalc.length is: {0}",timeCalc.Length); 
        }

        public void trim_Array()
        {
            //if all buttons .i = 0 then new array = i.length
            trimmedCalc = timeCalc;
            int counter = 0;
            //Console.WriteLine("trimmed calc at index 0: {0}",trimmedCalc[0].sq_Time);
            
            
            //checks if there is a time value this may need adjusted since it is only checking square. Could do lots of &&'s for each button. Time seems like the right value
            for (int i = 0; i < timeCalc.Length - 1; i++)
            {
                
                if (timeCalc[i].sq_Time != 0)
                {
                    counter++;
                }            

            }  //for loop     
            
            //resizes the Array after the button press lengths are written
            Array.Resize(ref timeCalc, counter);

            //checking the contents of the array
            for (int i = 0; i < timeCalc.Length; i++)
            {
                Console.WriteLine("Index: {0} sq_bool is: {1} and sq_time is: {2}", i, timeCalc[i].Sq_Bool, timeCalc[i].sq_Time);
            }

        }//trim array
    }//button state
}//namespace
