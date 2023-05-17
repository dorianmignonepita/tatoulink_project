CREATE TABLE [dbo].[notification] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [sender_id]         INT           NOT NULL,
    [receiver_id]       INT           NOT NULL,
    [job_offer_user_id] INT           NOT NULL,
    [message]           VARCHAR (200) NOT NULL,
    [timestamp]         DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([job_offer_user_id]) REFERENCES [dbo].[job_offer_user] ([id]),
    FOREIGN KEY ([receiver_id]) REFERENCES [dbo].[user] ([id]),
    FOREIGN KEY ([sender_id]) REFERENCES [dbo].[user] ([id])
);

