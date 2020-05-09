using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class ArticulosImagenes
    {
        public int IdArticuloImagen { get; set; }
        public int IdArticulo { get; set; }
        public int IdImagen { get; set; }

        public virtual Articulos IdArticuloNavigation { get; set; }
        public virtual Imagenes IdImagenNavigation { get; set; }
    }
}
