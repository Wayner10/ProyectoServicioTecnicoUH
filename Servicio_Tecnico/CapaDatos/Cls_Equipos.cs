using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaDatos
{
	public class Cls_Equipos
	{
        public static int ID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public string UsuarioID { get; set; }
    }
}