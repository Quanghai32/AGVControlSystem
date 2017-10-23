USE [master]
GO
/****** Object:  Table [dbo].[AGV]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AGV](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Enable] [bit] NULL,
	[Address] [nvarchar](8) NULL,
	[Host Xbee] [int] NULL,
	[Part] [nvarchar](200) NULL,
	[Count] [int] NULL,
	[Group] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AGVGroup]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AGVGroup](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [pk_AGVGroup_id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chart]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chart](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[EMG] [float] NULL,
	[Safety] [float] NULL,
	[Stop] [float] NULL,
	[Out line] [float] NULL,
	[Battery empty] [float] NULL,
	[No cart] [float] NULL,
	[Normal] [float] NULL,
	[Free] [float] NULL,
	[Disable] [float] NULL,
	[Disconnect] [float] NULL,
	[Shutdown] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CrossTable]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CrossTable](
	[Id] [bigint] NOT NULL,
	[1] [int] NULL,
	[2] [int] NULL,
	[3] [int] NULL,
	[4] [int] NULL,
	[5] [int] NULL,
	[6] [int] NULL,
	[7] [int] NULL,
	[8] [int] NULL,
	[9] [int] NULL,
	[11] [int] NULL,
	[12] [int] NULL,
	[13] [int] NULL,
	[14] [int] NULL,
	[15] [int] NULL,
	[16] [int] NULL,
	[17] [int] NULL,
	[18] [int] NULL,
	[19] [int] NULL,
	[20] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EndDevices]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EndDevices](
	[Id] [int] NOT NULL,
	[Address] [nvarchar](8) NULL,
	[Host Xbee] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HostXbee]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HostXbee](
	[Id] [int] NOT NULL,
	[Address][nvarchar](8) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LineGroup]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LineGroup](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkPoint]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkPoint](
	[Id] [int] NOT NULL,
	[First] [int] NULL,
	[Second] [int] NULL,
 CONSTRAINT [pk_ParkPoint_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Part]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Part](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Enable] [bit] NULL,
	[Priority] [int] NULL,
	[Group] [int] NULL,
	[EndDevices] [int] NULL,
	[Count] [int] NULL,
	[Target] [int] NULL,
	[Route] [int] NULL,
	[CycleTime][int] NULL,
	[Description][nvarchar](200) NULL,
	[EmptyCount][int] NULL,
	[X][int] NULL,
	[Y][int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StartPoint]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StartPoint](
	[Id] [int] NOT NULL,
	[Card ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkingTime]    Script Date: 6/15/2015 9:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingTime](
	[ID] [int] NOT NULL,
	[BeginTime] [datetime] NULL,
	[StartMorTime] [datetime] NULL,
	[StopMorTime] [datetime] NULL,
	[StartLunTime] [datetime] NULL,
	[StopLunTime] [datetime] NULL,
	[StartAftTime] [datetime] NULL,
	[StopAftTime] [datetime] NULL,
	[EndTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
GRANT ALL ON agv TO PUBLIC
GO
GRANT ALL ON agvgroup TO PUBLIC
GO
GRANT ALL ON chart TO PUBLIC
GO
GRANT ALL ON crosstable TO PUBLIC
GO
GRANT ALL ON enddevices TO PUBLIC
GO
GRANT ALL ON hostxbee TO PUBLIC
GO
GRANT ALL ON linegroup TO PUBLIC
GO
GRANT ALL ON parkpoint TO PUBLIC
GO
GRANT ALL ON part TO PUBLIC
GO
GRANT ALL ON startpoint TO PUBLIC
GO
GRANT ALL ON workingtime TO PUBLIC
GO