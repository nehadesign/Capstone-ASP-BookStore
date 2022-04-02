CREATE DATABASE dbBookStore
GO
USE dbBookStore
GO
CREATE TABLE Tbl_Category(
CategoryId int IDENTITY(1,1) primary key NOT NULL,
	CategoryName varchar(500)  unique NULL,
	IsActive bit NULL,
	IsDelete bit NULL,
)



CREATE TABLE Tbl_Product(
	ProductId int IDENTITY(1,1) primary key NOT NULL, 
	ProductName varchar(500)  unique NULL,
	CategoryId int NULL,
	IsActive bit NULL,
	IsDelete bit NULL,
	CreatedDate datetime NULL,
	ModifiedDate datetime NULL,
	Description datetime NULL,
	ProductImage varchar(max) NULL,
	IsFeatured bit NULL,
	Quantity int NULL
	foreign key(CategoryId) references Tbl_Category(CategoryId)
	)

CREATE TABLE Tbl_CartStatus(
	CartStatusId int IDENTITY(1,1) primary key NOT NULL,
	CartStatus varchar(500) NULL,
	)

CREATE TABLE Tbl_Members(
	MemberId int IDENTITY(1,1) primary key NOT NULL,
	FirstName varchar(200) NULL,
	LastName varchar(200)  NULL,
	EmailId varchar(200) unique NULL,
	Password varchar(500) NULL,
	IsActive bit NULL,
	IsDelete bit NULL,
	CreatedOn datetime NULL,
	ModifiedOn datetime NULL,
)


CREATE TABLE Tbl_ShippingDetails(
	ShippingDetailId int IDENTITY(1,1) NOT NULL,
	MemberId int NULL,
	Adress varchar(500) NULL,
	City varchar(500) NULL,
	State varchar(500) NULL,
	Country varchar(50) NULL,
	ZipCode varchar(50) NULL,
	OrderId int NULL,
	AmountPaid decimal(18, 0) NULL,
	PaymentType varchar(50) 
	foreign key(MemberId) references Tbl_Members(MemberId)
	)

	
CREATE TABLE Tbl_MemberRole(
	MemberRoleID int IDENTITY(1,1) primary key NOT NULL,
	memberId int NULL,
	RoleId int NULL,
)




CREATE TABLE Tbl_Roles(
	RoleId int IDENTITY(1,1) primary key NOT NULL,
	RoleName varchar(200) unique NULL,
	)


CREATE TABLE Tbl_Cart(
	CartId int IDENTITY(1,1) primary key NOT NULL,
	ProductId int NULL,
	MemberId int NULL,
	CartStatusId int NULL,
	foreign key(ProductId) references Tbl_Product(ProductId)
	)

CREATE TABLE Tbl_SlideImage(
	SlideId int IDENTITY(1,1) primary key  NOT NULL,
	SlideTitle varchar(500) NULL,
	SlideImage varchar(max) NULL

)
