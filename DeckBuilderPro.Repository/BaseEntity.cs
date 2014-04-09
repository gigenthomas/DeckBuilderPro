using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckBuilderPro.Repository.Enums;

namespace DeckBuilderPro.Repository
{
    public class BaseEntity : Interfaces.IObjectState
    {
        private static readonly int defaultId = 0;

        public int Id { get; set; }

        public ObjectState State { get; set; }

        public bool IsPersistent
        {
            get { return this.Id > BaseEntity.defaultId; }
        }
    }
}
