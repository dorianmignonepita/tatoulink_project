CREATE TABLE [dbo].[user] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [firstname] VARCHAR (50)  NOT NULL,
    [surname]   VARCHAR (50)  NOT NULL,
    [birthdate] DATETIME      NOT NULL,
    [password]  VARCHAR (100) NOT NULL,
    [email]     VARCHAR (100) NOT NULL,
    [status]    INT           NOT NULL,
    [last_jobs] VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([email] ASC)
);

