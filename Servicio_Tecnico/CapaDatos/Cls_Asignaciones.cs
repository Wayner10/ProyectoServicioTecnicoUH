using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaDatos
{
	public class Cls_Asignaciones
	{
		public static int AsignacionesID { get; set; }
		public string ReparacionID { get; set; }
		public string TecnicoID { get; set; }
        public string FechaAsignacion { get; set; }
    }
}