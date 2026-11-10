using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petkunas__Lukas___Doherty_Cars
{
    class CurrentUser
    {
        #region Public properties
        // holds the currently logged-in staff member in memory
        // this ensures that the program can easily access their privileges and details, allowing for the dynamic updating of forms where appropriate
        // initialised to null when no member is logged-in
        public static Staff CurrentLoggedInUser = null;
        #endregion
    }
}
