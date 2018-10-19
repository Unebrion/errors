using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace ConsoleApp1
{

    class buttonState
    {
        
        XmlDocument xmlDoc = new XmlDocument();
        //Button CurrentState = new Button();

        // I want to make this array equal to sq.count for example I don't know how
        //also you suck
        Button[] timeCalc = new Button[7];
     
        struct Button
        {
            public String isPressed;
            public String timePressed;
        }

        //default constructor
        public buttonState()
        {

        }

        public buttonState(XmlDocument xml)
        {
            xmlDoc = xml;
        }

        public void Square()
        {
            XmlNodeList sq = xmlDoc.GetElementsByTagName("Square");

            for (int i = 0; i <= sq.Count - 1; i++)
            {

                if (i == (sq.Count - 1))
                {
                    Console.WriteLine(sq[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (sq[i].InnerText == "true" && sq[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (sq[i].InnerText == "false" && sq[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//square

        public void Cross()
        {
            XmlNodeList cr = xmlDoc.GetElementsByTagName("Cross");

            for (int i = 0; i <= cr.Count - 1; i++)
            {

                if (i == (cr.Count - 1))
                {
                    Console.WriteLine(cr[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (cr[i].InnerText == "true" && cr[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (cr[i].InnerText == "false" && cr[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Cross

        public void Circle()
        {
            XmlNodeList ci = xmlDoc.GetElementsByTagName("Circle");

            for (int i = 0; i <= ci.Count - 1; i++)
            {

                if (i == (ci.Count - 1))
                {
                    Console.WriteLine(ci[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (ci[i].InnerText == "true" && ci[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (ci[i].InnerText == "false" && ci[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Circle

        public void Triangle()
        {
            XmlNodeList tr = xmlDoc.GetElementsByTagName("Triangle");

            for (int i = 0; i <= tr.Count - 1; i++)
            {

                if (i == (tr.Count - 1))
                {
                    Console.WriteLine(tr[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (tr[i].InnerText == "true" && tr[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (tr[i].InnerText == "false" && tr[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Triangle

        public void L1()
        {
            XmlNodeList l1 = xmlDoc.GetElementsByTagName("L1");

            for (int i = 0; i <= l1.Count - 1; i++)
            {

                if (i == (l1.Count - 1))
                {
                    Console.WriteLine(l1[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (l1[i].InnerText == "true" && l1[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (l1[i].InnerText == "false" && l1[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//L1

        public void R1()
        {
            XmlNodeList r1 = xmlDoc.GetElementsByTagName("R1");

            for (int i = 0; i <= r1.Count - 1; i++)
            {

                if (i == (r1.Count - 1))
                {
                    Console.WriteLine(r1[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (r1[i].InnerText == "true" && r1[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (r1[i].InnerText == "false" && r1[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//R1

        public void DPad_Up()
        {
            XmlNodeList du = xmlDoc.GetElementsByTagName("DPad_Up");

            for (int i = 0; i <= du.Count - 1; i++)
            {

                if (i == (du.Count - 1))
                {
                    Console.WriteLine(du[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (du[i].InnerText == "true" && du[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (du[i].InnerText == "false" && du[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Dpad Up

        public void DPad_Right()
        {
            XmlNodeList dr = xmlDoc.GetElementsByTagName("DPad_Right");

            for (int i = 0; i <= dr.Count - 1; i++)
            {

                if (i == (dr.Count - 1))
                {
                    Console.WriteLine(dr[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (dr[i].InnerText == "true" && dr[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (dr[i].InnerText == "false" && dr[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Dpad Right

        public void DPad_Down()
        {
            XmlNodeList dDo = xmlDoc.GetElementsByTagName("DPad_Down");

            for (int i = 0; i <= dDo.Count - 1; i++)
            {

                if (i == (dDo.Count - 1))
                {
                    Console.WriteLine(dDo[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (dDo[i].InnerText == "true" && dDo[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (dDo[i].InnerText == "false" && dDo[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Dpad down

        public void DPad_Left()
        {
            XmlNodeList dl = xmlDoc.GetElementsByTagName("DPad_Left");

            for (int i = 0; i <= dl.Count - 1; i++)
            {

                if (i == (dl.Count - 1))
                {
                    Console.WriteLine(dl[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                }
                else
                {
                    if (dl[i].InnerText == "true" && dl[i + 1].InnerText == "false")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));

                        Console.WriteLine("went from true to false");
                    }

                    else if (dl[i].InnerText == "false" && dl[i + 1].InnerText == "true")
                    {
                        // timeDifference[i] = Double.Parse(time[i].InnerText.Substring(17, 8));
                        Console.WriteLine("crassssh");
                    }
                }//else
            }//for loop
        }//Dpad Left





    }//button state
}//namespace
