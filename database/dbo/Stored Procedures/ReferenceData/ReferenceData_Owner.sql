CREATE PROCEDURE [dbo].[ReferenceData_Owner]
AS
BEGIN
	SET IDENTITY_INSERT [dbo].[Owner] ON

	MERGE INTO [dbo].[Owner] AS TARGET
	USING(
		VALUES
		  (1, 'John Doe', 'John Does address')
		, (2, 'Jane Doe', 'Jane Does address')
	)
	AS SOURCE([Id], [Name], [ADDRESS])
	ON TARGET.[Id] = SOURCE.[Id]
	WHEN MATCHED THEN

	UPDATE SET
		  [Name] = SOURCE.[Name]
		, [Address] = SOURCE.[ADDRESS]

	WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Id], [Name], [ADDRESS])
	VALUES ([Id], [Name], [ADDRESS])

	WHEN NOT MATCHED BY SOURCE THEN
	DELETE;

	SET IDENTITY_INSERT [dbo].[Owner] OFF
END
