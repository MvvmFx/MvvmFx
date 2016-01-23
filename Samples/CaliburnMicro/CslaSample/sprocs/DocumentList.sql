/****** Object:  StoredProcedure [GetDocumentList] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocumentList]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocumentList]
GO

CREATE PROCEDURE [GetDocumentList]
    @FolderId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocumentInfo from table */
        SELECT
            [Documents].[DocumentId],
            [Documents].[DocumentReference],
            [Documents].[DocumentDate],
            [Documents].[Subject],
            [Documents].[Sender],
            [Documents].[Receiver]
        FROM [Documents]
        WHERE
            [Documents].[FolderId] = @FolderId

    END
GO

