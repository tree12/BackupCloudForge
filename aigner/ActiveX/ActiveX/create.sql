USE [AignerTestSQL]
GO

ALTER TABLE [dbo].[TblPicture] DROP CONSTRAINT [DF_TblPicture_Sort]
GO

/****** Object:  Table [dbo].[TblPicture]    Script Date: 04.02.2018 10:53:58 ******/
DROP TABLE [dbo].[TblPicture]
GO

/****** Object:  Table [dbo].[TblDocument]    Script Date: 04.02.2018 10:53:58 ******/
DROP TABLE [dbo].[TblDocument]
GO

/****** Object:  Table [dbo].[TblDocument]    Script Date: 04.02.2018 10:53:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblDocument](
	[Document_PK] [int] IDENTITY(1,1) NOT NULL,
	[Document_GUID] [uniqueidentifier] NOT NULL,
	[Object_FK] [varchar](50) NULL,
	[Tag_FK] [nchar](10) NOT NULL,
 CONSTRAINT [Document_PK] PRIMARY KEY CLUSTERED 
(
	[Document_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__TblDocument__DC5481BD3DFCAD42] UNIQUE NONCLUSTERED 
(
	[Document_PK] ASC,
	[Object_FK] ASC,
	[Tag_FK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[TblPicture]    Script Date: 04.02.2018 10:53:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblPicture](
	[Picture_PK] [int] IDENTITY(1,1) NOT NULL,
	[Picture_GUID] [uniqueidentifier] NOT NULL,
	[Object_FK] [varchar](50) NOT NULL,
	[Tag_FK] [nchar](10) NOT NULL,
	[Comment] [varchar](1024) NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[Picture_PK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__TblPictu__DC5481BD3DFCAD42] UNIQUE NONCLUSTERED 
(
	[Picture_GUID] ASC,
	[Object_FK] ASC,
	[Tag_FK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPicture] ADD  CONSTRAINT [DF_TblPicture_Sort]  DEFAULT ((1)) FOR [Sort]
GO




CREATE FUNCTION dbo.GetNewPathLocator (@parent hierarchyid = null) RETURNS varchar(max) AS
BEGIN       
    DECLARE @result varchar(max), @newid uniqueidentifier  -- declare new path locator, newid placeholder       
    SELECT @newid = new_id FROM dbo.getNewID; -- retrieve new GUID      
    SELECT @result = ISNULL(@parent.ToString(), '/') + -- append parent if present, otherwise assume root
                     convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 1, 6))) + '.' +
                     convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 7, 6))) + '.' +
                     convert(varchar(20), convert(bigint, substring(convert(binary(16), @newid), 13, 4))) + '/'     
    RETURN @result -- return new path locator     
END
GO
create view dbo.getNewID as select newid() as new_id 
GO


/****** Object:  StoredProcedure [dbo].[spDocumentDirectory]    Script Date: 04.02.2018 10:54:43 ******/
DROP PROCEDURE [dbo].[spDocumentDirectory]
GO

/****** Object:  StoredProcedure [dbo].[spDocumentCount]    Script Date: 04.02.2018 10:54:43 ******/
DROP PROCEDURE [dbo].[spDocumentCount]
GO

/****** Object:  StoredProcedure [dbo].[spPictureAdd]    Script Date: 04.02.2018 10:54:43 ******/
DROP PROCEDURE [dbo].[spPictureAdd]
GO

/****** Object:  StoredProcedure [dbo].[spPictureCount]    Script Date: 04.02.2018 10:54:43 ******/
DROP PROCEDURE [dbo].[spPictureCount]
GO

/****** Object:  StoredProcedure [dbo].[spPictureGet]    Script Date: 04.02.2018 10:54:43 ******/
DROP PROCEDURE [dbo].[spPictureGet]
GO

/****** Object:  StoredProcedure [dbo].[spPictureAll]    Script Date: 04.02.2018 10:54:43 ******/
DROP PROCEDURE [dbo].[spPictureAll]
GO

