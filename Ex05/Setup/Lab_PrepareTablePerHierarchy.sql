USE AdventureWorksLT

IF(OBJECT_ID('SalesLT.vProduct') IS NOT NULL)
	DROP VIEW SalesLT.vProduct
GO
CREATE VIEW SalesLT.vProduct
AS
	SELECT	*,
			CASE WHEN SellEndDate IS NULL
				 THEN 1
				 ELSE 0
			END AS IsSoldOutProduct
	FROM	SalesLT.Product
GO
SELECT * FROM SalesLT.vProduct
