using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Centro_Salud.Persistencia
{
    public class IPedido:Intermediario
    {
    
    public IPedido(){

	}

    ~IPedido()
    {

	}
     public override void save<T>(T entity){
      try
        {
            Pedido ped = entity as Pedido;
            
            dao.Pedidos.InsertOnSubmit(ped);
                    
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

        return (from ped in dao.Pedidos where ped.nroPedido == Convert.ToInt32(name) select ped).ToList() as List<T>;
    }

    public override object getPorId(int id)
    {
        throw new NotImplementedException();
    }
    public override IList<T> getCriterioById<T>(string att, string op, int val)
    {
        return (from ped in dao.Pedidos where ped.nroPedido == val select ped).ToList() as List<T>;
    }
    public override List<T> getAll<T>()
    {
        return (from ped in dao.Pedidos select ped).ToList() as List<T>;
    }
	

    
    
    }
}