/****** Object:  StoredProcedure [dbo].[spPictureAll]    Script Date: 04.02.2018 10:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPictureAll]       
	@tag varchar(10),   
	@objectKey varchar(50)
AS   
BEGIN
	
		select FileTableRootPath()+file_stream.GetFileNamespacePath()  from tblPictureFiles f inner join tblPicture p on f.stream_id=p.Picture_GUID  where tag_fk=@tag and object_FK=@objectKey order by sort 
	
End 


GO

/****** Object:  StoredProcedure [dbo].[spPictureGet]    Script Date: 04.02.2018 10:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPictureGet]       
	@tag varchar(10),   
	@objectKey varchar(50),
	@nr int
AS   
BEGIN	
	select PicturePath from  (select (FileTableRootPath()+file_stream.GetFileNamespacePath()) as PicturePath, ROW_NUMBER() over (order by sort) as nr from tblPictureFiles f inner join tblPicture p on f.stream_id=p.Picture_GUID  where Object_FK=@objectKey and Tag_FK=@tag) as tmp where tmp.nr=@nr	
End 


GO

/****** Object:  StoredProcedure [dbo].[spPictureCount]    Script Date: 04.02.2018 10:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[spPictureCount]       
	@tag varchar(10),   
	@objectKey varchar(50)
AS   
BEGIN	
	--select Document_GUID from tblDocument where tag_fk=@tag and object_FK=@objectKey
	select count(*) from tblPictureFiles where stream_id in (select Picture_GUID from tblPicture where  tag_fk=@tag and object_FK=@objectKey)		
End 


GO

/****** Object:  StoredProcedure [dbo].[spPictureAdd]    Script Date: 04.02.2018 10:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPictureAdd]       
	@tag varchar(10),   
	@objectKey varchar(50),	
    @name nvarchar(255),       
	@data varbinary(max)   	
AS   
BEGIN
	begin try
	begin transaction
	declare @ID table (ID uniqueidentifier)
	insert into tblPictureFiles([name],file_stream)  OUTPUT INSERTED.[stream_id] into @ID values(@name,@data);                        
	INSERT into tblPicture(Picture_GUID,Object_FK,Tag_FK,Sort) values((select * from @ID),@objectKey,@tag,IsNull((select max(sort)+1 from TblPicture where Object_FK=@objectKey and Tag_FK=@tag),1))   
	commit
	end try
	begin catch
	rollback;
	 THROW;  
	end catch
End 

GO

/****** Object:  StoredProcedure [dbo].[spDocumentCount]    Script Date: 04.02.2018 10:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDocumentCount]       
	@tag varchar(10),   
	@objectKey varchar(50)
AS   
BEGIN	
	--select Document_GUID from tblDocument where tag_fk=@tag and object_FK=@objectKey
	select count(*) from tblDocumentFiles where parent_path_locator=(select path_locator from tblDocumentFiles where stream_id=(select Document_GUID from tblDocument where tag_fk=@tag and object_FK=@objectKey))		
End 


GO

/****** Object:  StoredProcedure [dbo].[spDocumentDirectory]    Script Date: 04.02.2018 10:54:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDocumentDirectory]       
	@tag varchar(10),   
	@objectKey varchar(50),
	@name nvarchar(255)      
AS   
BEGIN
	begin try
	begin transaction
	if (not exists (select * from tblDocument where tag_fk=@tag and object_FK=@objectKey))
    Begin		
		
		if (not exists (select * from tblDocument where tag_fk=@tag and object_FK is null))		
			begin
				declare @parent_id table (ID uniqueidentifier)
				insert into tblDocumentFiles(is_directory,[name],is_readonly,is_system)  OUTPUT INSERTED.[stream_id] into @parent_id values(1,@tag,1,1);                        
				--select * from @parent_id
				INSERT into tblDocument (Document_GUID,Object_FK,Tag_FK) values((select * from @parent_id),null,@tag)
			end
			declare @parent table (ID uniqueidentifier)
		--select Document_GUID from tblDocument where tag_fk=@tag and object_FK is null
		insert into @parent select stream_id from tblDocumentFiles  where parent_path_locator is null and stream_id=(select Document_GUID from tblDocument where tag_fk=@tag and object_FK is null)

		--select * from @parent
		
		declare @ID table (ID uniqueidentifier)
	
		--select * from @parent;
		--Verzeichniss einfügen
		begin try
			insert into tblDocumentFiles(is_directory,is_system,[name],path_locator)  OUTPUT INSERTED.[stream_id] into @ID values(1,1,@name,dbo.GetNewPathLocator((select path_locator from tblDocumentFiles where stream_id=(select * from @PARENT))));                            
		end try
		begin catch			
			--fallback einfügen mit zufallszahl + name
			insert into tblDocumentFiles(is_directory,is_system,[name],path_locator)  OUTPUT INSERTED.[stream_id] into @ID values(1,1,(@name+'('+cast(cast(RAND()*100 as int)as varchar)+')'),dbo.GetNewPathLocator((select path_locator from tblDocumentFiles where stream_id=(select * from @PARENT))));                            
		end catch
		--select * from @ID;
		INSERT into tblDocument (Document_GUID,Object_FK,Tag_FK) values((select * from @ID),@objectKey,@tag)
    End
	--select Document_GUID from tblDocument where tag_fk=@tag and object_FK=@objectKey	
		commit
		select FileTableRootPath()+file_stream.GetFileNamespacePath()  from tblDocumentFiles where stream_id = (select Document_GUID from tblDocument where tag_fk=@tag and object_FK=@objectKey)	
		RETURN
	end try
	begin catch
		rollback;
		THROW;
	end catch
	
End 


GO

USE [AignerTestSQL]
GO

/****** Object:  UserDefinedFunction [dbo].[fnPictureGet]    Script Date: 04.02.2018 10:55:22 ******/
DROP FUNCTION [dbo].[fnPictureGet]
GO

/****** Object:  UserDefinedFunction [dbo].[fnPictureGet]    Script Date: 04.02.2018 10:55:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create FUNCTION [dbo].[fnPictureGet] (      
	@tag varchar(10),   
	@objectKey varchar(50),
	@nr int) returns varchar(max)
AS   
BEGIN	
	Declare @p varchar(max)
	select @p=PicturePath from  (select (FileTableRootPath()+file_stream.GetFileNamespacePath()) as PicturePath, 
	ROW_NUMBER() over (order by sort) as nr from tblPictureFiles f inner join tblPicture p on f.stream_id=p.Picture_GUID  
	where Object_FK=@objectKey and Tag_FK=@tag) as tmp where tmp.nr=@nr	
	return @p
END
GO


CREATE PROCEDURE [dbo].[spPictureDelete]       
	@picture_pk int   	
AS   
BEGIN	
	delete from tblPictureFiles where stream_id = (select Picture_GUID from TblPicture where Picture_PK=@picture_pk)
	delete from tblPicture where Picture_PK=@picture_pk
End 


GO


CREATE PROCEDURE [dbo].[spPictureMoveTo]       
	@pictureSrc_pk int,
	@pictureDest_pk int   	
AS   
BEGIN	
	declare @objecttag varchar(50)
	declare @objectKey varchar(50)
	declare @objectsort int

	select @objectkey=Object_FK,@objecttag=Tag_FK,@objectsort=sort from TblPicture where Picture_PK=@picturedest_pk

	update TblPicture set Sort=Sort+1 where Sort>=@objectsort;
	update tblpicture set sort=@objectsort where Picture_PK=@picturesrc_pk
End 

