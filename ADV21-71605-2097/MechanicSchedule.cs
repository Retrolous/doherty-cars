using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petkunas__Lukas___Doherty_Cars
{
    class MechanicSchedule
    {
        // class that represents a mechanics schedule as represented in day appointments, including their information, their position in the timetable and the blocks that are rendered in their row
        public int MechanicStaffID;
        public string MechanicName;
        public List<Timeblock> Timeblocks = new List<Timeblock>();
        public int Index;

        public MechanicSchedule(int MechanicStaffID, string Name, int Index)
        {
            this.MechanicStaffID = MechanicStaffID;
            this.MechanicName = Name;
            this.Index = Index;
        }
    }
}
