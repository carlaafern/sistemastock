using System;
using Centro_Salud.Persistencia;
using Centro_Salud;
using Centro_Salud.Presentacion;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centro_Salud.Persistencia
{
    public class IPerfil:Intermediario
    {

    private int codigoPerfil;
	private string descripcion;
	

	public IPerfil(){

	}

	
     public override void save<T>(T entity){
      try
        {
            Perfil per = entity as Perfil;
            dao.Perfils.InsertOnSubmit(per);
      
         
        }
        catch (Exception ex)
        {
            throw new Exception("Error al guardar" + ex.Message);
        }
    
    }

	public virtual void Dispose(){

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
        
        return (from per in dao.Perfils where per.descripcion == name select per).ToList() as List<T>; //.SingleOrDefault() as List<T>; //retorna un solo Producto
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
        return (from per in dao.Perfils select per).ToList() as List<T>;
    }
    
	
    }
}