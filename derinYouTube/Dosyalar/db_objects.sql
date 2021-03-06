USE [YoutubeCommentDb]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_getUserAnswersCountByCompetitions]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[fn_getUserAnswersCountByCompetitions] (@competitionId int, @userChannelId varchar(1000))
RETURNS INT
AS
BEGIN
	-- Declare the return variable here
	DECLARE @result INT
	SELECT @result = COUNT(*)
	FROM competitions
	INNER JOIN liveChatMessages ON competitions.VideoId = liveChatMessages.VideoId
	WHERE competitions.Id=@competitionId
		AND PublishedAt BETWEEN competitions.StartTime AND competitions.EndTime
		AND AuthorChannelId = @userChannelId
	GROUP BY competitions.Id ,AuthorChannelId	

	RETURN @result
END
GO
/****** Object:  Table [dbo].[competitionAnswers]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competitionAnswers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fk_Competition] [int] NOT NULL,
	[Fk_LiveChatMessage] [int] NOT NULL,
	[Score] [int] NOT NULL,
	[IsValid] [bit] NOT NULL,
 CONSTRAINT [PK_competitionAnswers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[competitions]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[competitions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[LiveChatId] [varchar](800) NOT NULL,
	[VideoId] [varchar](800) NOT NULL,
	[Question] [varchar](1000) NOT NULL,
	[Answer] [varchar](1000) NOT NULL,
	[StartTime] [datetime] NOT NULL,
	[EndTime] [datetime] NULL,
 CONSTRAINT [PK_competitions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liveBroadcasts]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liveBroadcasts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BroadcastId] [varchar](800) NOT NULL,
	[Title] [varchar](max) NOT NULL,
	[ChannelId] [varchar](1000) NOT NULL,
	[LiveChatId] [varchar](800) NOT NULL,
	[Description] [varchar](max) NOT NULL,
	[LiveStatus] [varchar](100) NOT NULL,
	[ChannelTitle] [varchar](max) NOT NULL,
	[PublishedDate] [datetime] NULL,
	[ActualStartTime] [datetime] NULL,
	[ActualEndTime] [datetime] NULL,
	[ScheduledStartTime] [datetime] NULL,
 CONSTRAINT [PK_liveBroadcasts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liveBroadcastsViewCount]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liveBroadcastsViewCount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[VideoId] [varchar](800) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Count] [bigint] NOT NULL,
 CONSTRAINT [PK_liveBroadcastsViewCount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[liveChatMessages]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[liveChatMessages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [varchar](max) NOT NULL,
	[AuthorChannelId] [varchar](1000) NOT NULL,
	[AuthorChannelUrl] [varchar](1000) NOT NULL,
	[AuthorDisplayName] [varchar](1000) NOT NULL,
	[LiveChatId] [varchar](800) NOT NULL,
	[VideoId] [varchar](800) NOT NULL,
	[PublishedAt] [datetime] NULL,
	[HasDisplayContent] [bit] NULL,
	[MessageText] [varchar](max) NOT NULL,
	[IsVerified] [bit] NULL,
	[IsChatOwner] [bit] NULL,
	[IsChatSponsor] [bit] NULL,
	[IsChatModerator] [bit] NULL,
	[IsMessageNumeric] [bit] NOT NULL,
	[NumericMessage] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_liveChatMessages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[questions]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Question] [varchar](800) NOT NULL,
	[Answer] [varchar](800) NOT NULL,
	[InsertDate] [smalldatetime] NOT NULL,
	[QuestionDate] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[settings]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[settings](
	[Id] [int] NOT NULL,
	[Value] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_settings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[validAnswers_vw]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[validAnswers_vw]
AS
SELECT competitions.Id AS CompetitionId 
		,AuthorChannelId
		,AuthorChannelUrl
		,AuthorDisplayName
		,Score
		,PublishedAt
		,StartTime
		,EndTime
		,competitions.LiveChatId
		,competitions.VideoId
		,Question
		,Answer
		,NumericMessage as MessageText
		,ABS(CAST(Answer AS decimal(36,0))-CAST(NumericMessage as decimal(36,0))) AS Gap
		,ROW_NUMBER() OVER (PARTITION BY competitions.Id ORDER BY Score DESC) As Sequence
		--,ISNULL(dbo.fn_getUserAnswersCountByCompetitions(competitions.Id,liveChatMessages.AuthorChannelId),0) UserAnswerCount
		,1 AS UserAnswerCount
FROM competitionAnswers
INNER JOIN competitions ON competitions.Id = competitionAnswers.Fk_Competition
INNER JOIN liveChatMessages ON liveChatMessages.Id = competitionAnswers.Fk_LiveChatMessage
GO
/****** Object:  UserDefinedFunction [dbo].[fn_winnerOfDay]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fn_winnerOfDay]
(
    @tarih smalldatetime
)
RETURNS TABLE AS RETURN
(
	SELECT TOP 50 CAST(PublishedAt AS DATE) Day
		,AuthorChannelId
		,AuthorChannelUrl
		,AuthorDisplayName
		,SUM(Score) TotalScore
		,COUNT(DISTINCT(CompetitionId)) TotalCompetition
		,ROW_NUMBER() OVER (PARTITION BY CAST(PublishedAt AS DATE) ORDER BY SUM(Score) DESC) Sequence
	FROM ValidAnswers_vw
	WHERE CAST(PublishedAt AS DATE)=CAST(@tarih as DATE)
	GROUP BY CAST(PublishedAt AS DATE),AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
	ORDER BY TotalScore DESC
)



GO
/****** Object:  View [dbo].[winnerOfDay_vw]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[winnerOfDay_vw] 
AS 
SELECT TOP 10000000 CAST(PublishedAt AS DATE) Day
	,AuthorChannelId
	,AuthorChannelUrl
	,AuthorDisplayName
	,SUM(Score) TotalScore
	,COUNT(DISTINCT(CompetitionId)) TotalCompetition
	,ROW_NUMBER() OVER (PARTITION BY CAST(PublishedAt AS DATE) ORDER BY SUM(Score) DESC) Sequence
FROM ValidAnswers_vw
GROUP BY CAST(PublishedAt AS DATE),AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
ORDER BY TotalScore DESC

GO
/****** Object:  UserDefinedFunction [dbo].[fn_competitions]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_competitions](@date smalldatetime)
RETURNS TABLE AS RETURN
(
SELECT competitions.Id
	  ,CAST(competitions.Date AS DATE) AS Date
	  ,competitions.VideoId
	  ,competitions.Question
	  ,competitions.Answer
	  ,competitions.StartTime
	  ,ISNULL(competitions.EndTime,GETDATE()) AS EndTime
	  ,ISNULL(valid.ValidAnswers,0) As ValidAnswers
	  ,COUNT(liveChatMessages.Id) As TotalAnswers
	  ,COUNT(DISTINCT liveChatMessages.AuthorChannelId) As UserCount
FROM competitions
LEFT JOIN 
	(SELECT Fk_Competition,COUNT(*) ValidAnswers 
	 FROM competitionAnswers 
	 GROUP BY Fk_Competition) valid ON valid.Fk_Competition = competitions.Id
LEFT JOIN liveChatMessages ON liveChatMessages.VideoId = competitions.VideoId
							AND liveChatMessages.PublishedAt BETWEEN competitions.StartTime AND competitions.EndTime	
WHERE CAST(competitions.Date AS DATE)=CAST(@date AS DATE)
GROUP BY competitions.Id
	  ,CAST(competitions.Date AS DATE)
	  ,competitions.VideoId
	  ,competitions.Question
	  ,competitions.Answer
	  ,competitions.StartTime
	  ,competitions.EndTime
	  ,valid.ValidAnswers
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_getValidAnswers]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_getValidAnswers] ( @competitionId int)
RETURNS TABLE AS RETURN
(
	SELECT AuthorChannelId
		  ,AuthorChannelUrl
		  ,AuthorDisplayName
		  ,Score
		  ,PublishedAt
		  ,StartTime
		  ,EndTime
		  ,competitions.LiveChatId
		  ,competitions.VideoId
		  ,Question
		  ,Answer
		  ,MessageText
		  ,ABS(CAST(Answer AS DECIMAL(20))-CAST(MessageText AS DECIMAL(20))) AS Gap
		  ,ROW_NUMBER() OVER (ORDER BY Score DESC) As Sira
	FROM competitionAnswers
	INNER JOIN competitions ON competitions.Id = competitionAnswers.Fk_Competition
	INNER JOIN liveChatMessages ON liveChatMessages.Id = competitionAnswers.Fk_LiveChatMessage
	WHERE Fk_Competition = @competitionId
)
GO
/****** Object:  UserDefinedFunction [dbo].[fn_validAnswers]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_validAnswers]
(
    @Id int
)
RETURNS TABLE AS RETURN
(
SELECT TOP 100 competitions.Id AS CompetitionId 
		,AuthorChannelId
		,AuthorChannelUrl
		,AuthorDisplayName as DisplayName
		,Score
		,PublishedAt
		,StartTime
		,EndTime
		,competitions.LiveChatId
		,competitions.VideoId
		,Question
		,Answer
		,NumericMessage as MessageText
		,ABS(CAST(Answer AS decimal(36,0))-CAST(NumericMessage as decimal(36,0))) AS Gap
		,ROW_NUMBER() OVER (PARTITION BY competitions.Id ORDER BY Score DESC) As Sequence
		--,ISNULL(dbo.fn_getUserAnswersCountByCompetitions(competitions.Id,liveChatMessages.AuthorChannelId),0) UserAnswerCount
		,1 AS UserAnswerCount
FROM competitionAnswers
INNER JOIN competitions ON competitions.Id = competitionAnswers.Fk_Competition
INNER JOIN liveChatMessages ON liveChatMessages.Id = competitionAnswers.Fk_LiveChatMessage
WHERE competitions.Id=@Id  AND Score>0
)
GO
/****** Object:  View [dbo].[chatCountByTime_vw]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[chatCountByTime_vw]
AS
SELECT VideoId
	  ,CONVERT(VARCHAR(5), PublishedAt, 108) AS Time
	  ,COUNT(*) AS ChatCount
FROM liveChatMessages
--WHERE VideoId = 'skZl8MJug8s'
GROUP BY VideoId, CONVERT(VARCHAR(5), PublishedAt, 108)
GO
/****** Object:  View [dbo].[competitions_vw]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--.Where(x => DbFunctions.TruncateTime(x.Date) == DbFunctions.TruncateTime(dtReport.Value)).Select(x =>
--                       new CompetitionModel
--                       {
--                           Id = x.Id,
--                           VideoId = x.VideoId,
--                           Question = x.Question,
--                           Answer = x.Answer,
--                           StartTime = x.StartTime,
--                           EndTime = x.EndTime.Value
--                       }).ToSortableGridList();



CREATE VIEW [dbo].[competitions_vw]
AS
SELECT competitions.Id
	  ,CAST(competitions.Date AS DATE) AS Date
	  ,competitions.VideoId
	  ,competitions.Question
	  ,competitions.Answer
	  ,competitions.StartTime
	  ,competitions.EndTime
	  ,ISNULL(valid.ValidAnswers,0) As ValidAnswers
	  ,COUNT(liveChatMessages.Id) As TotalAnswers
	  ,COUNT(DISTINCT liveChatMessages.AuthorChannelId) As TotalUser
FROM competitions
LEFT JOIN 
	(SELECT Fk_Competition,COUNT(*) ValidAnswers 
	 FROM competitionAnswers 
	 GROUP BY Fk_Competition) valid ON valid.Fk_Competition = competitions.Id
LEFT JOIN liveChatMessages ON liveChatMessages.VideoId = competitions.VideoId
							AND liveChatMessages.PublishedAt BETWEEN competitions.StartTime AND competitions.EndTime	
GROUP BY competitions.Id
	  ,CAST(competitions.Date AS DATE)
	  ,competitions.VideoId
	  ,competitions.Question
	  ,competitions.Answer
	  ,competitions.StartTime
	  ,competitions.EndTime
	  ,valid.ValidAnswers
GO
/****** Object:  View [dbo].[viewerCountByTime_vw]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewerCountByTime_vw]
AS
SELECT VideoId
	  ,CONVERT(VARCHAR(5), Date, 108) Time
	  ,Count ViewerCount
FROM liveBroadcastsViewCount
GO
ALTER TABLE [dbo].[competitionAnswers] ADD  DEFAULT ((0)) FOR [Score]
GO
ALTER TABLE [dbo].[competitionAnswers] ADD  CONSTRAINT [DF_competitionAnswers_IsValid]  DEFAULT ((0)) FOR [IsValid]
GO
ALTER TABLE [dbo].[competitions] ADD  CONSTRAINT [DF_competitions_VideoId]  DEFAULT ('') FOR [VideoId]
GO
ALTER TABLE [dbo].[liveBroadcasts] ADD  CONSTRAINT [DF__liveBroad__Title__108B795B]  DEFAULT ('') FOR [Title]
GO
ALTER TABLE [dbo].[liveBroadcasts] ADD  CONSTRAINT [DF__liveBroad__Chann__117F9D94]  DEFAULT ('') FOR [ChannelId]
GO
ALTER TABLE [dbo].[liveBroadcasts] ADD  CONSTRAINT [DF__liveBroad__LiveC__1273C1CD]  DEFAULT ('') FOR [LiveChatId]
GO
ALTER TABLE [dbo].[liveBroadcasts] ADD  CONSTRAINT [DF__liveBroad__Descr__1367E606]  DEFAULT ('') FOR [Description]
GO
ALTER TABLE [dbo].[liveBroadcasts] ADD  CONSTRAINT [DF__liveBroad__LiveS__145C0A3F]  DEFAULT ('') FOR [LiveStatus]
GO
ALTER TABLE [dbo].[liveBroadcasts] ADD  CONSTRAINT [DF__liveBroad__Chann__15502E78]  DEFAULT ('') FOR [ChannelTitle]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  CONSTRAINT [DF_liveChatMessages_VideoId]  DEFAULT ('') FOR [VideoId]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  CONSTRAINT [DF__liveChatM__HasDi__286302EC]  DEFAULT ((0)) FOR [HasDisplayContent]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  CONSTRAINT [DF__liveChatM__IsVer__29572725]  DEFAULT ((0)) FOR [IsVerified]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  CONSTRAINT [DF__liveChatM__IsCha__2A4B4B5E]  DEFAULT ((0)) FOR [IsChatOwner]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  CONSTRAINT [DF__liveChatM__IsCha__2B3F6F97]  DEFAULT ((0)) FOR [IsChatSponsor]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  CONSTRAINT [DF__liveChatM__IsCha__2C3393D0]  DEFAULT ((0)) FOR [IsChatModerator]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  DEFAULT ((0)) FOR [IsMessageNumeric]
GO
ALTER TABLE [dbo].[liveChatMessages] ADD  DEFAULT ('0') FOR [NumericMessage]
GO
ALTER TABLE [dbo].[questions] ADD  CONSTRAINT [DF_questions_Code]  DEFAULT ('') FOR [Code]
GO
ALTER TABLE [dbo].[questions] ADD  CONSTRAINT [DF_questions_InsertDate]  DEFAULT (getdate()) FOR [InsertDate]
GO
ALTER TABLE [dbo].[questions] ADD  DEFAULT (getdate()) FOR [QuestionDate]
GO
ALTER TABLE [dbo].[settings] ADD  CONSTRAINT [DF__settings__Value__41B8C09B]  DEFAULT ('') FOR [Value]
GO
ALTER TABLE [dbo].[competitionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_competitionAnswers_competitions] FOREIGN KEY([Fk_Competition])
REFERENCES [dbo].[competitions] ([Id])
GO
ALTER TABLE [dbo].[competitionAnswers] CHECK CONSTRAINT [FK_competitionAnswers_competitions]
GO
ALTER TABLE [dbo].[competitionAnswers]  WITH CHECK ADD  CONSTRAINT [FK_competitionAnswers_liveChatMessages] FOREIGN KEY([Fk_LiveChatMessage])
REFERENCES [dbo].[liveChatMessages] ([Id])
GO
ALTER TABLE [dbo].[competitionAnswers] CHECK CONSTRAINT [FK_competitionAnswers_liveChatMessages]
GO
/****** Object:  StoredProcedure [dbo].[clearMultipleChatMessages]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[clearMultipleChatMessages] @videoId varchar(1000)
AS

WITH tbl AS (
SELECT ROW_NUMBER() OVER (PARTITION BY MessageId ORDER BY MessageId) As Sira, MessageId
FROM liveChatMessages
where VideoId=@videoId
AND Id not IN (SELECT Fk_LiveChatMessage FROM competitionAnswers)
) 

DELETE FROM tbl WHERE Sira>1
GO
/****** Object:  StoredProcedure [dbo].[findAnswers]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[findAnswers] @competitionId int
AS

DECLARE @startAt datetime,
		@endAt datetime,
		@videoId varchar(max),
		@answer decimal(38,0)

SELECT @startAt=StartTime, @endAt=EndTime, @videoId=VideoId, @answer=CAST(Answer AS decimal(38,0))
FROM competitions
WHERE Id=@competitionId

DELETE competitionAnswers WHERE Fk_Competition=@competitionId

INSERT INTO competitionAnswers(Fk_Competition,Fk_LiveChatMessage,Score,IsValid)
SELECT Fk_Comp, Fk_Chat,CASE WHEN Score < 0 THEN 0 ELSE Score END As Score ,Valid
FROM (
	SELECT TOP 1000000 @competitionId As Fk_Comp
		,Id as Fk_Chat 
		,@answer as Answer
		,CAST(1 as bit) as Valid
		,ABS(@answer-NumericMessage) AS Gap
		,100-(ROW_NUMBER() OVER(ORDER BY ABS(@answer-NumericMessage),PublishedAt ASC)-1) As Score
	FROM 
	(
		SELECT ROW_NUMBER() OVER(PARTITION BY AuthorChannelId ORDER BY AuthorChannelId,PublishedAt) As Sira,Id
			,CAST(NumericMessage AS decimal(38,0)) NumericMessage
			,PublishedAt
		FROM liveChatMessages
		WHERE VideoId=@videoId
			AND PublishedAt BETWEEN @startAt AND @endAt
			AND IsMessageNumeric=1
			AND (CASE WHEN NumericMessage NOT LIKE '%[^0-9]%' THEN NumericMessage END) IS NOT NULL
			AND LEN(NumericMessage)<30
	) tekilTablo
	WHERE Sira=1
	ORDER BY ABS(@answer-NumericMessage) ASC,PublishedAt ASC 
) tbl
GO
/****** Object:  StoredProcedure [dbo].[getWinnerOfDay]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[getWinnerOfDay] 
    @tarih smalldatetime= 0
AS

SELECT TOP 50 CAST(PublishedAt AS DATE) Day
	,AuthorChannelId
	,AuthorChannelUrl
	,AuthorDisplayName
	,SUM(Score) TotalScore
	,COUNT(DISTINCT(CompetitionId)) TotalCompetition
	,ROW_NUMBER() OVER (PARTITION BY CAST(PublishedAt AS DATE) ORDER BY SUM(Score) DESC) Sequence
FROM ValidAnswers_vw
WHERE CAST(PublishedAt AS DATE)=CAST(@tarih as DATE)
GROUP BY CAST(PublishedAt AS DATE),AuthorChannelId,AuthorChannelUrl,AuthorDisplayName
ORDER BY TotalScore DESC
GO
/****** Object:  StoredProcedure [dbo].[Index_Maintenance]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[Index_Maintenance] @DBName VARCHAR(100)
AS BEGIN
		SET NOCOUNT ON;
		DECLARE
			@OBJECT_ID INT,
			@INDEX_NAME sysname,
			@SCHEMA_NAME sysname,
			@OBJECT_NAME sysname,
			@AVG_FRAG float,
			@command varchar(8000),
			@RebuildCount int,
			@ReOrganizeCount int

		CREATE TABLE #tempIM (
			[ID] [INT] IDENTITY(1,1) NOT NULL PRIMARY KEY,
			[INDEX_NAME] sysname NULL,
			[OBJECT_ID] INT NULL,
			[SCHEMA_NAME] sysname NULL,
			[OBJECT_NAME] sysname NULL,
			[AVG_FRAG] float
		)		
		SELECT @RebuildCount=0,@ReOrganizeCount=0
		
		--Get Fragentation values
		SELECT @command=
			'Use ' + @DBName + '; 
			INSERT INTO #tempIM (OBJECT_ID, INDEX_NAME, SCHEMA_NAME, OBJECT_NAME, AVG_FRAG)
			SELECT
				ps.object_id,
				i.name as IndexName,
				OBJECT_SCHEMA_NAME(ps.object_id) as ObjectSchemaName,
				OBJECT_NAME (ps.object_id) as ObjectName,
				ps.avg_fragmentation_in_percent
			FROM sys.dm_db_index_physical_stats (NULL, NULL, NULL , NULL, ''LIMITED'') ps
			INNER JOIN sys.indexes i ON i.object_id=ps.object_id and i.index_id=ps.index_id
			WHERE avg_fragmentation_in_percent > 5 AND ps.index_id > 0
				and ps.database_id=DB_ID('''+@DBName+''')
			ORDER BY avg_fragmentation_in_percent desc
			'
		
		exec(@command)
		DECLARE c CURSOR FAST_FORWARD FOR
			SELECT OBJECT_ID,INDEX_NAME, SCHEMA_NAME, OBJECT_NAME, AVG_FRAG
			FROM #tempIM
		OPEN c
		FETCH NEXT FROM c INTO @OBJECT_ID, @INDEX_NAME, @SCHEMA_NAME, @OBJECT_NAME, @AVG_FRAG
		WHILE @@FETCH_STATUS = 0
		BEGIN
			--Reorganize or Rebuild
			IF @AVG_FRAG>30 BEGIN
				SELECT @command = 'Use ' + @DBName + '; ALTER INDEX [' + @INDEX_NAME +'] ON [' 
								  + @SCHEMA_NAME + '].[' + @OBJECT_NAME + '] REBUILD   WITH (ONLINE = ON  )';
				SET @RebuildCount = @RebuildCount+1
			END ELSE BEGIN
				SELECT @command = 'Use ' + @DBName + '; ALTER INDEX [' + @INDEX_NAME +'] ON [' 
								  + @SCHEMA_NAME + '].[' + @OBJECT_NAME + '] REORGANIZE ';
				SET @ReOrganizeCount = @ReOrganizeCount+1
			END
								  
			BEGIN TRY 
				EXEC (@command);	 
			END TRY 
			BEGIN CATCH 
			END CATCH 
			
			FETCH NEXT FROM c INTO @OBJECT_ID, @INDEX_NAME, @SCHEMA_NAME, @OBJECT_NAME, @AVG_FRAG
		END
		CLOSE c
		DEALLOCATE c
		
		DROP TABLE #tempIM
		
		SELECT cast(@RebuildCount as varchar(5))+' index Rebuild,'+cast(@ReOrganizeCount as varchar(5))+' index Reorganize edilmistir.' as Result
END		
GO
/****** Object:  StoredProcedure [dbo].[liveChatMessages_add]    Script Date: 23.10.2019 14:02:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[liveChatMessages_add] 
(
	@messageId varchar(max),
	@channelId varchar(1000),
	@channelUrl varchar(1000),
	@displayName varchar(1000),
	@liveChatId varchar(800),
	@videoId varchar(800),
	@publishedAt datetime,
	@messageText varchar(max),
	@hasDisplayContenct bit,
	@isVerified bit,
	@isChatOwner bit,
	@isChatSponsor bit,
	@isChatModerator bit
)
AS
SET NOCOUNT ON
DECLARE @yeni int = 0

IF NOT EXISTS (SELECT * FROM liveChatMessages WHERE MessageId=@messageId)
BEGIN
	INSERT INTO liveChatMessages(MessageId,AuthorChannelId,AuthorChannelUrl,AuthorDisplayName,LiveChatId,VideoId
		,PublishedAt,MessageText,HasDisplayContent,IsVerified,IsChatOwner,IsChatSponsor,IsChatModerator)
	SELECT @messageId,@channelId,@channelUrl,@displayName,@liveChatId,@videoId,@publishedAt,@messageText
		,@hasDisplayContenct,@isVerified,@isChatOwner,@isChatSponsor,@isChatModerator
	
	SET @yeni = 1
END
SELECT @yeni
GO
