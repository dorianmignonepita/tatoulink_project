/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Lenoic', 'CRAMON',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', 'lenoic.cramon@epita.fr', 1, 'Etudiant' )


INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Guillaume', 'AVRIL',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', 'guillaume.avril@epita.fr', 1, 'Etudiant' )

INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Dorian', 'MIGNON',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', 'dorian.mignon@epita.fr', 1, 'Etudiant' )

    
INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Leo', 'MERMET',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', 'leo.mermet@epita.fr', 1, 'Etudiant' )


INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Manon', 'JACQUET',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', 'manon.jacquet@epita.fr', 1, 'Etudiant' )

    
INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Marie', 'FLOISSAC--DUFOREZ',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', 'marie.floissac-duforez@epita.fr', 1, 'Etudiant' )

    
INSERT [dbo].[user] ([firstname],[surname] ,[birthdate] ,[password] ,[email] ,[status] ,[last_jobs])
    VALUES ( 'Thibault', 'HOGUIN',GETDATE(), 'AQAAAAEAACcQAAAAENMNy/T7Hk80MjCSB3Yo8wrck1Mq7yDfxLz6wJnNQFpV2yKngwtLGY2bBcMzh1owXw==', '	thibault.hoguin@epita.fr', 1, 'Etudiant' )




INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur BackEnd' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDI' ,'2060-06-03 19:50:00.000' ,1)

INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur FrontEnd' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDD de 6 mois' ,'2060-06-03 19:50:00.000' ,2)

INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur FullStack' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDI' ,'2060-06-03 19:50:00.000' ,3)

INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur DotNet' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDD de 3 ans' ,'2060-06-03 19:50:00.000' ,1)
    
INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur Kotlin' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDD de 6 mois' ,'2060-06-03 19:50:00.000' ,4)
    
INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur CAML' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDI' ,'2060-06-03 19:50:00.000' ,4)
    
INSERT [dbo].[job_offer] ([offer_name] ,[description] ,[creation_date] ,[type] ,[duration] ,[expiring_date] ,[creator_id])
    VALUES ('Développeur BRAINFUCK' ,'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.' ,GETDATE() ,1 ,'CDI' ,'2060-06-03 19:50:00.000' ,3)




INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (1 ,5)

INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (2 ,1)

INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (3 ,1)

INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (4 ,1)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (5 ,1)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (7 ,1)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (1 ,2)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (4 ,2)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (3 ,2)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (6 ,3)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (6 ,4)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (5 ,4)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (2 ,4)
    
INSERT [dbo].[job_offer_user] ([job_offer_id] ,[user_id])
    VALUES (7 ,3)




INSERT [dbo].[notification] ([sender_id] ,[receiver_id] ,[job_offer_user_id] ,[message] ,[timestamp])
    VALUES (1 ,2 ,1 ,'Nous sommes tres interesser par votre profile venez svp' ,GETDATE())