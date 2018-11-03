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
        const string SQUARE             = "SQUARE";
        const string CIRCLE             = "CIRCLE";
        const string TRIANGLE           = "TRIANGLE";
        const string CROSS              = "CROSS";
        const string DPAD_UP            = "DPAD_UP";
        const string DPAD_DOWN          = "DPAD_DOWN";
        const string DPAD_LEFT          = "DPAD_LEFT";
        const string DPAD_RIGHT         = "DPAD_RIGHT";
        static string[] super_array     = { SQUARE,
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
        int xml_length;
        int super_array_length = super_array.Length;



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
                dpad_up_nodelist = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist = xmlDoc.GetElementsByTagName("DPad_Left");
                xml_length = timestamp_nodelist.Count;
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

        //top-level method for scanning through xml file and getting information for each dualshock state
        public void scan_xml()
        {
            bool end_of_array = false;
            //iterate through boolean array lengths
            for (int i = 0; i <= xml_length - 1; i++)
            {
                for (int j = 0; j <= super_array_length - 1; j++)
                {
                    //generic button info gatherer
                    if (i == (xml_length - 1))
                    {
                        //special condition end of boolean array
                        end_of_array = true;
                        button_state_build(super_array[j], i, end_of_array);
                    }
                    else
                    {
                        //proceed as normal
                        button_state_build(super_array[j], i, end_of_array);
                    }
                }
            }
        }

        //does the actual parsing of information for each button state and records in Button struct
        //this struct is then put into an array of type Button
        public void button_state_build(string button_pointer, int boolean_index, bool end_flag)
        {
            //TODO: try to get non-hardcoded version of Square() working
            //      i think we'll need a struct of button structs to create dualshockstate-like struct
            //      then will make array of dualshockstate structs to port out to build-script-class.
            //      this requires a button struct for every button
            //      atm it needs: isbuttonpressed flag, startofpress time, endofpress time
            //      thought is start will be null if not pressed and end will be null if is pressed?
        }

        public void Square()
        {
           int counter = 0;
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
                Square();
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
