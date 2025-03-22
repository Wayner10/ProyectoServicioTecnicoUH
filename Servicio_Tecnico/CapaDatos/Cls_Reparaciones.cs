using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaDatos
{
	public class Cls_Reparaciones
	{
		public static int ReparacionID { get; set; }
        public static int EquipoID { get; set; }
        public string FechaSolicitud { get; set; }
        public string Estado { get; set; }

    }
}