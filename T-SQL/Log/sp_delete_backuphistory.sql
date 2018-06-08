USE msdb
GO

select Count(*) from [dbo].[backupfile] with (nolock)


USE msdb;  
GO  

EXEC sp_delete_backuphistory @oldest_date = '2017-02-07';