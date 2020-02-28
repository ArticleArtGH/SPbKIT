--Лаб1 24.01.2020
--1
--Использование БД Northwind
--use Northwind
--go
--2
--Просмотр БД
--sp_helpdb Northwind-- model

--Можно узнать т.о. системную таблицу(взято из интернета)
--if object_id (N'mytablename', N'U') is not null
--select 1 as res else select 0 as res;

--Вызовет всю (*) информацию о пользователях
--select *
--from sysusers
--3
--Создание таблицы
--use Northwind
--go
--create table LETO_3_374 (filed1 int not null)
--4
--Информаци о таблице в БД Northwind
--use Northwind
--go
--sp_helpindex customers
--sp_helpindex Categories

--Информация о методанных:
--use northwind
--go
--sp_help Customers--nvarchar-10 int-0
--sp_helpdb northwind
--sp_spaceused Customers 
--sp_spaceused Categori

--use northwind
--go
--select col_length ('categories','categoryid'),
--col_length('systemusers','name')
--go

--индентификатор БД ... - 62
--use pubs
--go
--select db_id('pubs')
--go

use northwind
go
sp_helpdb northwind

--use northwind
--go
--Select  --Table_Name  
--From { Information_Schema.Tables}--список таблиц 									базы данных
--{ Information_Schema.Columns}--список полей базы данных
--	Where Table_Name  = ‘Имя таблицы’

--select * 
--from information.schema.tables
--Посмотреть информацию о количестве байт, отведенных в таблице для поля.


