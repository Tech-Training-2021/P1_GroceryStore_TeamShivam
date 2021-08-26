CREATE TABLE Roles(
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(10) not null
)

CREATE TABLE Users(
    Id int IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Mobile INT NOT NULL,
    Aadhar INT,
    Roles INT FOREIGN KEY REFERENCES Roles(Id)
)

CREATE TABLE UserAddress(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Users INT FOREIGN KEY REFERENCES Users(Id),
    Address1 VARCHAR(100) NOT NULL,
    Address2 VARCHAR(50),
    Address3 VARCHAR(50),
    Pincode INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    State VARCHAR(30) NOT NULL
)

CREATE TABLE OutletAddress(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Address1 VARCHAR(100) NOT NULL,
    Address2 VARCHAR(50),
    Address3 VARCHAR(50),
    Pincode INT NOT NULL,
    City VARCHAR(30) NOT NULL,
    State VARCHAR(30) NOT NULL
)

CREATE TABLE Outlets(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Users INT FOREIGN KEY REFERENCES Users(Id),
    OutletAddress INT FOREIGN KEY REFERENCES OutletAddress(Id),
    Name VARCHAR(20) NOT NULL,
    Contact INT NOT NULL,
    Fssai INT NOT NULL,
)

CREATE TABLE Orders(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Users INT FOREIGN KEY REFERENCES Users(Id),
    Outlets INT FOREIGN KEY REFERENCES Outlets(Id),
    UsersAddress INT FOREIGN KEY REFERENCES UserAddress(Id),
    Date DATETIME NOT NULL DEFAULT SYSDATETIME(),
    TotalPrice INT NOT NULL,
)

CREATE TABLE Units(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
)

CREATE TABLE OrderItems(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Orders INT FOREIGN KEY REFERENCES Orders(Id),
    Name VARCHAR(20) NOT NULL,
    Quantity INT NOT NULL,
    Price INT NOT NULL,
    Weight INT NOT NULL,
    Units INT FOREIGN KEY REFERENCES Units(Id),
)

CREATE TABLE InventoryItems(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(20) NOT NULL,
    Price INT NOT NULL,
    Units INT FOREIGN KEY REFERENCES Units(Id),
)

CREATE TABLE INVENTORY(
    InventoryItems INT FOREIGN KEY REFERENCES InventoryItems(Id),
    Outlets INT FOREIGN KEY REFERENCES Outlets(Id),
    Weight INT NOT NULL,
)

DROP TABLE INVENTORY

CREATE TABLE Inventory(
    InventoryItems INT FOREIGN KEY REFERENCES InventoryItems(Id),
    Outlets INT FOREIGN KEY REFERENCES Outlets(Id),
    Weight INT NOT NULL,
)


INSERT INTO Roles VALUES('Customer')
INSERT INTO Roles VALUES('Manager')

ALTER TABLE Users ALTER COLUMN Mobile VARCHAR(10) NOT NULL
ALTER TABLE Outlets ALTER COLUMN Contact VARCHAR(10) NOT NULL
ALTER TABLE Outlets ALTER COLUMN Fssai VARCHAR(20) NOT NULL
ALTER TABLE Users ALTER COLUMN Aadhar VARCHAR(12)


insert into Users VALUES('Pratiksha','9923875676',234565432345,1)
insert into Users VALUES('Sana','9876575676',434588432345,1)
insert into Users VALUES('Mahesh','9678904676',234565432345,1)
insert into Users VALUES('Shivam','9923875676',234565432345,2)

insert into UserAddress VALUES(5,'B-8','Sagar Apartment','Ashok Nagar',416516,'Mumbai','Maharashtra')
insert into UserAddress VALUES(6,'G-9','Gore House','Bhawani Nagar',456516,'Thane','Maharashtra')
insert into UserAddress VALUES(7,'C-5','Ashoka Building','Sarita Nagar', 513516,'Pune','Maharashtra')
insert into UserAddress VALUES(8,'B-10','King Villa','Bhai Nagar',414356,'Mumbai','Maharashtra')

INSERT INTO OutletAddress VALUES('Roms APT','Walker St','Werkshire',123456,'Mumbai','Maharashtra')
INSERT INTO OutletAddress VALUES('WallBear APT','Walker St','New York',24680,'Pune','Maharashtra')
INSERT INTO OutletAddress VALUES('Shams APT','Wolf St','Morioh City',134679,'Thane','Maharashtra')
INSERT INTO OutletAddress VALUES('Gandhi APT','Bhagata Singh St','Werkshire',123456,'Mumbai','Maharshtra')

insert into Outlets VALUES(8,4,'Dadar','1234567890',98321014000399)
insert into Outlets VALUES(8,5,'Goregaon','1346792085',41521014000235)
insert into Outlets VALUES(8,7,'Thane','0111122233',71521324000399)
insert into Outlets VALUES(8,6,'Panvel','9897654345',21521014000399)

INSERT INTO Orders VALUES(5,9,7,'2015-1-5',3500)
INSERT INTO Orders VALUES(8,10,10,'2015-1-15',1300)
INSERT INTO Orders VALUES(7,12,9,'2015-1-4',2500)
INSERT INTO Orders VALUES(6,11,8,'2015-1-17',1530)

INSERT INTO Units VALUES('gram')
INSERT INTO Units VALUES('pc')
INSERT INTO Units VALUES('bundle')

INSERT INTO OrderItems VALUES(4,'potato',2,180,1000,1)
INSERT INTO OrderItems VALUES(3,'lemon',3,50,1,2)
INSERT INTO OrderItems VALUES(2,'onion',1,150,500,1)
INSERT INTO OrderItems VALUES(1,'carrot',2,120,500,1)

INSERT INTO InventoryItems VALUES('potato',30,1)
INSERT INTO InventoryItems VALUES('lemon',3,2)
INSERT INTO InventoryItems VALUES('spring onion',25,3)
INSERT INTO InventoryItems VALUES('cucumber',60,1)

INSERT INTO Inventory VALUES(1,10,50000)
INSERT INTO Inventory VALUES(2,9,350)
INSERT INTO Inventory VALUES(3,10,60)
INSERT INTO Inventory VALUES(4,12,20000)

