Use [MemeVault]

/****** Object:  Table [dbo].[Alternate]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alternate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Alternate] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Path] [nvarchar](255) NOT NULL,
	[Indexed] [bit] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Image_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Image_Path] UNIQUE NONCLUSTERED 
(
	[Path] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ImageView]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ImageView]
AS
SELECT    dbo.Image.Id AS ImageId, dbo.Image.Name, dbo.Image.Path, dbo.Image.Indexed, dbo.Alternate.Id AS AlternateId, dbo.Alternate.Name AS AlternateName
FROM      dbo.Image INNER JOIN
              dbo.Alternate ON dbo.Image.Id = dbo.Alternate.ImageId
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemeFolder] [nvarchar](255) NOT NULL,
	[IndexOnSave] [bit] NULL,
	[SuppressDeletePrompt] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alternate]  WITH CHECK ADD  CONSTRAINT [FK_Alternate_Image] FOREIGN KEY([ImageId])
REFERENCES [dbo].[Image] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Alternate] CHECK CONSTRAINT [FK_Alternate_Image]
GO
/****** Object:  StoredProcedure [dbo].[Admin_Delete]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Admin]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_FetchAll]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[IndexOnSave],[MemeFolder],[SuppressDeletePrompt]

    -- From tableName
    From [Admin]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Find]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[IndexOnSave],[MemeFolder],[SuppressDeletePrompt]

    -- From tableName
    From [Admin]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Insert]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Insert]

    -- Add the parameters for the stored procedure here
    @IndexOnSave bit,
    @MemeFolder nvarchar(255),
    @SuppressDeletePrompt bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Admin]
    ([IndexOnSave],[MemeFolder],[SuppressDeletePrompt])

    -- Begin Values List
    Values(@IndexOnSave, @MemeFolder, @SuppressDeletePrompt)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Update]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Update]

    -- Add the parameters for the stored procedure here
    @Id int,
    @IndexOnSave bit,
    @MemeFolder nvarchar(255),
    @SuppressDeletePrompt bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Admin]

    -- Update Each field
    Set [IndexOnSave] = @IndexOnSave,
    [MemeFolder] = @MemeFolder,
    [SuppressDeletePrompt] = @SuppressDeletePrompt

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Alternate_Delete]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Alternate_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Alternate]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Alternate_FetchAll]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Alternate_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[ImageId],[Name]

    -- From tableName
    From [Alternate]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Alternate_FetchAllForImageId]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Alternate_FetchAllForImageId]

    -- Create @ImageId Paramater
    @ImageId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[ImageId],[Name]

    -- From tableName
    From [Alternate]

    -- Load Matching Records
    Where [ImageId] = @ImageId

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[Alternate_Find]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Alternate_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[ImageId],[Name]

    -- From tableName
    From [Alternate]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Alternate_Insert]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Alternate_Insert]

    -- Add the parameters for the stored procedure here
    @ImageId int,
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Alternate]
    ([ImageId],[Name])

    -- Begin Values List
    Values(@ImageId, @Name)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Alternate_Update]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Alternate_Update]

    -- Add the parameters for the stored procedure here
    @Id int,
    @ImageId int,
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Alternate]

    -- Update Each field
    Set [ImageId] = @ImageId,
    [Name] = @Name

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_Delete]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Image]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_FetchAll]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Indexed],[Name],[Path]

    -- From tableName
    From [Image]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_FetchAllForSearch]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Image_FetchAllForSearch]

    -- Create @Name Paramater
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Indexed],[Name],[Path]

    -- From tableName
    From [Image]

    -- Load Matching Records
    Where [Name] = @Name

END
GO
/****** Object:  StoredProcedure [dbo].[Image_Find]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Indexed],[Name],[Path]

    -- From tableName
    From [Image]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_FindByName]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_FindByName]

    -- Create @Name Paramater
    @Name nvarchar(50)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[Indexed],[Name],[Path]

    -- From tableName
    From [Image]

    -- Find Matching Record
    Where [Name] = @Name

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_Insert]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Insert]

    -- Add the parameters for the stored procedure here
    @Indexed bit,
    @Name nvarchar(50),
    @Path nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Image]
    ([Indexed],[Name],[Path])

    -- Begin Values List
    Values(@Indexed, @Name, @Path)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_Update]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Update]

    -- Add the parameters for the stored procedure here
    @Id int,
    @Indexed bit,
    @Name nvarchar(50),
    @Path nvarchar(255)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Image]

    -- Update Each field
    Set [Indexed] = @Indexed,
    [Name] = @Name,
    [Path] = @Path

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageView_FetchAll]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AlternateId],[AlternateName],[ImageId],[Indexed],[Name],[Path]

    -- From tableName
    From [ImageView]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageView_FetchAllForSearch]    Script Date: 2/26/2025 7:15:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ImageView_FetchAllForSearch]
    @SearchText NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SearchWords TABLE (Word NVARCHAR(50));

    -- Split the @SearchText into individual words
    INSERT INTO @SearchWords (Word)
    SELECT DISTINCT value FROM STRING_SPLIT(@SearchText, ' ');

    WITH ScoredResults AS (
        SELECT
            iv.[AlternateId],
            iv.[AlternateName],
            iv.[ImageId],
            iv.[Indexed],
            iv.[Name],
            iv.[Path],
            Score = SUM(
                CASE 
                    WHEN iv.[Name] = sw.Word THEN 30.0 / LEN(iv.[Name])
                    WHEN iv.[Name] LIKE '%' + sw.Word + '%' THEN 10.0 / LEN(iv.[Name])
                    WHEN iv.[AlternateName] = sw.Word THEN 20.0 / LEN(iv.[AlternateName])
                    WHEN iv.[AlternateName] LIKE '%' + sw.Word + '%' THEN 4.0 / LEN(iv.[AlternateName])
                    ELSE 0
                END
            )
        FROM
            [ImageView] iv
            CROSS JOIN @SearchWords sw
        GROUP BY
            iv.[AlternateId],
            iv.[AlternateName],
            iv.[ImageId],
            iv.[Indexed],
            iv.[Name],
            iv.[Path]
    ),
    RankedResults AS (
        SELECT
            *,
            ROW_NUMBER() OVER (PARTITION BY [ImageId] ORDER BY [Score] DESC) AS RowNum
        FROM
            ScoredResults
        WHERE
            Score > 0
    )
    SELECT TOP 10
        [AlternateId],
        [AlternateName],
        [ImageId],
        [Indexed],
        [Name],
        [Path]
    FROM
        RankedResults
    WHERE
        RowNum = 1
    ORDER BY
        Score DESC;
END
GO
