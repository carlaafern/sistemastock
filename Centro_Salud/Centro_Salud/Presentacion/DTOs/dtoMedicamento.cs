using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centro_Salud.Presentacion.DTOs
{
    public class dtoMedicamento
    {
        private int item;
        private String descripcion;
        private int codigo;
        private int cantidad;

        public dtoMedicamento() { }
        public void setItem(int i) {
            item = i;
        }
        public void setDescripcion(String d) {
            descripcion = d;
        }
        public void setCodigo(int c) {
            codigo = c;
        }
        public void setCantidad(int cant) {
            cantidad = cant;
        }
        public int getItem() {
            return item;
        }
        public int getCantidad() { return cantidad; }
        public int getCodigo() { return codigo; }
        public String getDescripcion() { return descripcion; }

    }
}