--Создание и управление базой данных

	--Создание базы данных с помощью оператора CREATE DATABASE
use master
go
create database BookShopDB_374_3
--Основной файл
on primary
(
name = BookShop_dat,
filename = "C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ BookShop_374_3.mdf",
size = 4,--Первоначальный размер файла равен 4 МБ
maxsize = 10,--максимальный размер – 10 МБ
filegrowth = 1--Инкремент роста файла составляет 1 МБ.
)
--Журнал файл
log on
(
name = BookShop_log,
filename  = "C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ BookShop_374_3.ldf",
size = 2,
maxsize = 5,
filegrowth = 1
)
go


	--Просмотр базы данных BookShopDB
--Щелкните правой кнопкой BookShopDB, затем – Properties.


	--Удаление базы данных
drop database BookShopDB_374_3

	--Создание базы данных с помощью SQL Server Enterprise Manager
--Щелкните правой кнопкой узел Databases, а затем щелкните New Databases.


	--Увеличение размера базы данных
--Измените значение в поле Space Allocated (Mb) строки 
--BookShopDB_Data (в списке Database Files) с 1 Мб на 2 Мб.


	--Удаление данных из базы
--Щёлкните кнопку Delete.
--Файл Bookdata2 удален из базы данных.
