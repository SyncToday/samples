-- create new user
-- replace: __username__ for user name
-- replace: __floresuserid__ for Flores User ID from SecurityUsers.ID
-- replace: __exchangeloginname__ for Exchange login name
-- replace: __exchangeencryptedpassword__ for Exchange encrypted password
-- replace: __exchangeserver__ for Exchange server
-- replace: __synchronizefrom__ for the date you want the synchronization to start e.g. 2015-01-01
-- replace: rollback for commit

begin tran

declare @consumerId int
declare @accountId int

INSERT INTO [Consumers] ([Name]) VALUES ('__username__')
select @consumerId = @@IDENTITY

INSERT INTO [ConsumerAdapters] ([AdapterId] ,[ConsumerId] ,[DateJSON])
     VALUES ( (SELECT Id FROM Adapters where Name = 'EXCHANGE'), @consumerId, '' )
INSERT INTO [ConsumerAdapters] ([AdapterId] ,[ConsumerId] ,[DateJSON])
     VALUES ( (SELECT Id FROM Adapters where Name = 'FLORES'), @consumerId, '__floresuserid__' )

INSERT INTO [dbo].[Accounts] ([Name] ,[ConsumerId])
     VALUES ('__username__',@consumerId)
select @accountId = @@IDENTITY

INSERT INTO [ServiceAccounts] 
		([LoginJSON],[ServiceId],[AccountId],[LastSuccessfulDownload],[LastDownloadAttempt],[LastSuccessfulUpload],[LastUploadAttempt])
     VALUES
           ('{"loginName" : "__exchangeloginname__", "password" : "__exchangeencryptedpassword__", "server" : "__exchangeserver__", "impersonate" : "false"}'
           ,(SELECT Id FROM Services where [Key] = 'EXCHANGE')
           ,@accountId
           ,'__synchronizefrom__'
           ,NULL,NULL,NULL)

rollback
