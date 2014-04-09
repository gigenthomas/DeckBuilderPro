Create Table Users
(
	UserId int Primary Key Identity(1,1)
	,FirstName varchar(50) Not Null
	,LastName varchar(50) Not Null
	,EmailAddress varchar(255) Unique Not Null
	,ZipCode varchar(25)
	,CountryId int Not Null
	,DateOfBirth DateTime2(3)
	,IsMale bit
)