/****** Object:  StoredProcedure [GetFolderNVL] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderNVL]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderNVL]
GO

CREATE PROCEDURE [GetFolderNVL]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get FolderNVL from table */
        SELECT
            [Folders].[FolderId],
            [Folders].[FolderName]
        FROM [Folders]

    END
GO

