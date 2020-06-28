using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspireMovement
{
    class svContloleClass
    {
        public string name;
        public int svPort;
        public int svPin;
        public int cPosX;
        public int cPosY;

        public void makeInfor(string textName,int port,int pin)
        {
            this.name = textName;
            this.svPort = port;
            this.svPin = pin;
        }

        public void makePoint(int x,int y)
        {
            this.cPosX = x;
            this.cPosY = y;
        }

        public void makeControle()
        {
            Console.WriteLine("makeing controle...");
        }

    }
}
