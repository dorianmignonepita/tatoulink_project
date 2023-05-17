CREATE TABLE [dbo].[job_offer] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [offer_name]    VARCHAR (100) NOT NULL,
    [description]   VARCHAR (100) NOT NULL,
    [creation_date] DATETIME      NOT NULL,
    [type]          INT           NOT NULL,
    [duration]      VARCHAR (100) NULL,
    [expiring_date] DATETIME      NOT NULL,
    [creator_id]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([creator_id]) REFERENCES [dbo].[user] ([id])
);

