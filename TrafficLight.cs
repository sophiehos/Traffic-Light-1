using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficStudy

{
    class TrafficLight
    {
        int signalPos; // postion of light between red, yellow and green
        string signalColor;

        public TrafficLight() 
        // Constructor without parameters and set to red by default
        {
            signalColor = "Red ";
        }

        public void shiftSignal(int x)
        {
            //change light color
            signalPos = x;
            if (signalPos == 0)
                signalColor = "Green";
            else if (signalPos == 1)
                signalColor = "Yellow";
            else
                signalColor = "Red";
        }

        //print active signal light
        public string displaySignal()
        {
            return signalColor;
        }

        //wait for one second
        public void waitOneSec()
        {
            System.Threading.Thread.Sleep(1000);
        }

        //getter function for light
        public string getLightColor()
        {
            return signalColor;
        }


    }
}
