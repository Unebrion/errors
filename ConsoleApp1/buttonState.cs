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
        const string SQUARE               = "Square";
        const string CIRCLE               = "Circle";
        const string TRIANGLE             = "Triangle";
        const string CROSS                = "Cross";
        const string DPAD_UP              = "DPad_Up";
        const string DPAD_DOWN            = "DPad_Down";
        const string DPAD_LEFT            = "DPad_Left";
        const string DPAD_RIGHT           = "DPad_Right";
        static string[] const_button_arr  = { SQUARE,
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
        single_button[] timeCalc;
        single_button[] trimmedCalc;
        int xml_length;
        int const_button_arr_length = const_button_arr.Length;
        IList<state_button> state_output = new List<state_button>();
        string absolute_start_time;
        string absolute_end_time;


        //state of a single button (single 0 or 1 in matrix)
        public struct single_button
        {
            public bool   is_pressed;
            public string start_time;          
            public string end_time;
                   
        }

        //state of controller (all buttons) in an instant of time
        public struct state_button
        {
            public single_button square;
            public single_button circle;
            public single_button cross;
            public single_button triangle;
            public single_button dpad_up;
            public single_button dpad_down;
            public single_button dpad_left;
            public single_button dpad_right;
            public string inst_time;
        }

        //default constructor
        public buttonState()
        {
            try
            {
                Console.WriteLine("Enter file path:");
                xmlDoc.Load(Console.ReadLine());

                timestamp_nodelist    = xmlDoc.GetElementsByTagName("ReportTimeStamp");
                square_nodelist       = xmlDoc.GetElementsByTagName("Square");
                cross_nodelist        = xmlDoc.GetElementsByTagName("Cross");
                circle_nodelist       = xmlDoc.GetElementsByTagName("Circle");
                triangle_nodelist     = xmlDoc.GetElementsByTagName("Triangle");
                dpad_up_nodelist      = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist   = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist    = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist    = xmlDoc.GetElementsByTagName("DPad_Left");
                xml_length            = timestamp_nodelist.Count;

                timeCalc = new single_button[xmlDoc.GetElementsByTagName("Square").Count];
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
                xmlDoc = xml;

                timestamp_nodelist    = xmlDoc.GetElementsByTagName("ReportTimeStamp");
                square_nodelist       = xmlDoc.GetElementsByTagName("Square");
                cross_nodelist        = xmlDoc.GetElementsByTagName("Cross");
                circle_nodelist       = xmlDoc.GetElementsByTagName("Circle");
                triangle_nodelist     = xmlDoc.GetElementsByTagName("Triangle");
                dpad_up_nodelist      = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist   = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist    = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist    = xmlDoc.GetElementsByTagName("DPad_Left");
                xml_length            = timestamp_nodelist.Count;

                timeCalc = new single_button[xmlDoc.GetElementsByTagName("Square").Count];
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
            }
        }

        //top-level method for scanning through xml file and getting information for each dualshock state
        public void scan_xml()
        {
            bool start_of_array = false;
            bool end_of_array = false;
            single_button temp_button;

            try
            {
                //iterate through boolean array lengths
                for (int i = 0; i <= xml_length - 1; i++)
                {
                    //TODO: convert absolute times to doubles
                    if (i == 0)
                    {
                        absolute_start_time = timestamp_nodelist[i].InnerText;
                        start_of_array = true;
                    }
                    state_button temp_state = new state_button();

                    for (int j = 0; j <= const_button_arr_length - 1; j++)
                    {
                        //generic button info gatherer
                        if (i == (xml_length - 1))
                        {
                            //special condition end of boolean array
                            end_of_array = true;
                            absolute_end_time = timestamp_nodelist[i].InnerText;
                        }

                        temp_button = build_single_button(const_button_arr[j], i, start_of_array, end_of_array);
                        temp_state = build_button_state(const_button_arr[j], temp_button, temp_state);
                    }

                    state_output.Add(temp_state);
                }
            }
            catch(ArgumentNullException ex)
            {
                Console.Write("Error occurred: {0}", ex.Message);
            }
        }

        //does the actual parsing of information for each button state and records in Button struct
        //this struct is then put into an array of type Button
        public single_button build_single_button(string button_pointer, int boolean_index, bool start_flag, bool end_flag)
        {
            int counter = 0;
            single_button temp_button = new single_button();

            XmlNodeList current_button = find_curr_button(button_pointer);
            if (current_button == null)
                throw new ArgumentNullException("Invalid current button");

            //last entry - all buttons last press
            if (end_flag)
            {
                Console.Write("end of array");
                    
                //  Console.WriteLine(sq[i].InnerText);
                //  Console.WriteLine("end of array, take this time and subtract");    

                //timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
                //timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
                //  Console.WriteLine("if i == sq.count -1");
                // Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
            }
            //start entry - can't look backwards
            else if (start_flag)
            {
                Console.Write("start of array");
            }
            else
            {
                //end a button press
                if (current_button[boolean_index - 1].InnerText == "true" && current_button[boolean_index].InnerText == "false")
                {
                    temp_button.is_pressed = false;
                    // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                    Console.WriteLine();
                    Console.WriteLine("went from true to false");
                    timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
                    timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
                    Console.WriteLine("if square is true");
                    Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
                    counter++;
                }

                //start a button press
                else if (square_nodelist[boolean_index].InnerText == "false" && square_nodelist[boolean_index + 1].InnerText == "true")
                {
                    // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                    //Console.WriteLine("crassssh");
                    Console.WriteLine();
                    timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
                    timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
                    Console.WriteLine("if square is false");
                    Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
                    Console.WriteLine("attempting to print length of time calc: {0}", timeCalc.Length);
                    //  Console.WriteLine("print out timeclock.sq_bool: {0}",timeCalc[i].Sq_Bool);
                    counter++;
                }//else if

                    
            }//else

            return temp_button;
        }

        public XmlNodeList find_curr_button(string button_pointer)
        {
            //TODO: maybe combine find_curr_button and build_button_state? different return types..
            XmlNodeList return_list;
            switch (button_pointer)
            {
                case SQUARE:
                    return_list = square_nodelist;
                    break;
                case CIRCLE:
                    return_list = circle_nodelist;
                    break;
                case TRIANGLE:
                    return_list = triangle_nodelist;
                    break;
                case CROSS:
                    return_list = cross_nodelist;
                    break;
                case DPAD_UP:
                    return_list = dpad_up_nodelist;
                    break;
                case DPAD_DOWN:
                    return_list = dpad_down_nodelist;
                    break;
                case DPAD_LEFT:
                    return_list = dpad_left_nodelist;
                    break;
                case DPAD_RIGHT:
                    return_list = dpad_right_nodelist;
                    break;
                default:
                    return_list = null;
                    break;
            }
            return return_list;
        }

        public state_button build_button_state(string button_pointer, single_button inst_button, state_button temp_state)
        {
            //TODO: create helper to check for null later. should not overwrite data
            switch (button_pointer)
            {
                case SQUARE:
                    temp_state.square = inst_button;
                    break;
                case CIRCLE:
                    temp_state.circle = inst_button;
                    break;
                case TRIANGLE:
                    temp_state.triangle = inst_button;
                    break;
                case CROSS:
                    temp_state.cross = inst_button;
                    break;
                case DPAD_UP:
                    temp_state.dpad_up = inst_button;
                    break;
                case DPAD_DOWN:
                    temp_state.dpad_down = inst_button;
                    break;
                case DPAD_LEFT:
                    temp_state.dpad_left = inst_button;
                    break;
                case DPAD_RIGHT:
                    temp_state.dpad_right = inst_button;
                    break;
                default:
                    break;
            }
            return temp_state;
        }
        //    public void Square()
        //    {
        //       int counter = 0;
        //        for (int i = 0; i <= square_nodelist.Count - 1; i++)
        //        {

        //            if (i == (square_nodelist.Count - 1))
        //            {
        //                Console.WriteLine();
        //                //  Console.WriteLine(sq[i].InnerText);
        //                //  Console.WriteLine("end of array, take this time and subtract");    
        //                //timeCalcList.Add(sq[i].InnerText);
        //                //timeCalcList.Add(sq[i].InnerText);                  
        //                timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
        //                timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17,8));     
        //              //  Console.WriteLine("if i == sq.count -1");
        //               // Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
        //                counter++;
        //            }

        //            else
        //            {
        //                if (square_nodelist[i].InnerText == "true" && square_nodelist[i + 1].InnerText == "false")
        //                {
        //                    // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
        //                    Console.WriteLine();
        //                    Console.WriteLine("went from true to false");
        //                    timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
        //                    timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
        //                    Console.WriteLine("if square is true");
        //                    Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
        //                    counter++;
        //                }

        //                else if (square_nodelist[i].InnerText == "false" && square_nodelist[i + 1].InnerText == "true")
        //                {
        //                    // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
        //                    //Console.WriteLine("crassssh");
        //                    Console.WriteLine();
        //                    timeCalc[counter].Sq_Bool = square_nodelist[i].InnerText;
        //                    timeCalc[counter].sq_Time = Double.Parse(timestamp_nodelist[i].InnerText.Substring(17, 8));
        //                    Console.WriteLine("if square is false");
        //                    Console.WriteLine("time calc has: {0}, {1}", timeCalc[counter].Sq_Bool, timeCalc[counter].sq_Time);
        //                    Console.WriteLine("attempting to print length of time calc: {0}",timeCalc.Length);
        //                    //  Console.WriteLine("print out timeclock.sq_bool: {0}",timeCalc[i].Sq_Bool);
        //                    counter++;
        //                }//else if
        //            }//else
        //        }//for loop

        //        //this does the time calculation 
        //        for (int i = 0; i <= timeCalc.Length - 1; i++)
        //        {
        //            if (i == (timeCalc.Length - 1))
        //            {
        //                Console.WriteLine("last entry I think");
        //            }

        //            else
        //            {
        //                if (timeCalc[i].Sq_Bool == "true" && timeCalc[i + 1].Sq_Bool == "false")
        //                {
        //                    Double x = timeCalc[i + 1].sq_Time - timeCalc[i].sq_Time;
        //                    Console.WriteLine("attempting the math: {0}", x);
        //                }

        //                //this isn't necessary I don't think
        //                else
        //                {
        //                   // Console.WriteLine("do I ever see this?");
        //                }//nested else
        //            }//else
        //        }//for loop

        //    }//square

        //    public void Calc()
        //    {
        //        int count = 0;
        //        for (int i = 0; i < timeCalc.Length - 1; i++)
        //        {
        //            Square();
        //            count++;
        //        }

        //        Console.WriteLine("timecalc.length is: {0}",timeCalc.Length); 
        //    }

        //    public void trim_Array()
        //    {
        //        //if all buttons .i = 0 then new array = i.length
        //        trimmedCalc = timeCalc;
        //        int counter = 0;
        //        //Console.WriteLine("trimmed calc at index 0: {0}",trimmedCalc[0].sq_Time);


        //        //checks if there is a time value this may need adjusted since it is only checking square. Could do lots of &&'s for each button. Time seems like the right value
        //        for (int i = 0; i < timeCalc.Length - 1; i++)
        //        {

        //            if (timeCalc[i].sq_Time != 0)
        //            {
        //                counter++;
        //            }            

        //        }  //for loop     

        //        //resizes the Array after the button press lengths are written
        //        Array.Resize(ref timeCalc, counter);

        //        //checking the contents of the array
        //        for (int i = 0; i < timeCalc.Length; i++)
        //        {
        //            Console.WriteLine("Index: {0} sq_bool is: {1} and sq_time is: {2}", i, timeCalc[i].Sq_Bool, timeCalc[i].sq_Time);
        //        }

        //    }//trim array
    }//button state
}//namespace
