
// COP 4365 – Spring 2022
// Homework #4: Traffic Study
// Description: Updated traffic light calculating how many cars are coming from each direction, the maximum size of the car line, how long each car waited, and the average wait time
// File name: Traffic Study
// By: Sophia Hostetler
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TrafficStudy

{
    class Program
    {
        static Int64 Secs(DateTime dt)
        {
            var delta = dt - new DateTime(1970, 1, 1);
            return Convert.ToInt64(delta.TotalSeconds);
        }

        static void TrafficLightSimulator(int numSeconds)

        {
            DateTime dt = DateTime.Now;
            Int64 realTime = Secs(dt);
            long Start;
           

            Int64 realElapsed, timer = 0;
            long realConstantStart = realTime; 

            bool lightChange = false;

            string car; int seqNo;
            var reader = new StreamReader(File.OpenRead("Data.txt"));
            //read data file

            List<Car> NorthQueue = new List<Car>();
            List<Car> SouthQueue = new List<Car>();
            List<Car> EastQueuee = new List<Car>();
            List<Car> WestQueue = new List<Car>();

            //intialize variables
            int numNorthCars = 0, numSouthCars = 0, numWestCars = 0, numEastCars = 0;

            int AvgNorthTime = 0, AvgSouthTime = 0, AvgWestTime = 0, AvgEastTime = 0;

            int maxLengthNorth = 0, maxLengthSouth = 0, maxLengthEast = 0, maxLengthWest = 0;


            TrafficLight NorthLight = new TrafficLight();

            TrafficLight SouthLight = new TrafficLight();

            TrafficLight EastLight = new TrafficLight();

            TrafficLight WestLight = new TrafficLight();

            TrafficLight northP = NorthLight;

            TrafficLight southP = SouthLight;

            TrafficLight eastP = EastLight;

            TrafficLight westP = WestLight;

            //while loop going through and tracking cars
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                car = line;
                seqNo = (int)line[1];
                int aTime = Int32.Parse(car.Substring(1));

                if (car[0] == 'N')

                {

                    NorthQueue.Add(new Car(seqNo, aTime, 0));

                    if (maxLengthNorth < NorthQueue.Count)

                        maxLengthNorth = NorthQueue.Count;

                    numNorthCars++;



                }

                if (car[0] == 'S')

                {

                    SouthQueue.Add(new Car(seqNo, aTime, 0));

                    if (maxLengthNorth < EastQueuee.Count)

                        maxLengthNorth = EastQueuee.Count;

                    numSouthCars++;

                }

                if (car[0] == 'E')

                {

                    EastQueuee.Add(new Car(seqNo, aTime, 0));

                    if (maxLengthEast < EastQueuee.Count)

                        maxLengthEast = EastQueuee.Count;

                    numEastCars++;

                }

                if (car[0] == 'W')

                {

                    WestQueue.Add(new Car(seqNo, aTime, 0));

                    if (maxLengthWest < WestQueue.Count)

                        maxLengthWest = WestQueue.Count;

                    numWestCars++;



                }

            }

            Console.WriteLine("Elapsed Time " + "North Light " + "South Light " + "East Light " + "West Light");

            Console.WriteLine("------------ ----------- ----------- ----------- -----------");

            //while loop that keeps track of time from start and controls how long to run program
            while (timer < numSeconds) 

            {

                Start = realTime;
                dt = DateTime.Now;
                realTime = Secs(dt);
                do
                {

                    dt = DateTime.Now;
                    realTime = Secs(dt);
                    realElapsed = realTime - Start;
                    timer = realTime - realConstantStart;
                    if (realElapsed == 0)

                    {
                        northP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 6)
                    {
                        southP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 9)

                    {
                        northP.shiftSignal(1);
                        lightChange = true;
                    }

                    else if (realElapsed == 12)
                    {
                        northP.shiftSignal(2);
                        lightChange = true;
                    }

                    else if (realElapsed == 15)
                    {
                        southP.shiftSignal(1);
                        lightChange = true;
                    }

                    else if (realElapsed == 18)
                    {
                        southP.shiftSignal(2);
                        eastP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 24)

                    {
                        westP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 27)
                    {

                        eastP.shiftSignal(1);
                        lightChange = true;
                    }
                    else if (realElapsed == 30)

                    {
                        eastP.shiftSignal(2);
                        lightChange = true;
                    }

                    else if (realElapsed == 33)

                    {
                        westP.shiftSignal(1);
                        lightChange = true;
                    }

                    else if (realElapsed == 36)
                    {
                        westP.shiftSignal(2);
                        northP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 40)

                    {
                        westP.shiftSignal(2);
                        eastP.shiftSignal(0);
                        northP.shiftSignal(2);
                        lightChange = true;
                    }

                    else if (realElapsed == 50)

                    {
                        eastP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 56)

                    {
                        westP.shiftSignal(0);
                        lightChange = true;
                    }

                    else if (realElapsed == 59)

                    {
                        eastP.shiftSignal(1);
                        lightChange = true;
                    }

                    else if (realElapsed == 62)

                    {
                        eastP.shiftSignal(2);
                        lightChange = true;
                    }

                    else if (realElapsed == 65)

                    {
                        westP.shiftSignal(1);
                        lightChange = true;
                    }

                    else if (realElapsed == 68)

                    {
                        westP.shiftSignal(2);
                        northP.shiftSignal(0);
                        lightChange = true;
                    }

                    if (lightChange == true) 
                    {

                        Console.Write(timer+"\t");
                        Console.Write(northP.displaySignal() + "\t");
                        Console.Write(southP.displaySignal() + "\t");
                        Console.Write(eastP.displaySignal() + "\t");
                        Console.Write(westP.displaySignal());
                        Console.WriteLine();
                        lightChange = false;
                    }

                    //if statements tracking passing of cars through the intersection 

                    if ((int)NorthQueue[0].getATime() <= timer && northP.getLightColor() == "Green")

                    {
                        NorthQueue.First().setETime((int)timer);
                        Console.Write("The car that is coming from north has crossed: ");
                        NorthQueue.First().displayCar();
                        NorthQueue.Remove(NorthQueue.First());
                        AvgNorthTime = AvgNorthTime + ((int)timer - NorthQueue.First().getETime());
                        Console.WriteLine();
                    }

                    if ((int)EastQueuee[0].getATime() <= timer && eastP.getLightColor()=="Green")

                    {
                        EastQueuee.First().setETime((int)timer);
                        Console.Write("The car that is coming from East has crossed: ");
                        EastQueuee.First().displayCar();
                        EastQueuee.Remove(EastQueuee.First());
                        AvgEastTime = AvgEastTime + ((int)timer - EastQueuee.First().getETime());
                        Console.WriteLine();

                    }

                    if ((int)WestQueue[0].getATime() <= timer && westP.getLightColor()=="Green")

                    {
                        WestQueue.First().setETime((int)timer);
                        Console.Write("The car that is coming from west has crossed: ");
                        WestQueue.First().displayCar();
                        WestQueue.Remove(WestQueue.First());
                        AvgWestTime = AvgWestTime + ((int)timer - WestQueue.First().getETime());
                        Console.WriteLine();
                    }

                    if ((int)SouthQueue[0].getATime() <= timer && southP.getLightColor()== "Green")
                    {
                        SouthQueue.First().setETime((int)timer);
                        Console.Write("The car that is coming from south has  crossed: ");
                        SouthQueue.First().displayCar();
                        SouthQueue.Remove(SouthQueue.First());
                        AvgSouthTime = AvgSouthTime + ((int)timer - SouthQueue.First().getETime());
                        Console.WriteLine();
                    }

                    NorthLight.waitOneSec();
                } while (realElapsed < 68 && timer < numSeconds);
                //display results
                Console.WriteLine();
                Console.WriteLine("Total number of cars that came from the North is: " + numNorthCars);
                Console.WriteLine("Total number of cars that came from the South is: " + numSouthCars);
                Console.WriteLine("Total number of cars that came from the West is: " + numWestCars);
                Console.WriteLine("Total number of cars that came from the East is: " + numEastCars);
                int totalCars = numNorthCars + numSouthCars + numEastCars + numWestCars;
                Console.WriteLine("Total number of cars was: " + totalCars );
                Console.WriteLine("The maximum size of the line of cars that came from the North is: " + maxLengthNorth);
                Console.WriteLine("The maximum size of the line of cars that came from the South is: " + maxLengthSouth);
                Console.WriteLine("The maximum size of the line of cars that came from the West is: " + maxLengthWest);
                Console.WriteLine("The maximum size of the line of cars that came from the East is: " + maxLengthEast);
                int avgTime = (AvgNorthTime / numNorthCars) + (AvgSouthTime / numSouthCars) + (AvgWestTime / numWestCars) + (AvgEastTime / numEastCars);
                Console.WriteLine("Average wait time for cars that came from the North is: " + AvgNorthTime / numNorthCars);
                Console.WriteLine("Average wait time for cars that came from the South is: " + AvgSouthTime / numSouthCars);
                Console.WriteLine("Average wait time for cars that came from the West is: " + AvgWestTime / numWestCars);
                Console.WriteLine("Average wait time for cars that came from the East is: " + AvgEastTime / numEastCars);
                Console.WriteLine("Total Average wait time for all directions: " + avgTime / 4);

            }
         

        }
        static void Main(string[] args)
        {
            
            int runningTime;

            //ask user to input seconds

            Console.Write( "Enter Seconds to run for: ");
            runningTime = Console.Read();
            TrafficLightSimulator(runningTime);
            Console.WriteLine("\npress any key to exit..");
            //wait for user to exit
            Console.ReadKey();
        }
    }
}
