CREATE TABLE [dbo].[job_offer_user] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [job_offer_id] INT NULL,
    [user_id]      INT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([job_offer_id]) REFERENCES [dbo].[job_offer] ([id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([id])
);

