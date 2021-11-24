USE [dmaa0920_1086216]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 25-10-2021 15:49:44 ******/


CREATE TABLE [dbo].[Profile](
	[ID] [int] NOT NULL IDENTITY,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsBanned] [bit] NOT NULL,

	primary key (ID),
);



CREATE TABLE [dbo].[Event](
	[ID] [int] NOT NULL IDENTITY,
	[EventName] [varchar](50) NOT NULL,
	[EventCapacity] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[Description] [varchar](500) NULL,
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
	[ZIP] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[EventID] [int] NOT NULL,

	primary key (EventID),
	foreign key (EventID)		references	Event(ID) ON DELETE CASCADE,
);


CREATE TABLE [dbo].[Business](
	[Name] [varchar](50) NOT NULL,
	[CVR] [varchar](50) NOT NULL,
	[Subscription] [bit] NULL,
	[ProfileID] [int] NOT NULL,

	primary key (ProfileID),
	foreign key (ProfileID)		references	Profile(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[ReportUser](
	[AccuserID] [int] NOT NULL,
	[OffenderID] [int] NOT NULL,
	[Description] [varchar](400) NULL,
	[ID] [int] NOT NULL IDENTITY,

	primary key (ID),
	foreign key (AccuserID)		references	Profile(ID),
	foreign key (OffenderID)	references	Profile(ID)ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Chat](
	[DestinationID] [int] NOT NULL,
	[SourceID] [int] NOT NULL,
	[TimeSent] [date] NOT NULL,
	[Body] [varchar](250) NULL,
	[ID] [int] NOT NULL IDENTITY,

	primary key (ID),
	foreign key (DestinationID)	references	Event(ID) ON DELETE CASCADE,
	foreign key (SourceID)		references	Profile(ID) ON DELETE CASCADE,
);


INSERT INTO Profile VALUES('Jens', 'Vils', 'asda@asdasd.sd', '15456585', 'password', '0', 'Male', 'grim som en sten hehe', '0');
INSERT INTO Profile VALUES('Peter', 'Vils', 'asda@asdas.sd', '15456585', 'password', '0', 'Male', 'grim som en sten hehe', '0');
INSERT INTO Profile VALUES('Rasmus', 'Vils', 'asda@asdsd.sd', '15456585', 'password', '0', 'Male', 'grim som en sten hehe', '0');
INSERT INTO Profile VALUES('Ole', 'Vils', 'asda@dasd.sd', '15456585', 'password', '0', 'Male', 'grim som en sten hehe', '0');

INSERT INTO Event VALUES('Privat fest', '10','2018-06-23T05:45:55', '2018-06-23T05:55:55', 'oknadfogknsfg', '1');
INSERT INTO Event VALUES('Offentlig fest', '11','2018-06-23T05:45:55', '2018-06-23T05:55:55', 'oknadfogknsfg', '2');

