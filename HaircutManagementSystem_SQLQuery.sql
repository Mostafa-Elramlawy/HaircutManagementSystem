-- Create the database
CREATE DATABASE HaircutDB;
GO

-- Use the created database
USE HaircutDB;
GO

-- Table: Customers
CREATE TABLE Customers (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100)
);

-- Table: Barbers
CREATE TABLE Barbers (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Specialty NVARCHAR(100)
);

-- Table: Services
CREATE TABLE Services (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

-- Table: Appointments
CREATE TABLE Appointments (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Date DATETIME NOT NULL,
    CustomerId INT NOT NULL,
    BarberId INT NOT NULL,
    ServiceId INT NOT NULL,
    Notes NVARCHAR(500),

    -- Foreign Keys
    CONSTRAINT FK_Appointments_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(ID) ON DELETE CASCADE,
    CONSTRAINT FK_Appointments_Barbers FOREIGN KEY (BarberId) REFERENCES Barbers(ID) ON DELETE CASCADE,
    CONSTRAINT FK_Appointments_Services FOREIGN KEY (ServiceId) REFERENCES Services(ID) ON DELETE CASCADE
);
GO
