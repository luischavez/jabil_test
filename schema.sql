CREATE DATABASE Materials;

USE Materials;

CREATE TABLE Buildings (
    PKBuilding INT NOT NULL IDENTITY,
    Building VARCHAR(100) NOT NULL,
    Available BIT NOT NULL,

    CONSTRAINT PK_Buildings PRIMARY KEY (PKBuilding)
);

CREATE TABLE Customers (
    PKCustomer INT NOT NULL IDENTITY,
    Customer VARCHAR(100) NOT NULL,
    Prefix VARCHAR(5) NOT NULL,
    FKBuilding INT NOT NULL,
    Available BIT NOT NULL,

    CONSTRAINT PK_Customers PRIMARY KEY (PKCustomer),
    CONSTRAINT FK_Customers_Buildings FOREIGN KEY (FKBuilding)
        REFERENCES Buildings (PKBuilding)
        ON DELETE CASCADE
);

CREATE TABLE PartNumbers (
    PKPartNumber INT NOT NULL IDENTITY,
    PartNumber VARCHAR(50) NOT NULL,
    FKCustomer INT NOT NULL,
    Available BIT NOT NULL,

    CONSTRAINT PK_PartNumbers PRIMARY KEY (PKPartNumber),
    CONSTRAINT FK_PartNumbers_Customers
        FOREIGN KEY (FKCustomer) REFERENCES Customers (PKCustomer)
            ON DELETE CASCADE
);
