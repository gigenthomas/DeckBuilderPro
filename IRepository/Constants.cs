using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRepository
{
    class Constants
    {
        public class NotImeplementedExceptionMessages
        {
            public const string IObjectState = "All entites must implement the IObjectState interface, this interface must be implemented so each entites state can explicitely determined";
        }
    }
}
