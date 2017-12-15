using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revcom_bot
{
    public class Validation
    {
        public bool ValidLevel(string level)
        {
            try
            {
                if (int.Parse(level) < 11 && int.Parse(level) > 0)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        public bool ValidName(string name)
        {
            if (name=="" | name==" ")
            {

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
