CREATE PROCEDURE [dbo].[ReferenceData_Account]
AS
BEGIN
	SET IDENTITY_INSERT [dbo].[Account] ON

	MERGE INTO [dbo].[Account] AS TARGET
	USING(
		VALUES
		  (1, 1, 'Cash account for our users', 1)
		, (2, 2, 'Savings account for our users', 2)
		, (3, 4, 'Income account for our users', 2)
	)
	AS SOURCE([Id],[TypeId], [Description], [OwnerId])
	ON TARGET.[Id] = SOURCE.[Id]
	WHEN MATCHED THEN

	UPDATE SET
		  [TypeId] = SOURCE.[TypeId]  
		, [Description] = SOURCE.[Description]
		, [OwnerId] = SOURCE.[OwnerId]

	WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [TypeId], [Description], [OwnerId])
	VALUES ([Id], [TypeId], [Description], [OwnerId])

	WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

	SET IDENTITY_INSERT [dbo].[Account] OFF
END
