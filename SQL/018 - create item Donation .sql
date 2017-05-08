

create table ItemDonation(
donorID int,
donation nvarchar(50),
date date,
foreign key(donorID) references DONOR(D_CODE)
);