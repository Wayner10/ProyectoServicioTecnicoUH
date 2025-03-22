using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaDatos
{
	public class Cls_Usuarios
	{
        public static int ID { get; set; }
        public string Nombre { get; set; }
        public string Electronico { get; set; }
        public string Telefono { get; set; } = string.Empty;
    }
}