using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class UnidadesMedidas
    {
        public UnidadesMedidas()
        {
            Articulos = new HashSet<Articulos>();
        }

        public int IdUnidadMedida { get; set; }
        public string UnidadMedida { get; set; }
        public string Abreviatura { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
