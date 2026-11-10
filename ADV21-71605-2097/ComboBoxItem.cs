using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petkunas__Lukas___Doherty_Cars
{
    class ComboBoxItem
    {
        #region Public properties
        // what is displayed in the combobox
        public string DisplayValue { get; set; }
        // the value that the comboboxitem represents
        public string HiddenValue { get; set; }
        #endregion
        #region Constructors
        public ComboBoxItem(string DisplayValue, string HiddenValue)
        {
            this.DisplayValue = DisplayValue;
            this.HiddenValue = HiddenValue;
        }
        #endregion
        #region Methods
        // override ToString to control what the user sees in the dropdown
        public override string ToString()
        {
            return DisplayValue;
        }
        #endregion
    }
}
