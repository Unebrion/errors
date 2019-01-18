using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using static ConsoleApp1.buttonState;

namespace ConsoleApp1
{
    //andysucks.com
    class scriptBuilder
    {
        Double square_start;
        Double square_end;
        string macro_txt;
        StreamWriter output_text_file;

        public scriptBuilder()
        {
            square_start = 0;
            square_end = 0;
            macro_txt = "../../../macro.txt";

            if (File.Exists(macro_txt))
            {
                File.Delete(macro_txt);
            }
            output_text_file = new StreamWriter(macro_txt, true);

        }

        public void output_file()
        {
            //state_output
            //Press(new DualShockState() {BUTTON = BOOL });
            // I hate error checking Suuuuuuuuuuuuuuuck
            //it gets mad when there is nulls... so much typing required

            foreach (var button in state_output)
            {

                //square case//

                //if there is a start time
                if (button.square.start_time != null)
                {
                    square_start = Double.Parse(button.square.start_time.Substring(17, 8));
                }
                //if there is an end time
                else if (button.square.end_time != null)
                {
                    square_end = Double.Parse(button.square.end_time.Substring(17, 8));
                }

                if (square_start != 0 && square_end != 0)
                {
                    Double difference = 0;
                    difference = square_end - square_start;
                    output_text_file.WriteLine("Press (new DualShockState() {Square = True)");
                    output_text_file.WriteLine("Sleep({0})", difference);
                    square_start = 0;
                    square_end = 0;
                }
            }

            //gotta have this our it won't put stuff in txt. I dunno why
            output_text_file.Close();
        }//output_file()

    }


}         
