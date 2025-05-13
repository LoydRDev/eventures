CREATE TABLE Users (
    UserID COUNTER PRIMARY KEY,
    FirstName TEXT(50) NOT NULL,
    LastName TEXT(50) NOT NULL,
    Email TEXT(100) NOT NULL,
    PhoneNumber TEXT(15) NOT NULL,
    Username TEXT(50) NOT NULL,
    [Password] TEXT(100) NOT NULL,
    CreatedDate DATETIME DEFAULT Now()
);

/* Create indexes for frequently accessed columns */
CREATE INDEX idx_username ON Users(Username);
CREATE INDEX idx_email ON Users(Email);