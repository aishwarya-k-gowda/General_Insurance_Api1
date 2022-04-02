create database General_Insurance6
use General_Insurance6

-------------------------------------customer registration-----------------------------------
create table userRegistration(
userId int primary key identity(1,1) not null,
userName varchar(50),
email varchar(100),
dob date,
contactNo bigint,
Address varchar(max),
password varchar(50)

);

drop table userRegistration

select *  from userRegistration

insert into userRegistration(userName,email,dob,contactNo,address,password) 
values('Anisha','anisha@gmail.com','1999/02/21',9876543400,'pune','Anisha@22');

--------------------------------------vehicletypes------------------------------

 create table vehicletypes
 (
 vehicleType varchar(50),	
 vehicleTypeId int primary key identity(1,1)

 );

 insert into vehicletypes(vehicleType) values('2 wheeler')

 select * from vehicletypes

 
-----------------------------------vehicle details----------------
drop table vehiclesdetails;


create table vehiclesdetails(
vehicleId int primary key identity(101,1) not null,
vehicleType varchar(30),
manufacturer varchar(50),
model varchar(100),
drivingLicenseNumber varchar(50),
registrationNumber varchar(100), 
engineNumber varchar(100),
chasisNumber varchar(100),
vehicleAge  int
);

insert into vehiclesdetails(manufacturer,model,drivingLicenseNumber,registrationNumber,engineNumber,chasisNumber,vehicleAge) 
values('Toyota','Lenova','DL4567983456','KH22456','952373','CS76495',3)

select * from vehiclesdetails 

------------------------------------------/User Login table--------------------------------
create table login(
loginId int primary key identity(1001,1),
email varchar(100),
password varchar(50) not null,

);

select * from login

insert into login(email,password) values('anisha@gmail.com', 'Anisha@22')


------------------------------------------Admin Login table--------------------------------
/*create table adminlogin(
email varchar(100) not null,
password varchar(50) not null,
adminId int primary key identity(1,1)
);*/

-----------------------------insuranceplantype--------------------------------

 create table insuranceplantype
 (
  planId int primary key identity(1,1) not null,
  planName varchar(50)
 
 );
 
 insert into insuranceplantype(planName) values ('Comprehensive')
 
----------------------------------------insuranceduration------------------------------------

 create table insuranceduration
 (
 durationId int primary key identity(1,1) not null,
 durationValue varchar(50)
 
 );

 insert into insuranceduration(durationValue) values ('Three year')


-----------------------------------------policy details------------------------------------

create table policydetails(
policyNumber int primary key identity (50,1),
model varchar(100),
registrationNumber varchar(100),
userName varchar(50),
userId int,
vehicleId int,

foreign key (vehicleId) references vehiclesdetails(vehicleId),
foreign key (userId) references userRegistration(userId)

);


-------------------------------------------------Renew---------------------------------
create table renew(
renewId bigint primary key identity(21,1),
policyNumber int,
contactNo bigint,
email varchar(100),


)

----------------------------------------claimreasons------------------------------------

create table claimreasons(
claimId int primary key identity(1,1),
policyNumber int,
contactNo bigint,
claimreason varchar(50)


);


-----------------------------------claimhistory-----------------------------------------

create table claimhistory( 
claimNo int primary key identity(1,1) not null,
policyNumber int,
contactNo bigint,
claimreason varchar(50),
isApproved varchar(20),
claimId int,
foreign key (policyNumber) references policydetails(policyNumber),
foreign key (claimId) references claimreasons(claimId)
);


-----------------------------------------------------------