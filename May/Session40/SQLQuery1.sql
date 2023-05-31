Create Table Student(
	id int identity(1,1) primary key,
	name varchar(20),
	location varchar(20)
)

Select * From Student

insert into Student
	values('name1','location1');
insert into Student
	values('name2','location2');