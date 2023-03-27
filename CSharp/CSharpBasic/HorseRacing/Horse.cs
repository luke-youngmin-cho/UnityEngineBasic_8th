using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing
{
    internal class Horse
    {
        public string Name;
        public bool IsFinished;
        public double TotalDistance;

        public void Move(double distance)
        {
            TotalDistance += distance;
        }
    }
}
