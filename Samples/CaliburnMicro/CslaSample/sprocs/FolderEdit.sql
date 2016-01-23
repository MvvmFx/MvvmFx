/****** Object:  StoredProcedure [AddFolderEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AddFolderEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [AddFolderEdit]
GO

CREATE PROCEDURE [AddFolderEdit]
    @FolderId int OUTPUT,
    @FolderName varchar(MAX),
    @CreateDate datetime2,
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into Folders */
        INSERT INTO [Folders]
        (
            [FolderName],
            [CreateDate],
            [ChangeDate]
        )
        VALUES
        (
            @FolderName,
            @CreateDate,
            @ChangeDate
        )

        /* Return new primary key */
        SET @FolderId = SCOPE_IDENTITY()

    END
GO

/****** Object:  StoredProcedure [UpdateFolderEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[UpdateFolderEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [UpdateFolderEdit]
GO

CREATE PROCEDURE [UpdateFolderEdit]
    @FolderId int,
    @FolderName varchar(MAX),
    @ChangeDate datetime2
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [FolderId] FROM [Folders]
            WHERE
                [FolderId] = @FolderId
        )
        BEGIN
            RAISERROR ('''FolderEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in Folders */
        UPDATE [Folders]
        SET
            [FolderName] = @FolderName,
            [ChangeDate] = @ChangeDate
        WHERE
            [FolderId] = @FolderId

    END
GO

/****** Object:  StoredProcedure [DeleteFolderEdit] ******/
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DeleteFolderEdit]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [DeleteFolderEdit]
GO

CREATE PROCEDURE [DeleteFolderEdit]
    @FolderId int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [FolderId] FROM [Folders]
            WHERE
                [FolderId] = @FolderId
        )
        BEGIN
            RAISERROR ('''FolderEdit'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete FolderEdit object from Folders */
        DELETE
        FROM [Folders]
        WHERE
            [Folders].[FolderId] = @FolderId

    END
GO
