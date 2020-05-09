using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class CategoriasPrincipalesCategorias
    {
        public int IdCategoriaPrincipalCategoria { get; set; }
        public int IdCategoriaPrincipal { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categorias IdCategoriaNavigation { get; set; }
        public virtual CategoriasPrincipales IdCategoriaPrincipalNavigation { get; set; }
    }
}
