using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public abstract class Element
    {
        private List<purchasableSpace> ownedSpaces = new List<purchasableSpace>();

        public void AddSpace()
        {
            throw new System.NotImplementedException();
        }

        public void RemoveSpace()
        {
            throw new System.NotImplementedException();
        }
    }
}
