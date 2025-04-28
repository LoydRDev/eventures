# Event Management System - Database Setup Guide

This guide provides instructions for setting up the database tables for the Event Management System. The system uses a relational database structure to manage events, attendees, registrations, and notifications.

## Database Tables

### 1. Events Table

```sql
CREATE TABLE Events (
    EventId INT PRIMARY KEY IDENTITY(1,1),
    EventName NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    EventDate DATETIME NOT NULL,
    Location NVARCHAR(255),
    MaxAttendees INT NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    LastModifiedDate DATETIME NOT NULL
);
```

### 2. Attendees Table

```sql
CREATE TABLE Attendees (
    AttendeeId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    Phone NVARCHAR(20),
    Organization NVARCHAR(255),
    RegistrationDate DATETIME NOT NULL
);
```

### 3. Registrations Table

```sql
CREATE TABLE Registrations (
    RegistrationId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    AttendeeId INT NOT NULL,
    RegistrationDate DATETIME NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    AttendanceStatus NVARCHAR(50),
    Notes NVARCHAR(MAX),
    HasAttended BIT NOT NULL DEFAULT 0,
    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (AttendeeId) REFERENCES Attendees(AttendeeId)
);
```

### 4. Notifications Table

```sql
CREATE TABLE Notifications (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    EventId INT NOT NULL,
    AttendeeId INT,
    NotificationType NVARCHAR(50) NOT NULL,
    Message NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    SentDate DATETIME,
    Status NVARCHAR(50) NOT NULL,
    DeliveryMethod NVARCHAR(50) NOT NULL,
    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (AttendeeId) REFERENCES Attendees(AttendeeId)
);
```

## Table Relationships

1. **Events to Registrations**: One-to-Many
   - One event can have multiple registrations
   - Each registration must belong to one event

2. **Attendees to Registrations**: One-to-Many
   - One attendee can have multiple registrations
   - Each registration must belong to one attendee

3. **Events to Notifications**: One-to-Many
   - One event can have multiple notifications
   - Each notification must belong to one event

4. **Attendees to Notifications**: One-to-Many (Optional)
   - One attendee can have multiple notifications
   - A notification may or may not be associated with an attendee

## Important Notes

1. All tables use `IDENTITY(1,1)` for auto-incrementing primary keys
2. Foreign key constraints ensure data integrity
3. Appropriate NVARCHAR lengths are used for string fields
4. Dates are stored as DATETIME for precise timestamp tracking
5. Status fields use NVARCHAR(50) to accommodate various status values
6. Boolean fields (HasAttended) use BIT data type
7. Text fields that may contain large amounts of data use NVARCHAR(MAX)

## Indexes

Consider creating the following indexes for better query performance:

```sql
-- Events Table
CREATE INDEX IX_Events_EventDate ON Events(EventDate);
CREATE INDEX IX_Events_Status ON Events(Status);

-- Registrations Table
CREATE INDEX IX_Registrations_EventId ON Registrations(EventId);
CREATE INDEX IX_Registrations_AttendeeId ON Registrations(AttendeeId);
CREATE INDEX IX_Registrations_Status ON Registrations(Status);

-- Notifications Table
CREATE INDEX IX_Notifications_EventId ON Notifications(EventId);
CREATE INDEX IX_Notifications_AttendeeId ON Notifications(AttendeeId);
CREATE INDEX IX_Notifications_Status ON Notifications(Status);
```