USE [SQLiDemoDB]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[fsp_search_product]
		@productName = N'Mobile'

SELECT	@return_value as 'Return Value'

GO
