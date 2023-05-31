create table Customer(
	cid int primary key,
	cname varchar(20),
	cbalance int
)

create table Merchant(
	mid int primary key,
	mname varchar(20),
	mbalance int
)

insert into Customer values(1,'Manjunath',5995)
insert into Customer values(2,'Ekta',2575)
update Customer set cname='Ekta' where Customer.cid=2 

insert into Merchant values(31,'RMart',50560)
insert into Merchant values(32,'DMart',20125)

UPDATE Merchant SET mbalance = 50000 WHERE mid = 31

Select * from Merchant
select * from Customer