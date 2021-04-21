USE MMTShop
GO

CREATE PROCEDURE shop.uspGetFeaturedProducts 

AS   
	SELECT SKU, [Name], [Description], Price, IsFeatured 
	FROM shop.Product 
	WHERE IsFeatured = 1
GO

CREATE PROCEDURE shop.uspGetAvailableCategories 

AS   
	SELECT ID, [Name]
	FROM shop.Category
GO

CREATE PROCEDURE shop.uspGetProductsByCategory 
    @CategoryID int
AS   
	SELECT p.SKU, p.[Name], p.[Description], p.Price, p.IsFeatured
	FROM shop.Product p
	INNER JOIN shop.ProductCategoryLink pcl
	ON p.SKU = pcl.SKU
	WHERE pcl.CategoryID = @CategoryID
GO