/****** Object:  StoredProcedure [GetFolderEditCollection] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderEditCollection]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderEditCollection]
GO

/*
CREATE PROCEDURE [GetFolderEditCollection]
AS
    BEGIN

        SET NOCOUNT ON

        --/* Get FolderEdit from table */
        SELECT
            [Folders].[FolderId],
            [Folders].[FolderName],
            [Folders].[CreateDate],
            [Folders].[ChangeDate]
        FROM [Folders]

    END
*/
GO


