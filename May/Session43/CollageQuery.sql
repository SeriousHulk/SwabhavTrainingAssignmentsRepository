create table collage(
	id int primary key identity(1,1),
	name varchar(20)
)

create table Department(
	id int primary key identity(1,1),
	name varchar(20),
	collage_id int references collage(id)
)

insert into collage values ('Viva')

select * from collage

insert into Department values('CS',1)

select * from Department




create table customer(
	id int primary key identity(1,1),
	firstName varchar(20),
	lastName varchar(20),
	email varchar(20)
)

create table orders(
	id int primary key identity(1,1),
	orderName varchar(20),
	quantity int,
	cusromer_id int references customer(id)
)

create table lineItem(
	id int primary key identity(1,1),
	itemName varchar(20),
	price decimal,
	order_id int references orders(id),
)

insert into customer values ('name1','lastN1','abc@mail.com')

select * from customer

insert into orders values('Order1',3,1)

select * from orders

insert into lineItem values('toothbrush',20,1)

select * from lineItem