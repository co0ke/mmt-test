USE MMTShop
GO

CREATE SCHEMA shop
GO

CREATE TABLE shop.Product
(
	SKU NVARCHAR(16) NOT NULL, 
	[Name] NVARCHAR(500) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	IsFeatured BIT NOT NULL,

	CONSTRAINT PK_Product_SKU PRIMARY KEY (SKU),
)

CREATE TABLE shop.Category
(
	ID INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(500) NOT NULL,

	CONSTRAINT PK_Category_ID PRIMARY KEY (ID)
)

CREATE TABLE shop.ProductCategoryLink
(
	SKU NVARCHAR(16) NOT NULL,
	CategoryID INT NOT NULL,

	CONSTRAINT PK_ProductCategoryLink_ID PRIMARY KEY (SKU, CategoryID),

	CONSTRAINT FK_ProductCategoryLink_SKU FOREIGN KEY (SKU) 
	REFERENCES shop.Product (SKU)         
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	CONSTRAINT FK_ProductCategoryLink_CategoryID FOREIGN KEY (CategoryID)
	REFERENCES Shop.Category (ID)
	ON DELETE CASCADE
	ON UPDATE CASCADE,

	CONSTRAINT AK_SKU UNIQUE(SKU) -- Restrict product to one category max to satisfy current requirements. 
)

-- SEED

INSERT INTO shop.Product (SKU, [Name], [Description], Price, IsFeatured) 
VALUES 
	(10001, 'Dining Table', 'Made from Oak', 200, 1),
	(10002, 'Sofa', 'The softest ever', 600, 1),
	(20005, 'Plant', 'It is massive', 30, 1),
	(20006, 'Soil', 'A true classic', 11, 1),
	(30005, 'Laptop', 'Lighting fast', 800, 1),
	(40006, 'Tennis Raquet', 'A super tennis raquet', 11, 0),
	(50001, 'Fire Engine', 'Hours of fun', 13, 0)

INSERT INTO shop.Category ([Name]) 
VALUES 
	('Home'),
	('Garden'),
	('Electronics'),
	('Fitness'),
	('Toys')

INSERT INTO shop.ProductCategoryLink (SKU, CategoryID) 
VALUES 
	('10001', 1),
	('10002', 1),
	('20005', 2),
	('20006', 2),
	('30005', 3),
	('40006', 4),
	('50001', 5)