USE [AnalyticDatabase]
GO

/****** Object:  Table [dbo].[AnaliticData]    Script Date: 3/2/2021 12:42:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AnaliticData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TimeStamp] [datetime] NOT NULL,
	[UserName] [nvarchar](100) NOT NULL,
	[IsClick] [bit] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AnaliticData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AnaliticData] ADD  CONSTRAINT [DF_AnaliticData_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO

