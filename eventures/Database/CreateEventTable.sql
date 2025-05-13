CREATE TABLE Events (
    EventID COUNTER PRIMARY KEY,
    EventName TEXT(100) NOT NULL,
    Category TEXT(50) NOT NULL,
    Description TEXT(255),
    EventDate DATETIME NOT NULL,
    EventStart DATETIME NOT NULL,
    EventEnd DATETIME NOT NULL,
    Location TEXT(100) NOT NULL,
    AgeRestriction TEXT(10) NOT NULL,
    Capacity NUMBER NOT NULL,
    CreatorID NUMBER NOT NULL,
    CreatedDate DATETIME DEFAULT Now(),
    CONSTRAINT fk_creator FOREIGN KEY (CreatorID) REFERENCES Users(UserID)
);

/* Create indexes for frequently accessed columns */
CREATE INDEX idx_eventdate ON Events(EventDate);
CREATE INDEX idx_creator ON Events(CreatorID);