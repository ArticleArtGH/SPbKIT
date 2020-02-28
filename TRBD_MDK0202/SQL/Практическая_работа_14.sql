--Создание и исполнение операторов DDL, DCL и DML SQL

	--Создание БД
create database Northwind



	--Создание таблицы в базе данных Northwind
use Northwind
create table Investors_374_3
(InvestorID int not null,
firstname varchar(30) not null,
lastname varchar(30) not null)


	--Теперь в таблице есть атрибут InvestmentCode
 alter table Investors_374_3
 add InvestmentCode int null

 --Вывод сведений о таблице
 exec sp_help Investors_374_3
 --sp_help – это системная хранимая процедура, которая выводит сведения об объектах базы данных.


	--Предоставление права доступа к объекту базы данных
 grant select 
 on Investors_374_3
 to public

 --Данные разрешениях для таблице
 exec sp_helprotect Investors_374_3


	--Отзыв права доступа к объекту базы данных
 revoke select
 on Investors_374_3
 to public


	--Извлечение данных
insert Investors_374_3 values (01, 'Amie', 'Baldwin', 103)
insert Investors_374_3 values(02, 'Jo', 'Brown', 103)
insert Investors_374_3 values (03, 'Scott', 'Culp', 103)
insert Investors_374_3 values (04, 'Jon', 'Grand', 103)
insert Investors_374_3 values (05, 'Lani', 'Ota', 103)

--На панели Grids отображаются пять строк, введенных в таблицу Investors.
select*from Investors_374_3

--На панели Grids выводятся строки Lani ota и Scott Culp. 
--Показаны только имена и фамилии, отсортированные в алфавитном порядке по имени.
select Firstname, Lastname from Investors_374_3
where (InvestorID = 03 or InvestorID = 05)
order by Firstname


	--Модификация данных
update Investors_374_3
set InvestmentCode = 101
where InvestorID = 04
 
 --На панели Grids отображаются пять строк из таблицы Investors. Обратите внимание, 
 --что значение InvestmentCode для Jon Grande теперь равно 101.
select*from Investors_374_3

--удаление строки
delete from Investors_374_3
where InvestorID = 04


	--УДАЛИТЬ Таблицу
drop table Investors_374_3