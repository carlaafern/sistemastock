using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centro_Salud.Persistencia
{
    public class ITIpoPersona: Intermediario {
        private int codigoTipo;
        private String nombreTipo;
    
     public virtual void Dispose()
        {

        }
        public override void save<T>(T entity)
        {
            try
            {
                TipoPersona tipoPers = entity as TipoPersona;
                dao.TipoPersonas.InsertOnSubmit(tipoPers);

            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar" + ex.Message);
            }
        }
        public override void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public override void Update<T>(T entity)
        {
            throw new NotImplementedException();
        }
        public override List<T> getByCriterio<T>(string att, string op, string val)
        {
            return (from pe in dao.Personas where pe.dni==val select pe).ToList() as List<T>;
        }
        public override IList<T> getPorCriterio<T>(string name)
        {
            return (from us in dao.Usuarios where us.login == name select us).ToList() as List<T>; //.SingleOrDefault() as List<T>; //retorna un solo Producto
        }

        public override object getPorId(int id)
        {
            throw new NotImplementedException();
        }
        public override IList<T> getCriterioById<T>(string att, string op, int val)
        {
            throw new NotImplementedException();
        }
        public override List<T> getAll<T>()
        {
            return (from tp in dao.TipoPersonas select tp).ToList() as List<T>;
        }
    }
}
