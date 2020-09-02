CREATE PROCEDURE [dbo].[ReferenceData_ExecuteAll]
AS
BEGIN
	EXEC [dbo].[ReferenceData_Type];
	EXEC [dbo].[ReferenceData_Owner];
	EXEC [dbo].[ReferenceData_Account];
END	