use master
go

--При помощи alter
	--1.Изменить характеристики файла данных

--А.Увелечение размера файла до 10 mb при помощи alter
alter database BookShopDB_374_3
	Modify file
	(
	name = BookShop_dat,
	size = 10
	)
go

--Б.Изменение имени БД
alter database BookShopDB_374_3
	modify name = NewNameBookShopDB_374_3
go

--В.Добавить доп. файл
alter database NewNameBookShopDB_374_3
	add file 
	(
	name = 'BookShop_add',
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ BookShop_add.nbf',
	size = 2,
	maxsize = 5
	)
go

--Г.Добавить файл транзакций
alter database NewNameBookShopDB_374_3
	add log file 
	(
	name = 'BookShop_trans',
	filename = 'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\ BookShop_trans.ldf',
	size = 2,
	maxsize = 5,
	filegrowth = 1
	)
go

--Д.Изменить файлу данных шаг приращения
alter database NewNameBookShopDB_374_3
	modify file
	(
	name = 'BookShop_374_3',
	filegrowth = 1
	)
go

--Удаление файла
--alter database NewNameBookShopDB_374_3
--remove file   --BookShop_trans
--go

--Выполнение проверки внесённых изменений 
sp_helpdb NewNameBookShopDB_374_3