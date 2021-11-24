USE [dmaa0920_1086216]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 25-10-2021 15:49:44 ******/


CREATE TABLE [dbo].[Profile](
	[ID] [nvarchar](450) NOT NULL,
	[FirstName] [varchar](50),
	[LastName] [varchar](50),
	[Age] [int],
	[Gender] [varchar](50),
	[Description] [varchar](50),
	[IsBanned] [bit] NOT NULL,

	primary key (ID),
	foreign key (ID)		references	AspNetUsers(Id)	
);


CREATE TABLE [dbo].[Event](
	[ID] [int] NOT NULL IDENTITY,
	[EventName] [varchar](50) NOT NULL,
	[EventCapacity] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[Description] [varchar](500) NULL,
	[ProfileID] [nvarchar](450) NOT NULL,
	
	primary key (ID),
	foreign key (ProfileID)		references	AspNetUsers(Id)
);


CREATE TABLE [dbo].[Match](
	[EventID] [int] NOT NULL,
	[ProfileID] [nvarchar](450) NOT NULL,
	[Match] [bit] NOT NULL
	
	primary key (EventID, ProfileID),
	foreign key (EventID)		references	Event(ID) ON DELETE CASCADE,
	foreign key (ProfileID)		references	AspNetUsers(Id) ON DELETE CASCADE,
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
	[ProfileID] [nvarchar](450) NOT NULL,

	primary key (ProfileID),
	foreign key (ProfileID)		references	AspNetUsers(Id) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[ReportUser](
	[AccuserID] [nvarchar](450) NOT NULL,
	[OffenderID] [nvarchar](450) NOT NULL,
	[Description] [varchar](400) NULL,
	[ID] [int] NOT NULL IDENTITY,

	primary key (ID),
	foreign key (AccuserID)		references	AspNetUsers(Id),
	foreign key (OffenderID)	references	AspNetUsers(Id)ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Chat](
	[DestinationID] [int] NOT NULL,
	[SourceID] [nvarchar](450) NOT NULL,
	[TimeSent] [date] NOT NULL,
	[Body] [varchar](250) NULL,
	[ID] [int] NOT NULL IDENTITY,

	primary key (ID),
	foreign key (DestinationID)	references	Event(ID) ON DELETE CASCADE,
	foreign key (SourceID)		references	AspNetUsers(Id)ON DELETE CASCADE,
);
/*
INSERT INTO Profile VALUES('asda@asdasd.sd', '15456585', 'password', '0', 'grim som en sten hehe');
INSERT INTO Profile VALUES('asda@asdasd.sd', '85654525', '@asda@', '0', 'dårlig live musik');
INSERT INTO Profile VALUES('asda@asdasd.sd', '47832158', '56449879765', '0', 'dårlig live musik');
INSERT INTO Profile VALUES('asda@asdasd.sd', '96154453', 'XxXGamerMusXxX', '0', 'dårlig live musik');
INSERT INTO Profile VALUES('asda@asdasd.sd', '95959595', 'ikkepassword1!', '0', 'dårlig live musik');
INSERT INTO Profile VALUES('asda@asdasd.sd', '+4546464646', 'BestemtPassword', '1', 'tequila er din ven');
*/
/*
INSERT INTO Business VALUES('Flamingo', '53123965', '1', '2');
INSERT INTO Business VALUES('Old Irish', '15312313', '1', '4');
INSERT INTO Business VALUES('Mexi Bar', '12412313', '0', '6');

INSERT INTO Event VALUES('Privat fest', '10','2018-06-23 05:55:55.000', '2018-06-23 05:65:55.000', 'oknadfogknsfg', '4165b52b-27b8-4b3a-ab87-5e4c9590d4e6');
INSERT INTO Event VALUES('Offentlig fest', '11','2018-06-23 05:55:55.000', '2018-06-23 05:65:55.000', 'oknadfogknsfg', '63822908-58dc-49a0-8d20-021041611da4');

INSERT INTO Match VALUES('1', '3', '1');
INSERT INTO Match VALUES('1', '5', '0');
INSERT INTO Match VALUES('2', '1', '1');

INSERT INTO Location VALUES('Aalborg', '9000', '1');
INSERT INTO Location VALUES('Aalborg', '9000', '2');

INSERT INTO ReportUser VALUES ('1', '3');
*/
