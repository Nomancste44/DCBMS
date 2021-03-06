USE [master]
GO
/****** Object:  Database [DiagnosticCenterBillManagementSystem]    Script Date: 24-09-17 23.21.42 ******/
CREATE DATABASE [DiagnosticCenterBillManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DiagnosticCenterBillManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagementSystem.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DiagnosticCenterBillManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DiagnosticCenterBillManagementSystem_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DiagnosticCenterBillManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [DiagnosticCenterBillManagementSystem]
GO
/****** Object:  StoredProcedure [dbo].[spTestNameWiseReport]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[spTestNameWiseReport]
@fromDate Date =null, @toDate Date = null
AS
select TestNames.Name, isnull(TestDemo.TotalTest,0) TotalTest  ,isnull(TestDemo.Total,0) Total
from
(
Select TestNames.Name, TestPatient.TestId,(TestPatient.TestId) TotalTest,(TestNames.Fee*Count(TestPatient.TestId)) Total
From 
(TestPatient right join TestNames on TestNames.Id=TestPatient.TestId)
where [TestPatient].[Date] between @fromDate and @toDate
group by
TestPatient.TestId,
TestNames.Name,
TestNames.Fee
) AS TestDemo
right join

TestNames

on
TestNames.TestTypeId=TestDemo.TestId
Order by 
Total Desc;




GO
/****** Object:  StoredProcedure [dbo].[spTestTypeWiseReport]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spTestTypeWiseReport]
@fromDate Date = NULL , @toDate Date = NULL
AS
Select TestTypes.Name, isnull(count(TypeWiseSum.TotalTest),0) TotalTest , isnull(sum(TypeWiseSum.Total),0) Total

From
  (
select TestNames.TestTypeId, TestNames.Name, isnull(TestWiseSum.TotalTest,0) TotalTest  ,isnull(TestWiseSum.Total,0) Total
from
(
Select TestNames.Name, TestPatient.TestId,(TestPatient.TestId) TotalTest,(TestNames.Fee*Count(TestPatient.TestId)) Total
From 
(TestPatient right join TestNames on TestNames.Id=TestPatient.TestId)
where [TestPatient].[Date] between @fromDate and @toDate
group by
TestPatient.TestId,
TestNames.Name,
TestNames.Fee
)         AS TestWiseSum
           inner join
           TestNames

            on
       TestNames.TestTypeId=TestWiseSum.TestId)
            AS 
		TypeWiseSum

RIGHT JOIN

TestTypes

on

TypeWiseSum.TestTypeId=TestTypes.Id


Group by

TypeWiseSum.TestTypeId,
TestTypes.Name
Order by Total
DESC;






GO
/****** Object:  StoredProcedure [dbo].[spUnpaidBill]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[spUnpaidBill] 
@fromDate DATE =null, @toDate DATE = null
AS
SELECT BillInformation.BillNumber, Patients.MobileNumber, Patients.Name, BillInformation.TotalAmount

FROM Patients INNER JOIN BillInformation ON Patients.MobileNumber=BillInformation.P_MobileNumber

WHERE BillInformation.BillStatus='Unpaid' AND (BillInformation.[Date] BETWEEN @fromDate AND @toDate) ;

GO
/****** Object:  StoredProcedure [dbo].[spViewBillNumber]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROC [dbo].[spViewBillNumber]
	@MobileNumber Varchar(50) = NULL
	AS
SELECT [BillNumber]
  FROM [BillInformation]
  WHERE P_MobileNumber=@MobileNumber;
GO
/****** Object:  Table [dbo].[BillInformation]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BillInformation](
	[BillNumber] [varchar](150) NOT NULL,
	[BillStatus] [varchar](10) NOT NULL,
	[Date] [date] NOT NULL,
	[P_MobileNumber] [varchar](15) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_BillInformation] PRIMARY KEY CLUSTERED 
(
	[BillNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[MobileNumber] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestNames]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestNames](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Fee] [float] NOT NULL,
	[TestTypeId] [int] NOT NULL,
 CONSTRAINT [PK_TestName] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TestPatient]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestPatient](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[TestId] [int] NOT NULL,
	[Date] [date] NOT NULL CONSTRAINT [DF_TestPatient_Date]  DEFAULT (getdate()),
 CONSTRAINT [PK_TestPatient] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestTypes]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TestTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TestTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[VW_TestNames]    Script Date: 24-09-17 23.21.42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[VW_TestNames]
as 
select TestNames.Name as Name,TestNames.Fee as Fee, TestTypes.Name as [Type]
from 
TestNames inner join TestTypes on TestNames.TestTypeId=TestTypes.Id




GO
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 00.40.15BILL_6849', N'Unpaid', CAST(N'2017-09-24' AS Date), N'01829902222', CAST(950.00 AS Decimal(18, 2)))
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 10.28.41BILL_1331', N'Paid', CAST(N'2017-09-24' AS Date), N'01829902221', CAST(750.00 AS Decimal(18, 2)))
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 10.43.50BILL_4062', N'Unpaid', CAST(N'2017-09-24' AS Date), N'13435135', CAST(1700.00 AS Decimal(18, 2)))
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 11.01.10BILL_5915', N'Unpaid', CAST(N'2017-09-24' AS Date), N'018299022221', CAST(2400.00 AS Decimal(18, 2)))
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 11.05.57BILL_4908', N'Unpaid', CAST(N'2017-09-24' AS Date), N'018299022211', CAST(400.00 AS Decimal(18, 2)))
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 11.09.38BILL_8577', N'Unpaid', CAST(N'2017-09-24' AS Date), N'01829028234', CAST(1850.00 AS Decimal(18, 2)))
INSERT [dbo].[BillInformation] ([BillNumber], [BillStatus], [Date], [P_MobileNumber], [TotalAmount]) VALUES (N'#24-09-17 11.14.44BILL_8092', N'Unpaid', CAST(N'2017-09-24' AS Date), N'01829028232', CAST(1950.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (27, N'Wasif Bhuiyan', CAST(N'0021-01-21' AS Date), N'01829902222')
INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (28, N'Abdullah AL Noman', CAST(N'2017-01-01' AS Date), N'01829902221')
INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (29, N'Wasif Bhuiyan', CAST(N'2017-09-05' AS Date), N'13435135')
INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (30, N'Wasif Bhuiyan', CAST(N'2017-09-05' AS Date), N'018299022221')
INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (31, N'Wasif Bhuiyan', CAST(N'2017-09-12' AS Date), N'018299022211')
INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (32, N'Wasif Bhuiyan', CAST(N'2017-09-14' AS Date), N'01829028234')
INSERT [dbo].[Patients] ([Id], [Name], [BirthDate], [MobileNumber]) VALUES (33, N'Wasif Bhuiyan', CAST(N'2017-09-12' AS Date), N'01829028232')
SET IDENTITY_INSERT [dbo].[Patients] OFF
SET IDENTITY_INSERT [dbo].[TestNames] ON 

INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (1, N'Complete Blood count     ', 400, 1)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (2, N'RBS     ', 150, 1)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (3, N'S. Creatinine ', 350, 1)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (4, N'Lipid profile ', 450, 1)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (5, N'Hand X-ray', 200, 2)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (6, N'Feet X-ray', 300, 2)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (7, N'LS Spine  ', 1100, 2)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (9, N'Lower Abdomen ', 550, 3)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (10, N'Whole Abdomen', 800, 3)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (11, N'Pregnancy profile  ', 550, 3)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (12, N'ECG', 150, 4)
INSERT [dbo].[TestNames] ([Id], [Name], [Fee], [TestTypeId]) VALUES (23, N'ECHO', 1000, 5)
SET IDENTITY_INSERT [dbo].[TestNames] OFF
SET IDENTITY_INSERT [dbo].[TestPatient] ON 

INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (53, 27, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (54, 27, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (55, 27, 12, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (56, 28, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (57, 28, 12, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (58, 28, 5, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (59, 29, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (60, 29, 12, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (61, 29, 12, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (62, 29, 23, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (63, 30, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (64, 30, 23, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (65, 30, 23, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (66, 31, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (67, 32, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (68, 32, 7, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (69, 32, 3, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (70, 33, 1, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (71, 33, 23, CAST(N'2017-09-24' AS Date))
INSERT [dbo].[TestPatient] ([Id], [PatientId], [TestId], [Date]) VALUES (72, 33, 9, CAST(N'2017-09-24' AS Date))
SET IDENTITY_INSERT [dbo].[TestPatient] OFF
SET IDENTITY_INSERT [dbo].[TestTypes] ON 

INSERT [dbo].[TestTypes] ([Id], [Name]) VALUES (1, N'Blood')
INSERT [dbo].[TestTypes] ([Id], [Name]) VALUES (2, N'X-Ray ')
INSERT [dbo].[TestTypes] ([Id], [Name]) VALUES (3, N'USG')
INSERT [dbo].[TestTypes] ([Id], [Name]) VALUES (4, N'ECG ')
INSERT [dbo].[TestTypes] ([Id], [Name]) VALUES (5, N'Echo')
SET IDENTITY_INSERT [dbo].[TestTypes] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UK_Patients]    Script Date: 24-09-17 23.21.42 ******/
ALTER TABLE [dbo].[Patients] ADD  CONSTRAINT [UK_Patients] UNIQUE NONCLUSTERED 
(
	[MobileNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BillInformation]  WITH CHECK ADD  CONSTRAINT [FK_BillInformation_Patients] FOREIGN KEY([P_MobileNumber])
REFERENCES [dbo].[Patients] ([MobileNumber])
GO
ALTER TABLE [dbo].[BillInformation] CHECK CONSTRAINT [FK_BillInformation_Patients]
GO
ALTER TABLE [dbo].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_Patients] FOREIGN KEY([Id])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[Patients] CHECK CONSTRAINT [FK_Patients_Patients]
GO
ALTER TABLE [dbo].[TestNames]  WITH CHECK ADD  CONSTRAINT [FK_TestNames_TestTypes] FOREIGN KEY([TestTypeId])
REFERENCES [dbo].[TestTypes] ([Id])
GO
ALTER TABLE [dbo].[TestNames] CHECK CONSTRAINT [FK_TestNames_TestTypes]
GO
ALTER TABLE [dbo].[TestPatient]  WITH CHECK ADD  CONSTRAINT [FK_TestPatient_Patients] FOREIGN KEY([PatientId])
REFERENCES [dbo].[Patients] ([Id])
GO
ALTER TABLE [dbo].[TestPatient] CHECK CONSTRAINT [FK_TestPatient_Patients]
GO
ALTER TABLE [dbo].[TestPatient]  WITH CHECK ADD  CONSTRAINT [FK_TestPatient_TestNames] FOREIGN KEY([TestId])
REFERENCES [dbo].[TestNames] ([Id])
GO
ALTER TABLE [dbo].[TestPatient] CHECK CONSTRAINT [FK_TestPatient_TestNames]
GO
USE [master]
GO
ALTER DATABASE [DiagnosticCenterBillManagementSystem] SET  READ_WRITE 
GO
