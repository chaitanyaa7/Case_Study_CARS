-- create CARS database
create database CARS
drop DATABASE CARS


-- Create table for Incidents
CREATE TABLE Incidents (
    IncidentID INT PRIMARY KEY Identity(1,1),
    IncidentType VARCHAR(50) not null check(IncidentType in( 'Robbery', 'Homicide', 'Theft')),
    IncidentDate DATE not null,
   Location VARCHAR(255) not null,
    Description TEXT not null,
    Status VARCHAR(20) not null check(Status in('Open', 'Closed', 'Under Investigation')),
    VictimID INT not null,
    SuspectID INT not null,
    FOREIGN KEY (VictimID) REFERENCES Victims(VictimID),
    FOREIGN KEY (SuspectID) REFERENCES Suspects(SuspectID)
);

select * from Incidents

-- Create table for Victims
CREATE TABLE Victims (
    VictimID INT PRIMARY KEY Identity(100,1),
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    DateOfBirth DATE not null,
    Gender VARCHAR(10) not null,
    ContactInformation BIGINT not null
);

-- Create table for Suspects
CREATE TABLE Suspects (
    SuspectID INT PRIMARY KEY Identity(200,1),
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    DateOfBirth DATE not null,
    Gender VARCHAR(10) not null,
    ContactInformation BIGINT not null
);

-- Create table for Law Enforcement Agencies
CREATE TABLE LawEnforcementAgencies (
    AgencyID INT PRIMARY KEY Identity(300,1),
    AgencyName VARCHAR(100) not null,
    Jurisdiction VARCHAR(100) not null,
    ContactInformation BIGINT not null,
    OfficerID INT not null,
);


-- Create table for Officers
CREATE TABLE Officers (
    OfficerID INT PRIMARY KEY Identity(350,1),
    FirstName VARCHAR(50) not null,
    LastName VARCHAR(50) not null,
    BadgeNumber INT not null,
    Rank VARCHAR(50) not null,
    ContactInformation BIGINT  not null,
    AgencyID INT not null,
    FOREIGN KEY (AgencyID) REFERENCES LawEnforcementAgencies(AgencyID)
);




-- Create table for Evidence
CREATE TABLE Evidence (
    EvidenceID INT PRIMARY KEY Identity(400,1),
    Description TEXT not null,
    LocationFound VARCHAR(255) not null,
    IncidentID INT not null,
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID)
);

-- Create table for Reports
CREATE TABLE Reports (
    ReportID INT PRIMARY KEY Identity(450,1),
    IncidentID INT not null,
    ReportingOfficer INT not null,
    ReportDate DATE not null,
    ReportDetails TEXT not null,
    Status VARCHAR(100) not null check(Status in('Draft','Finalized')),
    FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID),
    FOREIGN KEY (ReportingOfficer) REFERENCES Officers(OfficerID)
);

-- Create a case table 
CREATE TABLE Cases (
    CaseID INT PRIMARY KEY IDENTITY(1,1),
    CaseNo VARCHAR(100) NOT NULL,
    CaseDescription TEXT,
    IncidentID INT NOT NULL,
    OfficerID INT NOT NULL,
    CONSTRAINT FK_Incident_Case FOREIGN KEY (IncidentID) REFERENCES Incidents(IncidentID),
    CONSTRAINT FK_Officer_Case FOREIGN KEY (OfficerID) REFERENCES Officers(OfficerID)
); 



--Insert into Incidents 

INSERT INTO Incidents (IncidentType, IncidentDate,Location, Description, Status, VictimID, SuspectID)
VALUES ('Robbery', '2024-05-03', 'Indore', 'Convenience store robbery', 'Open', 100, 200)
INSERT INTO Incidents (IncidentType, IncidentDate,Location, Description, Status, VictimID, SuspectID)
VALUES ('Homicide', '2024-05-02','Mumbai', 'Vehicle collision, driver fled the scene', 'Under Investigation', 101, 201) 
INSERT INTO Incidents (IncidentType, IncidentDate,Location, Description, Status, VictimID, SuspectID)
VALUES ('Theft', '2024-05-03','Delhi', 'Shoplifting at department store', 'Closed', 102, 202)
INSERT INTO Incidents (IncidentType, IncidentDate,Location, Description, Status, VictimID, SuspectID)
VALUES ('Homicide', '2024-05-03','Ahmedabad', 'Murder at the appartment', 'Open', 103, 203)



