﻿USE RentAFlat;

ALTER TABLE Offer
Add 
Date_From DATETIME NOT NULL,
Date_Until DATETIME NOT NULL;