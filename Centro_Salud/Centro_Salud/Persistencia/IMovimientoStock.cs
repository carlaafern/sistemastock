///////////////////////////////////////////////////////////
//  MovimientoStock.cs
//  Implementation of the Class MovimientoStock
//  Generated by Enterprise Architect
//  Created on:      14-ene-2014 21:36:21
///////////////////////////////////////////////////////////


using System;
using Centro_Salud.Persistencia;
using Centro_Salud;
using System.Collections.Generic;
using Centro_Salud.Presentacion;
using System.Linq;

namespace Centro_Salud.Persistencia{
public class IMovimientoStock:Intermediario {

	private int nroMovimiento;
    private int nroComprobante;
    private int tipoMovimiento;
    private DateTime fechaMovimiento;

	

	public IMovimientoStock(){

	}

	~IMovimientoStock(){

	}
     public override void save<T>(T entity){
      try
        {
            MovimientoStock movstk = entity as MovimientoStock;
            
            dao.MovimientoStocks.InsertOnSubmit(movstk);
            //dao.DetalleMovimientoStocks.InsertOnSubmit(movstk);
                    
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

        return (from movstk in dao.MovimientoStocks where movstk.nroMovimiento == int.Parse(name) select movstk).ToList() as List<T>; //.SingleOrDefault() as List<T>; //retorna un solo Producto
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
        return (from movstk in dao.MovimientoStocks select movstk).ToList() as List<T>;
    }
	

}//end MovimientoStock
}