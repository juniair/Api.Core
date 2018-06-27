using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestApi.Core.Entity
{
    public class EntityBase<T> : ICreateTime, IModifiedTime
    {
        [Key]
        public T Id { get; set; }

        public virtual DateTime ModifiedTime { get; set; }

        public virtual DateTime CreateTime { get; set; }
    }
}
