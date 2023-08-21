create database Inventory_Management_System
go

use Inventory_Management_System
go

create table Suplier
(
	Id int identity(1,1) primary key,
	SuplierName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(100),
	MoreInfo nvarchar(max),
	ContractDate DateTime
)
go

create table Customer
(
	Id int identity(1,1) primary key,
	CustomerName nvarchar(max),
	Address nvarchar(max),
	Phone nvarchar(20),
	Email nvarchar(100),
	MoreInfo nvarchar(max),
	ContractDate DateTime
)

create table UserRole(
	Id int identity(1,1) primary key,
	RoleName nvarchar(max)
)
go

create table Users(
	Id int identity(1,1) primary key,
	DisplayName nvarchar(max),
	UserName nvarchar(100),
	Password nvarchar(max),
	RoleId int not null,

	foreign key (RoleId) references UserRole(Id)
)
go

create table Category
(
	Id int identity(1,1) primary key,
	CategoryName nvarchar(max),
	Description nvarchar(max)  
)

create table Product(
	Id nvarchar(128),
	ProductName nvarchar(max),
	SuplierId int not null,
	Creator int not null,
	

)


create table Input(
	
)
