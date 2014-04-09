using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Repository.Enums;

namespace DeckBuilderPro.Repository.Interfaces
{
    public interface IObjectState
    {
        ObjectState State { get; set; }
    }
}
