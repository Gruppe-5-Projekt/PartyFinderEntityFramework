USE [dmaa0920_1086216]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 25-10-2021 15:49:44 ******/


CREATE TABLE [dbo].[Profile](
	[ID] [int] NOT NULL IDENTITY,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Age] [datetime] NOT NULL,
	[Gender] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[IsBanned] [bit] NOT NULL,
	[AspNetUserForeignKey] [nvarchar](450) NOT NULL,

	primary key (ID),
	foreign key (AspNetUserForeignKey)	references AspNetUsers(Id)
);



CREATE TABLE [dbo].[Event](
	[ID] [int] NOT NULL IDENTITY,
	[EventName] [nvarchar](50) NOT NULL,
	[EventCapacity] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[ProfileID] [int] NOT NULL,
	
	primary key (ID),
	foreign key (ProfileID)		references	Profile(ID)
);


CREATE TABLE [dbo].[Match](
	[EventID] [int] NOT NULL,
	[ProfileID] [int] NOT NULL,
	[Match] [bit] NOT NULL
	
	primary key (EventID, ProfileID),
	foreign key (EventID)		references	Event(ID) ON DELETE CASCADE,
	foreign key (ProfileID)		references	Profile(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Location](
	[ZIP] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[EventID] [int] NOT NULL,

	primary key (EventID),
	foreign key (EventID)		references	Event(ID) ON DELETE CASCADE,
);


CREATE TABLE [dbo].[Business](
	[Name] [nvarchar](50) NOT NULL,
	[CVR] [nvarchar](50) NOT NULL,
	[Subscription] [bit] NULL,
	[ProfileID] [int] NOT NULL,

	primary key (ProfileID),
	foreign key (ProfileID)		references	Profile(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[ReportUser](
	[AccuserID] [int] NOT NULL,
	[OffenderID] [int] NOT NULL,
	[Description] [nvarchar](400) NULL,
	[ID] [int] NOT NULL IDENTITY,

	primary key (ID),
	foreign key (AccuserID)		references	Profile(ID),
	foreign key (OffenderID)	references	Profile(ID)ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Chat](
	[DestinationID] [int] NOT NULL,
	[SourceID] [int] NOT NULL,
	[TimeSent] [date] NOT NULL,
	[Body] [nvarchar](250) NULL,
	[ID] [int] NOT NULL IDENTITY,

	primary key (ID),
	foreign key (DestinationID)	references	Event(ID) ON DELETE CASCADE,
	foreign key (SourceID)		references	Profile(ID) ON DELETE CASCADE,
);

INSERT INTO Profile VALUES('Admin', 'Adminson', '1998-01-01T23:59:59.997', 'Male','Admin', '0', '9f4527d7-a2a4-4450-ac06-e035676b75e5');
