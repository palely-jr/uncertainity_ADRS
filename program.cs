using System;
using System.IO;
using System.Linq;
using static System.Console;
using System.Threading.Tasks;
using System.Collections;

namespace Research
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = System.Text.Encoding.Unicode;
            sensorVulnerability();

        }

        public static void sensorVulnerability()
        {
           bool sensorValCheck = true;
            while (sensorValCheck)
            {
                int noOfSensors = 0;


                while (noOfSensors < 5)
                {
                    WriteLine("\nEnter the number of sensors minimun 5:");
                    int.TryParse(ReadLine(), out noOfSensors);

                }

                float[] sensorVal = new float[noOfSensors];
                for (int i = 0; i < noOfSensors; i++)
                {



                    WriteLine("\nEnter the value for sensor {0}", i);
                    string sensorValue = ReadLine();
                    float check;
                    if (!float.TryParse(sensorValue, out check))
                    {

                        while (!float.TryParse(sensorValue, out check))
                        {

                            WriteLine(i);
                            WriteLine("\nIncorrect Input.Enter the value for sensor {0}", i);
                            sensorVal[i] = check;


                        }
                    }
                    else
                    {


                        float.TryParse(sensorValue, out sensorVal[i]);


                    }




                }

                float smallest = sensorVal[0];


                for (int i = 0; i < noOfSensors; i++)

                {
                    if (sensorVal[i] < smallest)
                    {

                        smallest = sensorVal[i];

                    }
                }

                float largest = sensorVal[noOfSensors - 1];

                for (int i = 0; i < noOfSensors; i++)
                {

                    if (sensorVal[i] > largest)
                    {

                        largest = sensorVal[i];



                    }
                }





                ArrayList smallestArrayIndex = new ArrayList();
                ArrayList largestArrayIndex = new ArrayList();
                //Checks the difference betwwen smallest and largest value in the sensor network
                if ((FindDifference(largest, smallest)) > 10)
                {

                    WriteLine("\nUncertainty Found");

                    for (int i = 0; i < noOfSensors; i++)
                    {


                        if ((FindDifference(largest, sensorVal[i])) > 10)
                        {



                            largestArrayIndex.Add(i);


                        }

                        if ((FindDifference(sensorVal[i], smallest)) > 10)
                        {

                            smallestArrayIndex.Add(i);





                        }





                    }

                    try
                    {



                        bool UncertaintyChecker = true;

                        if (largestArrayIndex.Count > smallestArrayIndex.Count)
                        {

                            UncertaintyChecker = smallestRecheck(sensorVal, largest, smallest, smallestArrayIndex);

                        }
                        else
                        {

                            UncertaintyChecker = largestRecheck(sensorVal, largest, smallest, largestArrayIndex);

                        }

                        if (!UncertaintyChecker)
                        {

                            WriteLine("\nDo you want to continue or exit. Enter 1 to continue any other key to exit");
                            int value = 0;
                            if (int.TryParse(ReadLine(), out value) && int.Parse(ReadLine()) == 1)
                            {





                            }
                            else
                            {
                                sensorValCheck = false;

                            }



                        }






                    }
                    catch
                    {
                        WriteLine("\nsome error");
                    }


                }
                else
                {



                    bool accidentcheck = false;

                    accidentcheck = accidentRead(sensorVal);

                    if (!accidentcheck)
                    {

                        WriteLine("\nDo you want to continue or exit. Enter 1 to continue any other key to exit");
                        int value = 0;
                        string continueOrQuit = ReadLine();
                        if (int.TryParse(continueOrQuit, out value) && int.Parse(continueOrQuit) == 1)
                        {





                        }
                        else
                        {
                            sensorValCheck = false;

                        }



                    }





                }





            }


        }

        public static float FindDifference(float nr1, float nr2)
        {
            return Math.Abs(nr1 - nr2);
        }


        public static bool smallestRecheck(float[] sensorVal, float largest, float smallest, ArrayList smallestArrayIndex)
        {


          
            bool smallestArrayRecheck = true;
            while (smallestArrayRecheck)
            {

                for (int i = 0; i < smallestArrayIndex.Count; i++)
                {
                    WriteLine("\nPlease enter the value of Sensor {0} again:", smallestArrayIndex[i]);


                    float smallestsensorVal;
                    string sensorValue = ReadLine();
                    if (!float.TryParse(sensorValue, out smallestsensorVal))
                    {
                        while (!float.TryParse(sensorValue, out smallestsensorVal))
                        {
                            WriteLine("\nIncorrect Input.Please enter the value of Sensor {0} again:", smallestArrayIndex[i]);
                            sensorVal[int.Parse(smallestArrayIndex[i].ToString())] = smallestsensorVal;
                        }


                    }
                    else
                    {


                        sensorVal[int.Parse(smallestArrayIndex[i].ToString())] = float.Parse(sensorValue);



                    }


                    if ((FindDifference(largest, sensorVal[int.Parse(smallestArrayIndex[i].ToString())])) > 10)
                    {

                        WriteLine("\nUncertainity Prevails.Value of Sensor {0} Ignored:", smallestArrayIndex[i]);
                        sensorVal = sensorVal.Where((source, index) => index != int.Parse(smallestArrayIndex[i].ToString())).ToArray();




                    }




                }


                bool accidentcheck = false;

                accidentcheck = accidentRead(sensorVal);


                smallestArrayRecheck = accidentcheck;









            }

            return smallestArrayRecheck;
        }


        public static bool largestRecheck(float[] sensorVal, float largest, float smallest, ArrayList largestArrayIndex)
        {



            bool largestArrayRecheck = true;
            while (largestArrayRecheck)
            {

                for (int i = 0; i < largestArrayIndex.Count; i++)
                {
                    WriteLine("\nPlease enter the value of Sensor {0} again:", largestArrayIndex[i]);



                    float largestsensorVal;
                    string largesensorVal = ReadLine();
                    if (!float.TryParse(largesensorVal, out largestsensorVal))
                    {
                        while (!float.TryParse(largesensorVal, out largestsensorVal))
                        {
                            WriteLine("\nIncorrect Input.Please enter the value of Sensor {0} again:", largestArrayIndex[i]);
                            sensorVal[int.Parse(largestArrayIndex[i].ToString())] = largestsensorVal;
                        }


                    }
                    else
                    {


                        sensorVal[int.Parse(largestArrayIndex[i].ToString())] = float.Parse(largesensorVal);



                    }

                    if (((FindDifference(largest,sensorVal[int.Parse(largestArrayIndex[i].ToString())])) > 10))
                    {

                        WriteLine("\nUncertainity Prevails.Value of Sensor {0} Ignored", largestArrayIndex[i]);
                        sensorVal = sensorVal.Where((source, index) => index != int.Parse(largestArrayIndex[i].ToString())).ToArray();




                    }

                    




                }

                bool accidentcheck = false;

                accidentcheck = accidentRead(sensorVal);


                largestArrayRecheck = accidentcheck;













            }

            return largestArrayRecheck;
        }

        public static bool accidentRead(float[] sensorVal)

        {

            WriteLine("\n\nNo Uncertainity. Checking For accident ");

            float sum = 0;
            float average = 0;
            for (var i = 0; i < sensorVal.Length; i++)
            {
                sum += sensorVal[i];
            }
            average = sum / sensorVal.Length;




            WriteLine("\n\nNumber of Sensors is {0}", sensorVal.Length);

            for (int n = 0; n > sensorVal.Length; n++) {

                WriteLine("\n\nNumber of Sensors is {0}{1}", sensorVal[n],n);



            }



            WriteLine("\n\nSensor Value Average is {0}", average);
            WriteLine("\n\nEnter average sensor ouput in an accident");

            float accidentvalue;
            string accidentVal = ReadLine();
            if (!float.TryParse(accidentVal, out accidentvalue))
            {
                while (!float.TryParse(accidentVal, out accidentvalue))
                {
                    WriteLine("\nIncorrect Input.Enter average sensor ouput in an accident");
                    accidentvalue = float.Parse(accidentVal);
                }
            }
            else
            {

                accidentvalue = float.Parse(accidentVal);

            }


            if (accidentvalue < average)
            {

                WriteLine("\n\n \n \n ");
                WriteLine("\n                     ------------------------------------------------------------------");
                WriteLine("\n                     |*****************************************************************|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                 Accident Detected                             *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*               Press any key to continue                       *|");
                WriteLine("\n                     |*****************************************************************|");
                WriteLine("\n                     ------------------------------------------------------------------");
                ReadKey();


            }
            else
            {

                WriteLine("\n\n \n \n ");
                WriteLine("\n                     ------------------------------------------------------------------");
                WriteLine("\n                     |*****************************************************************|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                 Accident Not detected                         *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*                                                               *|");
                WriteLine("\n                     |*               Press any key to continue                       *|");
                WriteLine("\n                     |*****************************************************************|");
                WriteLine("\n                     ------------------------------------------------------------------");
                ReadKey();







            }

            return false;

        }




    }
}
