using System;

namespace IndieRadar.Model.Models.Base
{
    public abstract class BaseEntity<TKey>
    {
        public virtual TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<Int32>
    {

    }
}