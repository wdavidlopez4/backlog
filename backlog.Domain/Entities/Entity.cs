using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Entities
{
    public abstract class Entity
    {
        public string Id { get; protected set; }

        protected internal Entity(Guid? id = null)
        {
            this.Id = id == null ? Guid.NewGuid().ToString() : id.ToString();
        }
    }
}
