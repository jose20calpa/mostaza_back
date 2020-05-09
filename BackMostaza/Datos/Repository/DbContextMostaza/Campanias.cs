using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Campanias
    {
        public Campanias()
        {
            CampaniasImagenes = new HashSet<CampaniasImagenes>();
        }

        public int IdCampania { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Descripcion { get; set; }
        public int IdEstadoCampania { get; set; }

        public virtual EstadosCampanias IdEstadoCampaniaNavigation { get; set; }
        public virtual ICollection<CampaniasImagenes> CampaniasImagenes { get; set; }
    }
}
