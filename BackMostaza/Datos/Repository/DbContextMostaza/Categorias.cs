using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Categorias
    {
        public Categorias()
        {
            CategoriasPrincipalesCategorias = new HashSet<CategoriasPrincipalesCategorias>();
            UsuariosCategoria = new HashSet<UsuariosCategoria>();
        }

        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<CategoriasPrincipalesCategorias> CategoriasPrincipalesCategorias { get; set; }
        public virtual ICollection<UsuariosCategoria> UsuariosCategoria { get; set; }
    }
}