-- Insert into Victims
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES ('John', 'Doe', '1980-01-01', 'Male',  4758963245)
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender,ContactInformation)
VALUES ('Jane', 'Smith', '1975-07-15', 'Male',  5555553434)
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES ('Vikram', 'Mehta', '1995-09-25', 'Male', 7854123698)
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES  ('Sonia', 'Gupta', '1992-04-12', 'Female', 9854712365)



--Insert into Suspects 
INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, ContactInformation)
VALUES
  ('Amit', 'Kumar', '1980-01-31', 'Male', 6547895412),
  ('Rani', 'Singh', '1975-08-22', 'Female', 6321478598),
  ('Jane', 'Smith', '1975-07-15', 'Male',  5555553434),
 ('Sonia', 'Gupta', '1992-04-12', 'Female', 9854712365)

--Insert into LawEnforcementAgencies
INSERT INTO LawEnforcementAgencies (AgencyName, Jurisdiction, ContactInformation, OfficerID)
VALUES ('Indore Police', 'Indore, Madhya Pradesh', 7323430100, 350),
  ('Mumbai Police Department', 'Mumbai, Maharashtra', 9122600100, 351),
  ('Delhi Police', 'Delhi', 9123017474, 352),
  ('Ahmedabad City Police', 'Ahmedabad, Gujarat', 9126567100, 353)
 


--Insert into Officers 
INSERT INTO Officers (FirstName, LastName, BadgeNumber, Rank, ContactInformation, AgencyID)
VALUES('Sonia', 'Gupta', 10987, 'Inspector', 9167890567, 301),  -- Indore Police
  ('Akash', 'Verma', 12345, 'Inspector', 9876543210, 302),  -- Mumbai Police 
  ('Kiara', 'Kaur', 54321, 'Sub-Inspector', 9876543210, 303),  -- Delhi Police
   ('Rohan', 'Shah', 67890, 'Inspector', 9780125678, 304)  -- Ahmedabad Police
 


--Insert into Evidence 
INSERT INTO Evidence (Description, LocationFound, IncidentID)
VALUES
  ('Fingerprint lifted from the crime scene', 'Victim apartment', 7),
  ('Tire tracks found at the scene', 'Dirt road near the abandoned warehouse', 6),
  ('Ballistic evidence (bullet casings)', 'Forensics lab', 3),
  ('DNA sample from the crime scene', 'Crime scene investigation', 1)

--Insert into Reports 
INSERT INTO Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES
  (1, 358, '2024-05-03', 'Initial report of a homicide at the victims apartment. Fingerprint evidence collected.', 'Draft'),
  (3, 359, '2024-05-03', 'Follow-up investigation at the crime scene. Murder weapon recovered.', 'Draft'),
  (6, 360, '2024-05-03', 'Witness interview conducted. Witness provided description of the suspect.', 'Draft'),
  (7, 361, '2024-05-04', 'Security camera footage obtained from nearby store. Suspect identified.', 'Draft')
  
--insert into cases
INSERT INTO Cases (CaseNo, CaseDescription, IncidentID, OfficerID)
VALUES ('CASE101', 'Robbery at convenience store',  1, 358),
    ('CASE102', 'Car break-in, laptop stolen',  3, 359),
    ('CASE103', 'Domestic violence incident',  6, 360),
    ('CASE104', 'Bank robbery',  7, 361)
    
select * from Incidents 
select * from Victims 
select * from Suspects 
select * from LawEnforcementAgencies 
select * from Officers 
select * from Evidence 
select * from Reports 
select * from Cases
