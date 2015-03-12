using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd, other
    }

   public class Battery
    {
        public BatteryType typeBattery;
        private string batteryModel;
        private double hoursIdle;
        private double hoursTalk;
        
        public double HoursTalk
        {
            get
            {
                return hoursTalk;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("######The talk time should be bigger than 0!");
                }
                hoursTalk = value;
            }
        }

        public double HoursIdle
        {
            get
            {
                return hoursIdle;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("######The idle time should be bigger than 0!");
                }
                hoursIdle = value;
            }
        }

        public string BatteryModel
        {
            get
            {
                return batteryModel;
            }
            set
            {
                batteryModel = value;
            }
        }

        public BatteryType TypeBattery
        {
            get
            {
                return typeBattery;
            }
        }

        public Battery(string batteryModel = null, double hoursIdle = 0, double hoursTalk = 0, BatteryType batteryType = BatteryType.other)
        {
            this.BatteryModel = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
        }
    }
}
