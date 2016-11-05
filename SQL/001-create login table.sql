IF OBJECT_ID('Login') IS NOT NULL
BEGIN
	DROP TABLE dbo.[Login]
END

CREATE TABLE dbo.[Login]
(
	Username	NVARCHAR(50),
	Password	NVARCHAR(50),
	PRIMARY KEY CLUSTERED(Username)
)

INSERT INTO dbo.[Login]
(
Username,
Password
)
VALUES
(
	'hopetherapy',
	'hopetherapy!'
),
(
	'test',
	'test2'
)