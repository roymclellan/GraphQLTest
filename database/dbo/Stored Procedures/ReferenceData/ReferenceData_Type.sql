CREATE PROCEDURE [dbo].[ReferenceData_Type]
AS
BEGIN
	SET IDENTITY_INSERT [dbo].[Type] ON
	MERGE INTO [dbo].[Type] AS TARGET
	USING(
		VALUES
		  (1, 'Cash')
		, (2, 'Savings')
		, (3, 'Expense')
		, (4, 'Income')
	)
	AS SOURCE([TypeId], [Name])
	ON TARGET.[TypeId] = SOURCE.[TypeId]
	WHEN MATCHED THEN

	UPDATE SET
		[Name] = SOURCE.[Name]

	WHEN NOT MATCHED BY TARGET THEN
	INSERT ([TypeId], [Name])
	VALUES ([TypeId], [Name])

	WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

	SET IDENTITY_INSERT [dbo].[Type] OFF;
END

