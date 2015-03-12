using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
   public class Display
    {
        
        private double displaySize;
        private string displayColors;

        public double DisplaySize
        {
            get
            {
                return displaySize;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ArgumentNullException("######The size of the display should be bigger than 1!");
                }
                displaySize = value;
            }
        }

        public string DisplayColors
        {
            get
            {
                return displayColors;
            }
            set
            {
                displayColors = value;
            }
        }

        public Display(double displaySize=2,string displayColors=null)
        {
            this.DisplaySize = displaySize;
            this.DisplayColors = displayColors;
        }
    }
}
