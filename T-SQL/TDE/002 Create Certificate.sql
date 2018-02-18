USE master;
GO

CREATE MASTER KEY ENCRYPTION BY PASSWORD = '123';
GO

-- will expire after one year
CREATE CERTIFICATE TDE_CERT WITH SUBJECT = 'TDE_CERT123';
GO

USE TDE_DB;
GO

CREATE DATABASE ENCRYPTION KEY
WITH ALGORITHM = AES_128
ENCRYPTION BY SERVER CERTIFICATE TDE_CERT;
GO

USE master
GO

BACKUP CERTIFICATE TDE_CERT
TO FILE = 'TDE_CERT'
WITH PRIVATE KEY (
		 FILE = 'TDE_CERT.pvk'
		,ENCRYPTION BY PASSWORD = '321');
GO

SELECT db.name
	,db.is_encrypted
	,dm.encryption_state
	,dm.percent_complete
	,dm.key_algorithm
	,dm.key_length
FROM sys.databases db
LEFT JOIN sys.dm_database_encryption_keys dm
ON db.database_id = dm.database_id
GO