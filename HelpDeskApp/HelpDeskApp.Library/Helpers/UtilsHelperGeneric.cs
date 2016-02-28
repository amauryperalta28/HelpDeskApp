using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskApp.Library.Helpers
{
    public static class UtilsHelperGeneric<t>
    {
        public static bool modelIsNull(t Model)
        {
            bool nullModel = (Model == null);
            bool result = false;

            if (nullModel)
            {
                result = true;
            }

            return result;
        }
    }
}
