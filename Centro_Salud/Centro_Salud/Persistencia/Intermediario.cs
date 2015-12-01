using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Centro_Salud.Persistencia
{
    public abstract class Intermediario
    {
        //"centro_saludConnectionString2"
        protected static CentroSaludDatosDataContext dao = new CentroSaludDatosDataContext();
     

        public static void confirmarCambios()
        {
            dao.SubmitChanges();
        }

        public abstract void save<T>(T entity);
        public abstract List<T> getAll<T>();
        public abstract List<T> getByCriterio<T>(string att, string op, string val);
        public abstract IList<T> getCriterioById<T>(string att, string op, int val);
        public abstract Object getPorId(int id);
        public abstract IList<T> getPorCriterio<T>(string name);
        public abstract void Update<T>(T entity);
        public abstract void Delete(int id);

    }
}