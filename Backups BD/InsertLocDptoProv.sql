INSERT INTO dbo.Provincia (nombreProvincia, codigoProvincia)VALUES ('Mendoza',1);
INSERT INTO dbo.Provincia (nombreProvincia, codigoProvincia)VALUES ('San Luis',2);
INSERT INTO dbo.[Departamento](codigoDepartamento,nombreDepartamento,codigoProvincia)VALUES (1,'Maipu',1);
INSERT INTO dbo.[Departamento](codigoDepartamento,nombreDepartamento,codigoProvincia)VALUES (2,'Lavalle',1);
INSERT INTO dbo.Localidad(nombreLocalidad,codigoLocalidad,codigoDepartamento)VALUES ('Coquimbito',1,1);
INSERT INTO dbo.Localidad(nombreLocalidad,codigoLocalidad,codigoDepartamento)VALUES ('Gutierrez',2,1);
INSERT INTO dbo.Localidad(nombreLocalidad,codigoLocalidad,codigoDepartamento)VALUES ('Villa',3,2);
INSERT INTO dbo.Localidad(nombreLocalidad,codigoLocalidad,codigoDepartamento)VALUES ('Costa',4,2);


SELECT * FROM centro_salud.dbo.Provincia;
SELECT * FROM centro_salud.dbo.Departamento;
SELECT * FROM centro_salud.dbo.Localidad;

