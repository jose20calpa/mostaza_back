using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class EstadosArticulos
    {
        public EstadosArticulos()
        {
            Articulos = new HashSet<Articulos>();
        }

        public int IdEstadoArticulo { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
