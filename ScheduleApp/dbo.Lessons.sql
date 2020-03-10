CREATE TABLE [dbo].[Lessons] (
    [LessonId]    INT            IDENTITY (1, 1) NOT NULL,
    [Type]        INT            NOT NULL,
    [Number]      INT            NOT NULL,
    [Date]        DATETIME2 (7)  NOT NULL,
    [StartLesson] DATETIME2 (7)  NOT NULL,
    [EndLesson]   DATETIME2 (7)  NOT NULL,
    [Info]        NVARCHAR (MAX) NULL,
    [SubjectId]   INT            NOT NULL,
    [GroupId]     INT            NOT NULL,
    [TeacherId]   NVARCHAR (450) NULL,
    [ClassroomId] INT            NOT NULL,
    CONSTRAINT [PK_Lessons] PRIMARY KEY CLUSTERED ([LessonId] ASC),
    CONSTRAINT [FK_Lessons_Classrooms_ClassroomId] FOREIGN KEY ([ClassroomId]) REFERENCES [dbo].[Classrooms] ([ClassroomId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Lessons_Groups_GroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([GroupId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Lessons_Subjects_SubjectId] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subjects] ([SubjectId]) ON DELETE CASCADE,
    CONSTRAINT [FK_Lessons_AspNetUsers_TeacherId] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Lessons_ClassroomId]
    ON [dbo].[Lessons]([ClassroomId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Lessons_GroupId]
    ON [dbo].[Lessons]([GroupId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Lessons_SubjectId]
    ON [dbo].[Lessons]([SubjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Lessons_TeacherId]
    ON [dbo].[Lessons]([TeacherId] ASC);

