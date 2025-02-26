Use [MemeVault]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Insert a new Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Insert >>>'

    End

GO

Create PROCEDURE Admin_Insert

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
Go
-- =========================================================
-- Procure Name: Admin_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Update an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Update >>>'

    End

GO

Create PROCEDURE Admin_Update

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
Go
-- =========================================================
-- Procure Name: Admin_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Find an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Find >>>'

    End

GO

Create PROCEDURE Admin_Find

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
Go
-- =========================================================
-- Procure Name: Admin_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Delete an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Delete >>>'

    End

GO

Create PROCEDURE Admin_Delete

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
Go
-- =========================================================
-- Procure Name: Admin_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Returns all Admin objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_FetchAll >>>'

    End

GO

Create PROCEDURE Admin_FetchAll

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
Go
-- =========================================================
-- Procure Name: Alternate_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Insert a new Alternate
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Alternate_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Alternate_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Alternate_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Alternate_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Alternate_Insert >>>'

    End

GO

Create PROCEDURE Alternate_Insert

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
Go
-- =========================================================
-- Procure Name: Alternate_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Update an existing Alternate
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Alternate_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Alternate_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Alternate_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Alternate_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Alternate_Update >>>'

    End

GO

Create PROCEDURE Alternate_Update

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
Go
-- =========================================================
-- Procure Name: Alternate_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Find an existing Alternate
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Alternate_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Alternate_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Alternate_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Alternate_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Alternate_Find >>>'

    End

GO

Create PROCEDURE Alternate_Find

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
Go
-- =========================================================
-- Procure Name: Alternate_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Delete an existing Alternate
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Alternate_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Alternate_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Alternate_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Alternate_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Alternate_Delete >>>'

    End

GO

Create PROCEDURE Alternate_Delete

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
Go
-- =========================================================
-- Procure Name: Alternate_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Returns all Alternate objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Alternate_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Alternate_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Alternate_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Alternate_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Alternate_FetchAll >>>'

    End

GO

Create PROCEDURE Alternate_FetchAll

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
Go
-- =========================================================
-- Procure Name: Image_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Insert a new Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Insert >>>'

    End

GO

Create PROCEDURE Image_Insert

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
Go
-- =========================================================
-- Procure Name: Image_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Update an existing Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Update >>>'

    End

GO

Create PROCEDURE Image_Update

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
Go
-- =========================================================
-- Procure Name: Image_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Find an existing Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Find >>>'

    End

GO

Create PROCEDURE Image_Find

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
Go
-- =========================================================
-- Procure Name: Image_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Delete an existing Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Delete >>>'

    End

GO

Create PROCEDURE Image_Delete

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
Go
-- =========================================================
-- Procure Name: Image_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Returns all Image objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_FetchAll >>>'

    End

GO

Create PROCEDURE Image_FetchAll

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
Go
-- =========================================================
-- Procure Name: ImageView_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Returns all ImageView objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ImageView_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ImageView_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ImageView_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ImageView_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ImageView_FetchAll >>>'

    End

GO

Create PROCEDURE ImageView_FetchAll

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
Go
-- =========================================================
-- Procure Name: Image_FindByName
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Find an existing Image for the Name given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_FindByName'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_FindByName

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_FindByName') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_FindByName >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_FindByName >>>'

    End

GO

Create PROCEDURE Image_FindByName

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
Go
-- =========================================================
-- Procure Name: Alternate_FetchAllForImageId
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Returns all Alternate objects for the ImageId given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Alternate_FetchAllForImageId'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Alternate_FetchAllForImageId

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Alternate_FetchAllForImageId') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Alternate_FetchAllForImageId >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Alternate_FetchAllForImageId >>>'

    End

GO

Create PROCEDURE Alternate_FetchAllForImageId

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

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: ImageView_Search
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   2/24/2025
-- Description:    Returns all ImageView objects for the Name given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('ImageView_Search'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure ImageView_Search

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.ImageView_Search') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure ImageView_Search >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure ImageView_Search >>>'

    End

GO

Create PROCEDURE ImageView_Search

    -- Create @Name Paramater
    @Name nvarchar(50)


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AlternateId],[AlternateName],[ImageId],[Indexed],[Name],[Path]

    -- From tableName
    From [ImageView]

    -- Load Matching Records
    Where [Name] = @Name

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

