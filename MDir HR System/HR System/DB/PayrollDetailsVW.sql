USE [HR]
GO

/****** Object:  View [dbo].[PayrollDetailsVW]    Script Date: 2019/04/09 8:54:37 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[PayrollDetailsVW]
AS
SELECT        dbo.EmployeesTBL.EmpID, dbo.EmployeesTBL.FirstNameAR + N' ' + dbo.EmployeesTBL.MidNameAR + N' ' + dbo.EmployeesTBL.LastNameAR AS Name, dbo.EmployeesTBL.LeaveDate, dbo.EmployeesTBL.BasicSalary, 
                         dbo.EmployeesTBL.MaturityDate AS EmployementStartDate, Allowance, Descreption, ParentID, IsContract
FROM            [dbo].[EmployeesTBL] CROSS APPLY[dbo].[AllowancesTabFN]([EmployeesTBL].empid) LEFT JOIN
                         [dbo].[ValuesTBL] ON ValuesTBL.TitleAR = AllowancesTabFN.Descreption AND ValuesTBL.ParentID <> 0
GO

