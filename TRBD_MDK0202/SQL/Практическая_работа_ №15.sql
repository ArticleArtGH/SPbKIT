--�������� ��������� � ������� �������������� ��������� ����� Transact-SQL

	--������� ��
use Northwind
go


	--������� �������
--New Table ��� ������������� � ��������������, 
--� ������� �� �������� � ���������� ������.
create table [New_Table_374_3] (ColumnA int, ColumnB char(30))
go
--����� ������������� ����� ��������� � ������ �����
set nocount on
--����� ��������� ����� ���� 
--set nocount off
go


	--�������� ����������� ���������
declare @MyCounter int
--���������������� ���������
set @MyCounter = 0

--����������� ����� ������ � ������� ����������
while (@MyCounter < 26)
begin
--��������� � ������� ������
insert into [New_Table_374_3] values
--� ������� ���������� �������� ������������� �������� ��� �������
--ColumnA � ������������� ���������� ����� ��� ������ ������.
-- �������� ������������� �������� ������� �a� � ������� ������� ASSCII
--��������� @MyCounter. � ������� ������� CHAR ������������� ����� 
--������� � ������� @MyCounter, ��������� ����� �������  �a�.
(@MyCounter + 1, char ((@MyCounter + ascii('a'))))
--��������� �������� ���������� ��� ����� ���� �������� �����
set @MyCounter = @MyCounter + 1
end
go

set nocount off
go

--������ ��������� 26 �����, � �������� � ���� �������� 
--���������� �������������.
select*from [New_Table_374_3]
--or
--select*from New_Table_374_3--����������� ������

--delete from [New_Table_374_3]

drop table [New_Table_374_3]
--? � ��� ������� ���� �� ��������� � ������� ������� � � [] ��� ��� ��� ?
--[] ����� ���� ����� ��������� ����� ������