using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
   public  abstract class Space
    {
        private int name;

        public event EventHandler playerLanded;

        public int Name
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
