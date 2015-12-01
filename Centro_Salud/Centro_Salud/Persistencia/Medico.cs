///////////////////////////////////////////////////////////
//  Medico.cs
//  Implementation of the Class Medico
//  Generated by Enterprise Architect
//  Created on:      14-ene-2014 21:36:22
///////////////////////////////////////////////////////////


using System;

public class Medico {

	private int dni;
	private string domicilio;
	private DateTime fechaIngreso;
	private int legajo;
	private int matricula;
	private string nombreyApellido;
	private int telefono;
	public IEspecialidad m_Especialidad;
	public IUsuario m_Usuario;

	public Medico(){

	}

	~Medico(){

	}

	public virtual void Dispose(){

	}

}//end Medico