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
        //Button[] timeCalc = new Button[];
        //asshole c# won't let me declare like this
        // XmlNodeList sq, ci,tr,l1,r1,du,dr,dDo,dl;


        XmlNodeList sq;
        XmlNodeList tr;
        XmlNodeList cr;
        XmlNodeList ci;
        XmlNodeList l1;
        XmlNodeList r1;
        XmlNodeList du;
        XmlNodeList dr;
        XmlNodeList dDo;
        XmlNodeList dl;
        Button[] timeCalc;
        struct Button
        {
            public String isPressed;
            public String timePressed;
            public String s1, s2, s3;
            
            
        }

        //default constructor
        public buttonState()
        {

        }

        public buttonState(XmlDocument xml)
        {
            //XmlDocument xmlDoc = new XmlDocument();
            //cr,ci,tr,l1,r1,du,dr,dDo,dl;

            xmlDoc = xml;
            timeCalc = new Button[xmlDoc.GetElementsByTagName("Square").Count];
            sq = xmlDoc.GetElementsByTagName("Square");
            cr = xmlDoc.GetElementsByTagName("Cross");
            ci = xmlDoc.GetElementsByTagName("Circle");
            tr = xmlDoc.GetElementsByTagName("Triangle");
            l1 = xmlDoc.GetElementsByTagName("L1");
            r1 = xmlDoc.GetElementsByTagName("R1");
            du = xmlDoc.GetElementsByTagName("DPad_Up");
            dr = xmlDoc.GetElementsByTagName("DPad_Right");
            dDo = xmlDoc.GetElementsByTagName("DPad_Down");
            dl = xmlDoc.GetElementsByTagName("DPad_Left");
        }

        public void Square()
        {
           // XmlNodeList sq = xmlDoc.GetElementsByTagName("Square");
           
           
            for (int i = 0; i <= sq.Count - 1; i++)
            {

                if (i == (sq.Count - 1))
                {
                    Console.WriteLine(sq[i].InnerText);
                    Console.WriteLine("end of array, take this time and subtract");
                    timeCalc[i].isPressed = sq[i].InnerText;
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
            //XmlNodeList ci = xmlDoc.GetElementsByTagName("Circle");

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
            //XmlNodeList tr = xmlDoc.GetElementsByTagName("Triangle");

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
            //XmlNodeList l1 = xmlDoc.GetElementsByTagName("L1");

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
            //XmlNodeList r1 = xmlDoc.GetElementsByTagName("R1");

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
            //XmlNodeList du = xmlDoc.GetElementsByTagName("DPad_Up");

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
            //XmlNodeList dr = xmlDoc.GetElementsByTagName("DPad_Right");

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
            //XmlNodeList dDo = xmlDoc.GetElementsByTagName("DPad_Down");

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
            //XmlNodeList dl = xmlDoc.GetElementsByTagName("DPad_Left");

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
