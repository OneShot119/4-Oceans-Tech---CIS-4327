CREATE TABLE Volunteer ( 
VolunteerID      INTEGER IDENTITY (1,1)     NOT NULL UNIQUE, 
FirstName     NVARCHAR(35) NOT NULL, 
LastName     NVARCHAR(35) NOT NULL, 
StreetAddress 	NVARCHAR(50) NULL, 
City		NVARCHAR(35) NULL, 
States		NVARCHAR(35) NULL,
ZipCode		NVARCHAR(10) 	NULL,
County	NVARCHAR(35)	NULL,
CellPhoneNumber    NVARCHAR(10) NULL,     
HomePhoneNumber    NVARCHAR(10) NULL,     
WorkPhoneNumber    NVARCHAR(10) NULL, 
Email  		NVARCHAR(50) NULL,    
Birthday	NVARCHAR(15)		NULL,
Gender	NVARCHAR(10) NULL,
CompanyName		NVARCHAR(50) NULL,
Position	NVARCHAR(20) NULL,
CompanyAddress	NVARCHAR(50) NULL,
CompanyZip NVARCHAR(10),
DateOrientation		NVARCHAR(15) NULL, 
DateStarted		NVARCHAR(15) NULL, 
HoursPerMonth		INTEGER NULL,
VolunteerPosition	NVARCHAR(20) NULL,
AreaOfInterest NVARCHAR(20) NULL,
Skills NVARCHAR(20) NULL,
Donor NVARCHAR(3) NULL,
Board NVARCHAR(3) NULL,
EmailList NVARCHAR(3) NULL,
MailList NVARCHAR(3) NULL,

PRIMARY KEY (VolunteerID))