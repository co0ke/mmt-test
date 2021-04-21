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
	SELECT p.SKU, p.[Name], p.[Description], p.Price, p.IsFeatured --c.ID, c.[Name] -- consider if you want to return category stuff.
	FROM shop.Product p
	INNER JOIN shop.ProductCategoryLink pcl
	ON p.SKU = pcl.SKU
	INNER JOIN shop.Category c
	ON c.ID = pcl.CategoryID
	WHERE c.ID = @CategoryID
GO