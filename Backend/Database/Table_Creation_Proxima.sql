CREATE DATABASE Proxima_Database

use Proxima_Database

-- Table: UserRoles
CREATE TABLE UserRoles (
    RoleID INT IDENTITY(1,1) PRIMARY KEY,
    RoleName VARCHAR(100) NOT NULL UNIQUE,
    Description VARCHAR(255)
);

-- Table: TaskTypes
CREATE TABLE TaskTypes (
    TaskTypeID INT IDENTITY(1,1) PRIMARY KEY,
    TypeName VARCHAR(100) NOT NULL UNIQUE
);

-- Table: Users
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Password VARCHAR(50) NOT NULL,
    RoleID INT NOT NULL FOREIGN KEY REFERENCES UserRoles(RoleID),
    Status BIT NOT NULL DEFAULT 1, -- 1: Active, 0: Inactive
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

-- Table: Clients
CREATE TABLE Clients (
    ClientID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(50),
    Address VARCHAR(50),
    Status BIT NOT NULL DEFAULT 1, -- 1: Active, 0: Inactive
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

-- Table: Projects
CREATE TABLE Projects (
    ProjectID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(100),
    ClientID INT FOREIGN KEY REFERENCES Clients(ClientID),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Upcoming' CHECK (Status IN ('Ongoing', 'Completed', 'Upcoming', 'Archived')),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

-- Table: Milestones
CREATE TABLE Milestones (
    MilestoneID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID),
    Title VARCHAR(100) NOT NULL,
    DueDate DATETIME NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'Pending' CHECK (Status IN ('Pending', 'Achieved'))
);

-- Table: ProjectAssignments
CREATE TABLE ProjectAssignments (
    AssignmentID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    RoleID INT FOREIGN KEY REFERENCES UserRoles(RoleID),
    AssignedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table: Teams
CREATE TABLE Teams (
    TeamID INT IDENTITY(1,1) PRIMARY KEY,
    TeamName VARCHAR(100) NOT NULL,
    Description VARCHAR(100),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

-- Table: TeamMembers
CREATE TABLE TeamMembers (
    TeamMemberID INT IDENTITY(1,1) PRIMARY KEY,
    TeamID INT FOREIGN KEY REFERENCES Teams(TeamID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    AssignedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table: Tasks
CREATE TABLE Tasks (
    TaskID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(100) NOT NULL,
    Description VARCHAR(100),
    TaskTypeID INT FOREIGN KEY REFERENCES TaskTypes(TaskTypeID),
    DueDate DATETIME NOT NULL,
    Status VARCHAR(50) NOT NULL DEFAULT 'In Progress' CHECK (Status IN ('In Progress', 'Under Review', 'Completed')),
    AssignedTo INT FOREIGN KEY REFERENCES Users(UserID),
    ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL
);

-- Table: TaskAssignments
CREATE TABLE TaskAssignments (
    AssignmentID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT FOREIGN KEY REFERENCES Tasks(TaskID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    RoleID INT FOREIGN KEY REFERENCES UserRoles(RoleID),
    AssignedAt DATETIME NOT NULL DEFAULT GETDATE()
);	

-- Table: TaskAttachments
CREATE TABLE TaskAttachments (
    AttachmentID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT FOREIGN KEY REFERENCES Tasks(TaskID),
    FilePath VARCHAR(500) NOT NULL,
    UploadedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table: TaskComments
CREATE TABLE TaskComments (
    CommentID INT IDENTITY(1,1) PRIMARY KEY,
    TaskID INT FOREIGN KEY REFERENCES Tasks(TaskID),
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Comment VARCHAR(MAX),
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table: Notifications
CREATE TABLE Notifications (
    NotificationID INT IDENTITY(1,1) PRIMARY KEY,
    SenderID INT FOREIGN KEY REFERENCES Users(UserID),
    ReceiverID INT FOREIGN KEY REFERENCES Users(UserID),
    Message VARCHAR(MAX),
    SentAt DATETIME NOT NULL DEFAULT GETDATE(),
    IsRead BIT NOT NULL DEFAULT 0
);

-- Table: ActivityLog
CREATE TABLE ActivityLog (
    ActivityID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    Action VARCHAR(MAX),
    ActionTime DATETIME NOT NULL DEFAULT GETDATE()
);

-- Table: Sprints
CREATE TABLE Sprints (
    SprintID INT IDENTITY(1,1) PRIMARY KEY,
    ProjectID INT FOREIGN KEY REFERENCES Projects(ProjectID),
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    Status VARCHAR(50) NOT NULL CHECK (Status IN ('Ongoing', 'Completed', 'Failed')),
    Goals VARCHAR(255)
);

-- Table: SprintTasks
CREATE TABLE SprintTasks (
    SprintTaskID INT IDENTITY(1,1) PRIMARY KEY,
    SprintID INT FOREIGN KEY REFERENCES Sprints(SprintID),
    TaskID INT FOREIGN KEY REFERENCES Tasks(TaskID)
);

CREATE TABLE Permissions (
    PermissionID INT PRIMARY KEY IDENTITY(1, 1),
    PermissionName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE RolePermissions (
    RolePermissionID INT PRIMARY KEY IDENTITY(1, 1),
    RoleID INT NOT NULL FOREIGN KEY REFERENCES UserRoles(RoleID),
    PermissionID INT NOT NULL FOREIGN KEY REFERENCES Permissions(PermissionID)
);

INSERT INTO Permissions (PermissionName) VALUES 
('AddProject'), 
('UpdateProject'), 
('DeleteProject'), 
('AssignProject'),
('AddTask'),
('UpdateTask'),
('AssignTask'),
('DeleteTask'),
('ViewProject');

DELETE FROM Permissions

select * from Permissions

INSERT INTO RolePermissions (RoleID, PermissionID)
SELECT 1, PermissionID FROM Permissions;
DELETE FROM RolePermissions
where RoleID = 2
select * from RolePermissions

INSERT INTO RolePermissions(RoleID, PermissionID)
VALUES
(2, 8), -- UpdateProject
(2,11), --AddTask
(2,10), --AssignProject
(2,12), --UpdateTask
(2,14), --DeleteTask
(2, 13), -- AssignTask
(2,15); --ViewProjects

INSERT INTO RolePermissions (RoleID, PermissionID)
VALUES
(3, 15);

INSERT INTO RolePermissions (RoleID, PermissionID)
VALUES
(4, 15); -- ViewProject


------------------------------------------Record Insertion---------------------------------------------

--1. UserRoles

INSERT INTO UserRoles (RoleName, Description)
VALUES
('Admin', 'Administrator with full access'),
('PM', 'Project Manager'),
('TM', 'Team Member'),
('Client', 'Client providing projects');

SELECT * FROM UserRoles

--2. TaskTypes

INSERT INTO TaskTypes (TypeName)
VALUES
('Design'),
('Development'),
('Testing'),
('High Priority');

SELECT * FROM TaskTypes

--3. Users

INSERT INTO Users (Name, Email, Password, RoleID, Status, CreatedAt)
VALUES
('John Doe', 'john.doe@example.com', 'encryptedPassword1', 1, 1, GETDATE()),
('Jane Smith', 'jane.smith@example.com', 'encryptedPassword2', 2, 1, GETDATE());

SELECT * FROM Users

--4.Clients

INSERT INTO Clients (Name, Email, Phone, Address, Status, CreatedAt)
VALUES
('Tech Solutions', 'contact@techsolutions.com', '123-456-7890', '123 Tech Street', 1, GETDATE()),
('Build Corp', 'info@buildcorp.com', '987-654-3210', '789 Build Ave', 1, GETDATE());

SELECT * FROM Clients

--5.Projects

INSERT INTO Projects (Title, Description, ClientID, StartDate, EndDate, Status, CreatedAt)
VALUES
('Website Development', 'Develop a company website', 1, '2025-01-01', '2025-03-01', 'Upcoming', GETDATE()),
('Mobile App', 'Create a mobile application', 2, '2025-02-01', '2025-06-01', 'Upcoming', GETDATE());

SELECT * FROM Projects

--6. Milestones

INSERT INTO Milestones (ProjectID, Title, DueDate, Status)
VALUES
(1, 'Design Completion', '2025-01-15', 'Pending'),
(2, 'Initial Release', '2025-05-01', 'Pending');

SELECT * FROM Milestones

--7. ProjectAssignments

INSERT INTO ProjectAssignments (ProjectID, UserID, RoleID, AssignedAt)
VALUES
(1, 2, 2, GETDATE()), -- Assigned project to PM
(2,1, 3, GETDATE()); -- Assigned project to a team member

SELECT * FROM ProjectAssignments

--8. Teams

INSERT INTO Teams (TeamName, Description, CreatedAt)
VALUES
('Development Team', 'Handles all development tasks', GETDATE()),
('Design Team', 'Focuses on design and user experience', GETDATE());

SELECT * FROM Teams

--9. TeamMembers

INSERT INTO TeamMembers (TeamID, UserID, AssignedAt)
VALUES
(1, 1, GETDATE()),
(2, 2, GETDATE());

SELECT * FROM TeamMembers

--10. Tasks

INSERT INTO Tasks (Title, Description, TaskTypeID, DueDate, Status, AssignedTo, ProjectID, CreatedAt)
VALUES
('Create Mockups', 'Design initial mockups for the website', 1, '2025-01-10', 'In Progress',1 , 1, GETDATE()),
('API Integration', 'Integrate APIs into the app', 2, '2025-05-01', 'In Progress', 2, 2, GETDATE());

SELECT * FROM Tasks

--11. TaskAssignments

INSERT INTO TaskAssignments (TaskID, UserID, RoleID, AssignedAt)
VALUES
(3, 2, 2, GETDATE()),
(2, 1, 1, GETDATE());

SELECT * FROM TaskAssignments

--12. TaskAttachments

INSERT INTO TaskAttachments (TaskID, FilePath, UploadedAt)
VALUES
(2, 'C:\\Files\\Mockups.pdf', GETDATE()),
(3, 'C:\\Files\\API_Documentation.pdf', GETDATE());

SELECT * FROM TaskAttachments

--13. TaskComments

INSERT INTO TaskComments (TaskID, UserID, Comment, CreatedAt)
VALUES
(2, 1, 'Please review the mockups.', GETDATE()),
(3, 2, 'API integration is in progress.', GETDATE());

SELECT * FROM TaskComments

--14. Notifications

INSERT INTO Notifications (SenderID, ReceiverID, Message, SentAt)
VALUES
(1, 2, 'New project assigned to you.', GETDATE()),
(2, 1, 'Please complete the task by the due date.', GETDATE());

SELECT * FROM Notifications

--15. ActivityLog

INSERT INTO ActivityLog (UserID, Action, ActionTime)
VALUES
(2, 'Assigned a task to a team member', GETDATE()),
(1, 'Uploaded a file for the task', GETDATE());

SELECT * FROM ActivityLog

--16. Sprints

INSERT INTO Sprints (ProjectID, StartDate, EndDate, Status, Goals)
VALUES
(1, '2025-01-01', '2025-01-07', 'Ongoing', 'Complete initial design'),
(2, '2025-02-01', '2025-02-07', 'Ongoing', 'Complete backend setup');

Select * from Sprints

--17. SprintTasks

INSERT INTO SprintTasks (SprintID, TaskID)
VALUES
(1, 3),
(2, 2);

Select * from SprintTasks









