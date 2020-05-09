using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class EstadosCampanias
    {
        public EstadosCampanias()
        {
            Campanias = new HashSet<Campanias>();
        }

        public int IdEstadoCampania { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Campanias> Campanias { get; set; }
    }
}
