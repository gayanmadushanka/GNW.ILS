--Insert a Entity
Truncate Table [dbo].[Entity]
INSERT INTO [dbo].[Entity]([RowGuid]) VALUES (default);

--Insert a Court Type
Truncate Table [dbo].[CourtType]
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Supreme Court','SC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Court of Appeal','COA');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Civil Appellate','CA');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Commercial High Court','CHC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('District Court','DC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('High Court','HC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Magistrate''s Court','MC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Labor Court','LC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Quasi Court','QC');
INSERT INTO[dbo].[CourtType]([Name],[Code]) VALUES ('Labour Tribunal','LT');

 --Insert a Court
 Truncate Table [dbo].[Court] 

 INSERT INTO[dbo].[Court]  ([EntityId],[CourtTypeId],[Name]) VALUES (1, 1, 'Colombo Supreme Court');
 INSERT INTO[dbo].[Court]  ([EntityId],[CourtTypeId],[Name]) VALUES (2, 2, 'Colombo Court of Appeal');
 INSERT INTO[dbo].[Court]  ([EntityId],[CourtTypeId],[Name]) VALUES (3, 2, 'Galle Court of Appeal');

--Insert Department
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Criminal','CRI')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('General','GEN')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Matrimonial','MAT')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Private','PRI')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Wills','WIL')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Probate','PRO')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Personal Injury','PIN')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Housing','HOU')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Uninsured Loss Recovery','ULR')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Conveyancing','CON')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Debt  Recovery','DEB')
INSERT INTO [dbo].[Department]([Name],[Code])VALUES('Employment','EMP')


 --Insert a Employee
INSERT INTO [dbo].[Employee]
           ([EntityId]
           ,[NationalIdNumber]
           ,[LoginID]
           ,[OrganizationNode]
           ,[JobTitle]
           ,[BirthDate]
           ,[MaritalStatus]
           ,[Gender]
           ,[HireDate]
           ,[SalariedFlag]
           ,[VacationHours]
           ,[SickLeaveHours]
           ,[CurrentFlag])
     VALUES
           (1
           ,'873582812v'
           ,'GM'
           ,hierarchyid::GetRoot()
           ,'Super User'
           ,'1980-07-06'
           ,'S'
           ,'M'
           ,'2003-02-15'
           ,1
           ,0
           ,0
           ,1)

 --Insert a Person
INSERT INTO [dbo].[Person]
           ([EntityId]
           ,[PersonType]
           ,[NameStyle]
           ,[Title]
           ,[FirstName]
           ,[LastName])
     VALUES
           (1
           ,'EM'
           ,1
           ,'Ms.'
           ,'Gayan'
           ,'Madushanka'
           )


