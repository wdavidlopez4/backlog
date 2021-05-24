using System;
using System.Collections.Generic;
using System.Text;

namespace backlog.Domain.Entities
{
    public class Feature : Entity
    {
        public string Nombre { get; private set; }

        public string Historial { get; private set; }

        public List<Job> Jobs { get; private set; }

        public Epic Epic { get; private set; }

        public string EpicId { get; private set; }

        internal Feature(string nombre, string historial, string epicId)
        {
            this.Nombre = nombre;
            this.Historial = historial;
            this.EpicId = epicId;
        }

        private Feature()
        {

        }
    }
}
