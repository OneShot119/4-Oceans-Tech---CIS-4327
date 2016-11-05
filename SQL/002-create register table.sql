IF OBJECT_ID('Register') IS NOT NULL
BEGIN
	DROP TABLE dbo.[Register]
END

CREATE TABLE dbo.[Register]
(
	Username	NVARCHAR(50),
	Password	NVARCHAR(50),
	Email		NVARCHAR(50),
	FirstName	NVARCHAR(50),
	LastName	NVARCHAR(50),
	PRIMARY KEY CLUSTERED(Username)
)

INSERT INTO dbo.[Register]
(
Username,
Password,
Email,
FirstName,
LastName
)
VALUES
(
	'hopetherapy',
	'hopetherapy!',
	'hope@therapy.org',
	'Hope',
	'Therapy'
)