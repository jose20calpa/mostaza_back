using System;
using System.Collections.Generic;

namespace Datos.Repository.DbContextMostaza
{
    public partial class CampaniasImagenes
    {
        public int IdCampaniaImagen { get; set; }
        public int IdCampania { get; set; }
        public int IdImagen { get; set; }

        public virtual Campanias IdCampaniaNavigation { get; set; }
        public virtual Imagenes IdImagenNavigation { get; set; }
    }
}
