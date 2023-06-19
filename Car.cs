using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficStudy
{
    //car class allowing definition of car objects
    class Car
    {
        int seqNum;
        int arrivalTime;
        int leaveTime;

   
   public Car()
        {
            seqNum = 0;
            arrivalTime = 0;
            leaveTime = 0;
        }
    
    public Car(int sNum, int aTime, int eTime)
        {
            seqNum = sNum;
            arrivalTime = aTime;
            leaveTime = eTime;
        }
    //setter function for sequence number
    public void setSeqNo(int seq)
        {
            seqNum = seq;
        }
    //setter function for arrival time
    public void setArrTime(int at)
        {
            arrivalTime = at;
        }
    //setter function for exit time
    public void setETime(int et)
        {
            leaveTime = et;
        }
    //getter function for arrival time
    public int getATime()
        {
            return arrivalTime;
        }
    //getter function for exit time
    public int getETime()
        {
            return leaveTime;
        }
    //print car details
    public void displayCar()
        {
           Console.WriteLine("\n Seq. No: " + seqNum + "\t Arr. Time: " + arrivalTime + "\t Exit time: " + leaveTime);
        }
}
}
