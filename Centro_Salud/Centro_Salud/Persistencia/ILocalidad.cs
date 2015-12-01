using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centro_Salud.Persistencia
{
    public class ILocalidad:Intermediario
    {
            private String nombreLocalidad;
            private int codLocalidad;


            public virtual void Dispose()
            {

            }
            public override void save<T>(T entity)
            {
                try
                {
                    Usuario us = entity as Usuario;
                    dao.Usuarios.InsertOnSubmit(us);

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
                throw new NotImplementedException();
            }
            public override IList<T> getPorCriterio<T>(string name)
            {
                return (from loc in dao.Localidads where loc.nombreLocalidad == name select loc).ToList() as List<T>; //.SingleOrDefault() as List<T>; //retorna un solo Producto
            }

            public override object getPorId(int id)
            {
               
                throw new NotImplementedException();
            }
            public override IList<T> getCriterioById<T>(string att, string op, int val)
            {
                return (from loc in dao.Localidads where loc.codigoDepartamento == val select loc).ToList() as List<T>;
                //throw new NotImplementedException();
            }
            public override List<T> getAll<T>()
            {
                return (from p in dao.Provincias select p).ToList() as List<T>;
            }


        }
    }
