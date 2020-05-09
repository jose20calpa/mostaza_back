using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosLayer.Dtos
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }
}
