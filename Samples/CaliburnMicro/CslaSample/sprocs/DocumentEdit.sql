/****** Object:  StoredProcedure [GetDocumentEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[GetDocumentEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [GetDocumentEdit]
GO

CREATE PROCEDURE [GetDocumentEdit]
    @DocumentId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get DocumentEdit from table */
        SELECT
            [Documents].[DocumentId],
            [Documents].[DocumentReference],
            [Documents].[DocumentDate],
            [Documents].[Subject],
            [Documents].[Sender],
            [Documents].[Receiver],
            [Documents].[TextContent],
            [Documents].[CreateDate],
            [Documents].[ChangeDate],
            [Documents].[FolderId]
        FROM [Documents]
        WHERE
            [Documents].[DocumentId] = @DocumentId

    END
GO

/****** Object:  StoredProcedure [AddDocumentEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddDocumentEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddDocumentEdit]
GO

CREATE PROCEDURE [AddDocumentEdit]
    @DocumentId int OUTPUT,
    @DocumentReference varchar(15),
    @DocumentDate date,
    @Subject varchar(MAX),
    @Sender varchar(50),
    @Receiver varchar(50),
    @TextContent varchar(MAX),
    @CreateDate datetime2,
    @ChangeDate datetime2,
    @FolderId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Documents */
        INSERT INTO [Documents]
        (
            [DocumentReference],
            [DocumentDate],
            [Subject],
            [Sender],
            [Receiver],
            [TextContent],
            [CreateDate],
            [ChangeDate],
            [FolderId]
        )
        VALUES
        (
            @DocumentReference,
            @DocumentDate,
            @Subject,
            @Sender,
            @Receiver,
            @TextContent,
            @CreateDate,
            @ChangeDate,
            @FolderId
        )

        /* Return new primary key */
        SET @DocumentId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateDocumentEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateDocumentEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateDocumentEdit]
GO

CREATE PROCEDURE [UpdateDocumentEdit]
    @DocumentId int,
    @DocumentReference varchar(15),
    @DocumentDate date,
    @Subject varchar(MAX),
    @Sender varchar(50),
    @Receiver varchar(50),
    @TextContent varchar(MAX),
    @ChangeDate datetime2,
    @FolderId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocumentId] FROM [Documents]
            WHERE
                [DocumentId] = @DocumentId
        )
        BEGIN
            RAISERROR ('''DocumentEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Documents */
        UPDATE [Documents]
        SET
            [DocumentReference] = @DocumentReference,
            [DocumentDate] = @DocumentDate,
            [Subject] = @Subject,
            [Sender] = @Sender,
            [Receiver] = @Receiver,
            [TextContent] = @TextContent,
            [ChangeDate] = @ChangeDate,
            [FolderId] = @FolderId
        WHERE
            [DocumentId] = @DocumentId

    END
GO

/****** Object:  StoredProcedure [DeleteDocumentEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteDocumentEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteDocumentEdit]
GO

CREATE PROCEDURE [DeleteDocumentEdit]
    @DocumentId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [DocumentId] FROM [Documents]
            WHERE
                [DocumentId] = @DocumentId
        )
        BEGIN
            RAISERROR ('''DocumentEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete DocumentEdit object from Documents */
        DELETE
        FROM [Documents]
        WHERE
            [Documents].[DocumentId] = @DocumentId

    END
GO
