using System;
using System.Collections.Generic;
using System.Text;

namespace PlainsAndDepressions
{
    class Depression
    {
        public int Size { get; private set; }

        public void Increase()
        {
            Size++;
        }
        public Depression() { }
        public Depression(int s)
        {
            Size = s;
        }
    }
}
