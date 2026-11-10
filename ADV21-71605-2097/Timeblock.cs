using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petkunas__Lukas___Doherty_Cars
{
    class Timeblock
    {
        // a more abstract version of an appointment which is used to render appointments
        // as blocks in the appointment viewer
        public int AppointmentID;
        public DateTime AppointmentStart;
        public DateTime AppointmentEnd;

        public Timeblock(int AppointmentID, DateTime AppointmentStart, DateTime AppointmentEnd)
        {
            this.AppointmentID = AppointmentID;
            this.AppointmentStart = AppointmentStart;
            this.AppointmentEnd = AppointmentEnd;
        }
    }
}
