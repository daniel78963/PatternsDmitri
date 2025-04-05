using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePatternsNETFramework
{
    //public class Square  
    //{ }

    public class Square : Rectangle
    {
        public override int Width
        {
            set { base.Width = base.Heigth = value; }
        }

        public override int Heigth
        {
            set { base.Width = base.Heigth = value; }
        }
    }
}
