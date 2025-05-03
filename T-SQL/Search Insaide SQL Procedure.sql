DECLARE @SearchText NVARCHAR(100) = N'Client';

SELECT 
    OBJECT_SCHEMA_NAME(o.object_id) AS [Schema],
    o.name AS [ObjectName],
    o.type_desc AS [ObjectType],
    m.definition AS [ObjectDefinition]
FROM 
    sys.sql_modules m
JOIN 
    sys.objects o ON m.object_id = o.object_id
WHERE 
    m.definition LIKE '%' + @SearchText + '%'
    AND o.type IN ('P', 'FN', 'TF', 'IF')  -- P = Stored Procedure, FN = Scalar Function, TF = Table-valued Function, IF = Inline Table-valued Function
ORDER BY 
    [Schema], [ObjectName];