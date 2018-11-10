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
        const string SQUARE = "Square";
        const string CIRCLE = "Circle";
        const string TRIANGLE = "Triangle";
        const string CROSS = "Cross";
        const string DPAD_UP = "DPad_Up";
        const string DPAD_DOWN = "DPad_Down";
        const string DPAD_LEFT = "DPad_Left";
        const string DPAD_RIGHT = "DPad_Right";
        static string[] const_button_arr = { SQUARE,
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
        XmlNodeList square_nodelist,
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
        bool DEBUG = true;


        //state of a single button (single 0 or 1 in matrix)
        public struct single_button
        {
            public bool is_pressed;
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

                timestamp_nodelist = xmlDoc.GetElementsByTagName("ReportTimeStamp");
                square_nodelist = xmlDoc.GetElementsByTagName("Square");
                cross_nodelist = xmlDoc.GetElementsByTagName("Cross");
                circle_nodelist = xmlDoc.GetElementsByTagName("Circle");
                triangle_nodelist = xmlDoc.GetElementsByTagName("Triangle");
                dpad_up_nodelist = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist = xmlDoc.GetElementsByTagName("DPad_Left");
                xml_length = timestamp_nodelist.Count;

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

                timestamp_nodelist = xmlDoc.GetElementsByTagName("ReportTimeStamp");
                square_nodelist = xmlDoc.GetElementsByTagName("Square");
                cross_nodelist = xmlDoc.GetElementsByTagName("Cross");
                circle_nodelist = xmlDoc.GetElementsByTagName("Circle");
                triangle_nodelist = xmlDoc.GetElementsByTagName("Triangle");
                dpad_up_nodelist = xmlDoc.GetElementsByTagName("DPad_Up");
                dpad_right_nodelist = xmlDoc.GetElementsByTagName("DPad_Right");
                dpad_down_nodelist = xmlDoc.GetElementsByTagName("DPad_Down");
                dpad_left_nodelist = xmlDoc.GetElementsByTagName("DPad_Left");
                xml_length = timestamp_nodelist.Count;

                timeCalc = new single_button[xmlDoc.GetElementsByTagName("Square").Count];
            }
            catch (FileNotFoundException ex)
            {
                Console.Write("Exception occured: {0}", ex.Message);
            }
        }

        //top-level method for scanning through xml file and getting information for each dualshock state
        public IList<state_button> scan_xml()
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
                    else
                    {
                        start_of_array = false;
                    }

                    state_button temp_state = new state_button();

                    for (int j = 0; j <= const_button_arr_length - 1; j++)
                    {
                        if (i == (xml_length - 1))
                        {
                            //special condition end of boolean array
                            end_of_array = true;
                            absolute_end_time = timestamp_nodelist[i].InnerText;
                        }
                        //generic button info gatherer
                        temp_button = build_single_button(const_button_arr[j], i, start_of_array, end_of_array);
                        temp_state = build_button_state(const_button_arr[j], temp_button, temp_state);
                    }

                    temp_state.inst_time = timestamp_nodelist[i].InnerText;
                    state_output.Add(temp_state);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.Write("Error occurred: {0}", ex.Message);
            }

            if (DEBUG)
            {
                print_output(state_output);
                Console.ReadLine();
            }
            return state_output;
        }

        //does the actual parsing of information for each button state and records in Button struct
        //this struct is then put into an array of type Button
        //button pressed flag should always be true or false, times can be null - subject to change
        public single_button build_single_button(string button_pointer, int boolean_index, bool start_flag, bool end_flag)
        {
            single_button temp_button = new single_button();

            XmlNodeList current_button = find_curr_button(button_pointer);
            if (current_button == null)
                throw new ArgumentNullException("Invalid current button");

            //last entry - all buttons last press
            if (end_flag)
            {
                temp_button.is_pressed = false;
                temp_button.end_time = timestamp_nodelist[boolean_index].InnerText;
                temp_button.start_time = null;
            }
            //start entry - can't look backwards
            else if (start_flag)
            {
                //set up pressed flags regardless of pressed
                if (current_button[boolean_index].InnerText == "true")
                {
                    temp_button.is_pressed = true;
                    temp_button.end_time = null;
                    temp_button.start_time = timestamp_nodelist[boolean_index].InnerText;
                }
                else
                {
                    temp_button.is_pressed = false;
                    temp_button.end_time = null;
                    temp_button.start_time = timestamp_nodelist[boolean_index].InnerText;
                }
            }
            else
            {
                //sustain button press
                if (current_button[boolean_index - 1].InnerText == "true" && current_button[boolean_index].InnerText == "true")
                {
                    temp_button.is_pressed = true;
                    temp_button.end_time = null;
                    temp_button.start_time = null;
                }

                //sustain not press
                else if (current_button[boolean_index - 1].InnerText == "false" && current_button[boolean_index].InnerText == "false")
                {
                    temp_button.is_pressed = false;
                    temp_button.end_time = null;
                    temp_button.start_time = null;
                }

                //end a button press
                else if (current_button[boolean_index - 1].InnerText == "true" && current_button[boolean_index].InnerText == "false")
                {
                    temp_button.is_pressed = false;
                    temp_button.end_time = timestamp_nodelist[boolean_index].InnerText;
                    temp_button.start_time = null;
                }

                //start a button press
                else if (current_button[boolean_index - 1].InnerText == "false" && current_button[boolean_index].InnerText == "true")
                {
                    temp_button.is_pressed = true;
                    temp_button.end_time = null;
                    temp_button.start_time = timestamp_nodelist[boolean_index].InnerText;
                }
                //error
                else
                {
                    temp_button.is_pressed = false;
                    temp_button.end_time = null;
                    temp_button.start_time = null;
                }


            }

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

        public void print_output(IList<state_button> state_output)
        {
            int i = 0;
            foreach (var button in state_output)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("== State {0}", i);
                Console.WriteLine("========================================================================");
                Console.WriteLine("SQUARE");
                Console.WriteLine(button.square.is_pressed);
                Console.WriteLine(button.square.start_time);
                Console.WriteLine(button.square.end_time);
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("TRIANGLE");
                Console.WriteLine(button.triangle.is_pressed);
                Console.WriteLine(button.triangle.start_time);
                Console.WriteLine(button.triangle.end_time);
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("CIRCLE");
                Console.WriteLine(button.circle.is_pressed);
                Console.WriteLine(button.circle.start_time);
                Console.WriteLine(button.circle.end_time);
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("CROSS");
                Console.WriteLine(button.cross.is_pressed);
                Console.WriteLine(button.cross.start_time);
                Console.WriteLine(button.cross.end_time);
                i++;
            }
            

        }
    }

}//namespace
