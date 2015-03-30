namespace Monopoly
{
    using System;

    public abstract class Space
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
