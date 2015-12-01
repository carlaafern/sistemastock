--MODIFICACIONES EN TABLAS RELACIONADAS A LOS CAMBIOS EN EL STOCK DE MEDICAMENTOS Y MEDICAMENTOS
--INSERTS PARA CARGAR ALGUNOS DATOS
select * from Lote
select * from Medicamento
select * from StockMedicamento
--select * from Formato
--select * from UnidadMedida
--Insertar Unidades de Medida
insert into UnidadMedida values(1, 'mg');
insert into UnidadMedida values(2, 'ml');
insert into UnidadMedida values(3, 'unidad');
--Insertar Presentación
insert into Formato values(1,'capsulas');
insert into Formato values(2,'jarabe');
insert into Formato values(3,'inyeccion');
insert into Formato values(4, 'pastillas');
--Insertar Tipo Medicamento
insert into Medicamento(codigo, descripcion, monodroga, formato, unidadMedida)values(1,'Tafirol','Paracetamol',4,3);
insert into Medicamento(codigo, descripcion, monodroga, formato, unidadMedida)values(2,'Histamino','Corticoide',2,2);
--Modificaciones en tabla Medicamento-Agregué 3 campos
alter table Medicamento add stockMinimo int
alter table Medicamento add stockAlerta int
alter table Medicamento add stockInicioMes int
--Modificaciones en tabla Stock Medicamento-Saqué 3 campos-FALTA EJECUTAR ESTO
alter table StockMedicamento drop column stockMinimo
alter table StockMedicamento drop column stockAlerta
alter table StockMedicamento drop column stockInicioMes


--Insertar Medicamentos--ESTO CAMBIARÌA SI SACO LOS CAMPOS
insert into StockMedicamento(stockActual,stockInicioMes,stockMinimo,stockAlerta,codigoStock,codigoMedicamento,lote) values(100,50,10,20,1,1,1);
insert into StockMedicamento(stockActual,stockInicioMes,stockMinimo,stockAlerta,codigoStock,codigoMedicamento,lote) values(100,50,10,20,1,1,1);
insert into StockMedicamento(stockActual,codigoStock,codigoMedicamento,lote) values(100,2,2,2);

update Medicamento set stockInicioMes=50, stockMinimo=20, stockAlerta=30 where codigo=1
update Medicamento set stockInicioMes=50, stockMinimo=20, stockAlerta=20 where codigo=2