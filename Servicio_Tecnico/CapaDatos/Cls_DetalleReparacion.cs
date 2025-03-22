using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Servicio_Tecnico.CapaDatos
{
	public class Cls_DetalleReparacion
	{
        public int DetalleID { get; set; }
        public int ReparacionID { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Cls_DetalleReparacion()
        {
        }
        public Cls_DetalleReparacion(int detalleID, int reparacionID, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            DetalleID = detalleID;
            ReparacionID = reparacionID;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
        }
    }
}