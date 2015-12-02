select * from Persona
select * from Usuario
select * from Perfil
select * from Direccion
select * from Provincia
select * from Departamento
select * from Localidad
insert into Perfil values(1, 'administrador');
insert into Perfil values(2, 'usuario');
insert into Direccion values(1,'Gustavo Andre',135,1,2,2);
insert into Persona values('Carla', 'Fernandez', '28819441', '153010770','dni',1,1,1);
insert into Usuario(contraseña,estado,codigoUsuario,login,codigoPersona,perfil,mail,recibeAlertas) values('brisa',1,1,'brisa',1,1,'carlaafern@gmail.com',1);