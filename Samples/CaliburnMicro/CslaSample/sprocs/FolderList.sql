/****** Object:  StoredProcedure [GetFolderList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetFolderList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetFolderList]
GO

CREATE PROCEDURE [GetFolderList]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get FolderInfo from table */
        SELECT
            [Folders].[FolderId],
            [Folders].[FolderName]
        FROM [Folders]

    END
GO

