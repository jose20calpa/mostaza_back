using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class Imagenes
    {
        public Imagenes()
        {
            ArticulosImagenes = new HashSet<ArticulosImagenes>();
            CampaniasImagenes = new HashSet<CampaniasImagenes>();
        }

        public int IdImagen { get; set; }
        public byte[] Imagen { get; set; }

        public virtual ICollection<ArticulosImagenes> ArticulosImagenes { get; set; }
        public virtual ICollection<CampaniasImagenes> CampaniasImagenes { get; set; }
    }
}
