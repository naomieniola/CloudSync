-- Create Artists Table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](max) NOT NULL,
	[GenreId] [int] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Biography] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artists] ADD  CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Artists_GenreId] ON [dbo].[Artists]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Artists] ADD  DEFAULT (N'') FOR [Image]
GO
ALTER TABLE [dbo].[Artists] ADD  DEFAULT (N'') FOR [Biography]
GO
ALTER TABLE [dbo].[Artists]  WITH CHECK ADD  CONSTRAINT [FK_Artists_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Artists] CHECK CONSTRAINT [FK_Artists_Genres_GenreId]
GO

-- Insert Into Arists Table
SELECT 'INSERT INTO dbo.Artists (ArtistId, ArtistName, GenreId) VALUES (' + 
       CAST(ArtistId AS NVARCHAR) + ', ''' + ArtistName + ''', ' + 
       CAST(GenreId AS NVARCHAR) + ');'
FROM dbo.Artists;

-- Create FavouriteSongs Table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FavouriteSongs](
	[FavouriteSongId] [int] IDENTITY(1,1) NOT NULL,
	[SongId] [int] NOT NULL,
	[UserId] [nvarchar](450) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FavouriteSongs] ADD  CONSTRAINT [PK_FavouriteSongs] PRIMARY KEY CLUSTERED 
(
	[FavouriteSongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FavouriteSongs_SongId] ON [dbo].[FavouriteSongs]
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE NONCLUSTERED INDEX [IX_FavouriteSongs_UserId] ON [dbo].[FavouriteSongs]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FavouriteSongs]  WITH CHECK ADD  CONSTRAINT [FK_FavouriteSongs_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FavouriteSongs] CHECK CONSTRAINT [FK_FavouriteSongs_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[FavouriteSongs]  WITH CHECK ADD  CONSTRAINT [FK_FavouriteSongs_Songs_SongId] FOREIGN KEY([SongId])
REFERENCES [dbo].[Songs] ([SongId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FavouriteSongs] CHECK CONSTRAINT [FK_FavouriteSongs_Songs_SongId]
GO

-- Insert Into FavouriteSongs Table
SELECT 'INSERT INTO dbo.FavouriteSongs (FavouriteId, UserId, SongId) VALUES (' + 
       CAST(FavouriteId AS NVARCHAR) + ', ''' + UserId + ''', ' + 
       CAST(SongId AS NVARCHAR) + ');'
FROM dbo.FavouriteSongs;

-- Create Genres Table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[GenreId] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](max) NOT NULL,
	[GenreImage] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Genres] ADD  CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Genres] ADD  DEFAULT (N'') FOR [GenreImage]
GO

-- Insert Into Genres Table
SELECT 'INSERT INTO dbo.Genres (GenreId, GenreName) VALUES (' + 
       CAST(GenreId AS NVARCHAR) + ', ''' + GenreName + ''');'
FROM dbo.Genres;


-- Create Songs Table
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Songs](
	[SongId] [int] IDENTITY(1,1) NOT NULL,
	[SongName] [nvarchar](max) NOT NULL,
	[SongDuration] [time](7) NOT NULL,
	[SongFile] [nvarchar](max) NULL,
	[ArtistId] [int] NOT NULL,
	[GenreId] [int] NOT NULL,
	[SongImage] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Songs] ADD  CONSTRAINT [PK_Songs] PRIMARY KEY CLUSTERED 
(
	[SongId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Songs_ArtistId] ON [dbo].[Songs]
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Songs_GenreId] ON [dbo].[Songs]
(
	[GenreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Artists_ArtistId] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artists] ([ArtistId])
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Artists_ArtistId]
GO
ALTER TABLE [dbo].[Songs]  WITH CHECK ADD  CONSTRAINT [FK_Songs_Genres_GenreId] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([GenreId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Songs] CHECK CONSTRAINT [FK_Songs_Genres_GenreId]
GO

-- Insert Into Songs Table
SELECT 'INSERT INTO dbo.Songs (SongId, SongName, SongDuration, SongFile, ArtistId, GenreId) VALUES (' + 
       CAST(SongId AS NVARCHAR) + ', ''' + SongName + ''', ''' + SongDuration + ''', ''' + SongFile + ''', ' + 
       CAST(ArtistId AS NVARCHAR) + ', ' + CAST(GenreId AS NVARCHAR) + ');'
FROM dbo.Songs;
