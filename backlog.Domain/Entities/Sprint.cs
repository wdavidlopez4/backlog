using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Entities
{
    public class Sprint : Entity
    {
        public string Desde { get; private set; }

        public string Hasta { get; private set; }

        public List<Epic> Epics { get; private set; }

        internal Sprint(string desde, string hasta)
        {
            this.Desde = desde;
            this.Hasta = hasta;
        }

        private Sprint()
        {

        }

    }
}
