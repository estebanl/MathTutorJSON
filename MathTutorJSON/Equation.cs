using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTutorJSON
{
    [Serializable]
    class Equation
    {
        public int Left = 0;
        public string LeftHandSide = null;
        public string Operation = null;
        public int Result = 0;
        public int Right = 0;
        public string RightHandSide = null;
    }
}
