create database DBMS_BMS
use DBMS_BMS

create table Customer
(	CustomerId int primary key identity(1,1),
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	CustPhone nvarchar(100) not null

)
create table Employee(
	empId int primary key identity(1,1),
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	empPhone nvarchar(100) not null,
	empAddress nvarchar(100) not null
)

create table Category(
	Cat_id int primary key identity(1,1),
	CatName varchar(100) not null,
)


create table Product(
	ProId int primary key identity(1,1),
	Pro_Name varchar(100) not null,
	Pro_Price Bigint  not null,
	Category_id int foreign key references Category(Cat_id),
)



create table ProductIngredients(
	Proc_Ing_id int primary key identity(1,1),
	Proc_Ing_Name varchar(100) not null,
    Product_id int foreign key references Product(ProId),
)
 
create table Supplier(
	SupId int primary key identity(1,1),
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	SupPhone nvarchar(100) not null,
	SupAddress nvarchar(100) not null
)

create table Stock(
	StId int primary key identity(1,1),
	Quantity Bigint not null,
	Product_id int foreign key references Product(ProId),
	Supplier_id int foreign key references Supplier(SupId),
)

create table Orders(
	OrId int primary key identity(1,1),
	Or_Date datetime,
	Customer_id int foreign key references Customer(CustomerId),
	Employee_id int foreign key references Employee(empId),
	Or_Item Bigint not null,
)

create table FeedBack(
	FbId int primary key identity(1,1),
	Descriptions nvarchar(100) not null,
	Fb_Date Datetime ,
	 Customer_id int foreign key references Customer(CustomerId),
     Employee_id int foreign key references Employee(empId),

)

Insert into Customer values ('Shaloom','Paul','7637267818')
Insert into Customer values ('Muzzamil','Waseem','33332467818')
Insert into Customer values ('Junaid','Khan','26337818')
Insert into Customer values ('Warda','Junaid','67121818')
Insert into Customer values ('Nadeem','Qamar','8775665')
select* from Customer

Insert into Employee values ('Shaloom','Paul','7637267818','Johar')
Insert into Employee values ('Muzzamil','Waseem','33332467818','Koarngi')
Insert into Employee values ('Junaid','Khan','26337818','Crossing')
Insert into Employee values ('Warda','Junaid','67121818','Shah faisal')
Insert into Employee values ('Nadeem','Qamar','8775665','DHA')
select* from Employee

Insert into Category values ('Sweets')
Insert into Category values ('Nimco')
Insert into Category values ('Cakes')
select* from Category

Insert into Product values ('Barfi',1233,1)
Insert into Product values ('Gulaab janum',3433,1)
Insert into Product values ('Chumchum',442,1)
Insert into Product values ('Milk Cake',754,3)
Insert into Product values ('Pine Apple',1522,3)
Insert into Product values ('Ladoo',122,1)
Insert into Product values ('Dal chana',122,2)
Insert into Product values ('Dal danedar',112,2)
select* from Product

Insert into ProductIngredients values ('Chini',1)
Insert into ProductIngredients values ('Milk',2)
Insert into ProductIngredients values ('Egg',3)
Insert into ProductIngredients values ('Milk',4)
Insert into ProductIngredients values ('Pineapple',5)
Insert into ProductIngredients values ('basan',6)
Insert into ProductIngredients values ('Maasalay',7)
Insert into ProductIngredients values ('Dals',8)
select* from ProductIngredients

Insert into Supplier values ('Sohaib','Doodhwala','Bufferzone',23213123)
Insert into Supplier values ('Rashid','Masalaywala','NHS',5513123)
Insert into Supplier values ('Bilal','Andaywala','Gulberg',66213123)
select* from Supplier

Insert into Stock values (100,1,1)
Insert into Stock values (200,2,1)
Insert into Stock values (200,3,1)
Insert into Stock values (100,7,2)
Insert into Stock values (200,8,2)
Insert into Stock values (200,4,3)
Insert into Stock values (200,5,3)
select* from Stock

Insert into Orders values (getdate(),2,5,25)
Insert into Orders values (getdate(),3,2,266)
Insert into Orders values (getdate(),2,3,33)
Insert into Orders values (getdate(),4,1,344)
Insert into Orders values (getdate(),5,5,111)
select* from Orders

Insert into FeedBack values ('Not Amazing',getdate(),2,4)
Insert into FeedBack values ('Excellent',getdate(),2,1)
Insert into FeedBack values ('Best',getdate(),3,5)
Insert into FeedBack values ('Good',getdate(),4,1)
Insert into FeedBack values ('Fair',getdate(),5,1)
select* from FeedBack
