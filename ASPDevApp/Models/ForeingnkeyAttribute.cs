using System;

namespace ASPDevApp.Models
{
    internal class ForeingnkeyAttribute : Attribute
    {
        private string v;

        public ForeingnkeyAttribute(string v)
        {
            this.v = v;
        }
    }
}