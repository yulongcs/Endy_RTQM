/****** Object:  Table [dbo].[Notifications]    Script Date: 07/04/2012 08:48:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Notifications](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](20) NOT NULL,
	[From] [varchar](100) NULL,
	[To] [varchar](200) NOT NULL,
	[Subject] [varchar](100) NOT NULL,
	[Content] [varchar](max) NOT NULL,
	[FailedMessage] [varchar](1000) NULL,
	[ReadySendTime] [datetime] NOT NULL,
	[ActualSendTime] [datetime] NULL,
	[Status] [varchar](10) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  Table [dbo].[NotificationAttachments]    Script Date: 07/04/2012 08:48:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotificationAttachments](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[NotificationID] [bigint] NOT NULL,
	[ExpectName] [nvarchar](50) NULL,
	[FilePath] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_NotificationAttachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[NotificationAttachments]  WITH CHECK ADD  CONSTRAINT [FK_NotificationAttachments_Notifications] FOREIGN KEY([NotificationID])
REFERENCES [dbo].[Notifications] ([ID])
GO

ALTER TABLE [dbo].[NotificationAttachments] CHECK CONSTRAINT [FK_NotificationAttachments_Notifications]
GO