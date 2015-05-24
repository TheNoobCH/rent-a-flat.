Alter Table Flatimages
Add FlatID int,
CONSTRAINT flatImage_flat FOREIGN KEY (FlatId) REFERENCES Flat(Id) ON DELETE CASCADE;