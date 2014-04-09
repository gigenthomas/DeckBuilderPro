using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRepository
{
    public class BaseEntity
    {
        private static readonly int defaultId = 0;

        public int Id { get; set; }

        public bool IsPersistent
        {
            get { return this.Id > BaseEntity.defaultId; }
        }
    }
}
