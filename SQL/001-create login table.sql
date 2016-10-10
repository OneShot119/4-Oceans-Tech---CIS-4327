USE [HopeTherapy]
GO

IF OBJECT_ID('Login') IS NULL
BEGIN
	CREATE TABLE dbo.[Login]
	(
		Username	NVARCHAR(50),
		Password	NVARCHAR(50),
		PRIMARY KEY CLUSTERED(Username)
	)
END