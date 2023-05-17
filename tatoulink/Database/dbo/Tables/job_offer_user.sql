CREATE TABLE [dbo].[job_offer_user] (
    [job_offer_id] INT NULL,
    [user_id]      INT NULL,
    FOREIGN KEY ([job_offer_id]) REFERENCES [dbo].[job_offer] ([id]),
    FOREIGN KEY ([user_id]) REFERENCES [dbo].[user] ([id])
);

