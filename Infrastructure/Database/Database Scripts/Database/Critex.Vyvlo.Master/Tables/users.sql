CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username VARCHAR(255) UNIQUE,
    Email VARCHAR(255) UNIQUE,
    PasswordHash VARCHAR(255),
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    RoleID INT,
    CreatedAt DATETIME,
    UpdatedAt DATETIME,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);

CREATE TABLE Role (
    RoleID INT PRIMARY KEY,
    RoleName VARCHAR(255) UNIQUE,
    Description VARCHAR(255)
);
