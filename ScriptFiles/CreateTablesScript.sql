USE [AddressBookDB]
GO

/****** Object:  Table [dbo].[AddressBooks]    Script Date: 5/2/2020 8:00:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
Drop table IF EXISTS [dbo].[persons]
Go
Drop table IF EXISTS [dbo].[AddressBooks]
Go

CREATE TABLE [dbo].[AddressBooks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[persons]    Script Date: 5/2/2020 8:02:00 PM ******/



CREATE TABLE [dbo].[persons](
	[Persons_ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NULL,
	[LastName] [varchar](100) NULL,
	[mobile] [bigint] NULL,
	[AddressBook_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Persons_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[persons]  WITH CHECK ADD  CONSTRAINT [fk_Persons_AddressBooks] FOREIGN KEY([AddressBook_ID])
REFERENCES [dbo].[AddressBooks] ([ID])
GO

ALTER TABLE [dbo].[persons] CHECK CONSTRAINT [fk_Persons_AddressBooks]
GO





