USE [HR]
GO

/****** Object:  View [dbo].[payroll]    Script Date: 2019/04/09 8:33:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[payroll]
AS
SELECT        EmpID, Name, ISNULL(BasicSalary, 0) AS BasicSalary, [Acctual Basic Salary], Allowances, Deductions, Tax, [Acctual Basic Salary] + Allowances - Deductions - Tax AS [Full Salary], 
                         [Acctual Basic Salary] + Allowances AS [Total Salary],IsContract
FROM            (SELECT        EmpID, FirstNameAR + ' ' + MidNameAR + ' ' + LastNameAR AS Name, BasicSalary, dbo.AcctualBasicSalaryFN(EmpID) AS [Acctual Basic Salary], dbo.AllowancesFN(EmpID) AS Allowances, dbo.DeductionFN(EmpID) 
                                                    AS Deductions, iif([IsContract]=1,0, dbo.TaxFN(EmpID)) AS Tax,IsContract
                           FROM            dbo.EmployeesTBL
                           WHERE        (IsActive = 1)) AS Foo
GO


