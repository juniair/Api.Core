using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Core.Entity
{
    public class DateEntityBase : ICreateTime, IModifiedTime
    {
        public virtual DateTime ModifiedTime { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}
