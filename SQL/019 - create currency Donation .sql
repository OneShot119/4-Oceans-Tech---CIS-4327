Create table CurrencyDonation(
amount int,
date date,
donorID int,
Foreign key(DonorID) references DONOR(D_CODE)
);