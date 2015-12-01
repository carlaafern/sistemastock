using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centro_Salud.Reportes
{
    public class Prueba
    {
        public IQueryable<Especialidad> traerEspecialidades() {
            return new CentroSaludDatosDataContext().Especialidads;
        }
    }
}