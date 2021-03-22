CREATE DATABASE DemoCrud2
GO

USE DemoCrud2
go


CREATE TABLE StudentTb(
	StudentID INT PRIMARY KEY IDENTITY(1,1),
	Name VARCHAR(50),
	FatherName varchar(50),
	RollNumber VARCHAR(50),
	Address VARCHAR(200),
	Mobile VARCHAR(15)
)
go


