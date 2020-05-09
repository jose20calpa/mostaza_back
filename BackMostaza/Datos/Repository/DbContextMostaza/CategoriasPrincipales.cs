using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class CategoriasPrincipales
    {
        public CategoriasPrincipales()
        {
            CategoriasPrincipalesCategorias = new HashSet<CategoriasPrincipalesCategorias>();
        }

        public int IdCategoriaPrincipal { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<CategoriasPrincipalesCategorias> CategoriasPrincipalesCategorias { get; set; }
    }
}
