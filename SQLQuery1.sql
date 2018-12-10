CREATE PROCEDURE sp_GetIngredient
@name nvarchar(50),
@price money,
@unit nvarchar(20)
AS
INSERT INTO Ingredients (Name_Ingredient, Price_Dish, ID_Unit)
VALUES (@name, @price, (SELECT ID_Unit FROM Unit WHERE Name_Unit = @unit))
GO


CREATE PROCEDURE sp_GetDish
@name nvarchar(50),
@price money,
@typeOfDish nvarchar(40)
AS
INSERT INTO Dish (Name_Dish, Price_Dish, ID_TypeDish)
VALUES (@name, @price, (SELECT ID_Type FROM TypeOfDish WHERE Name_Type = @typeOfDish))
GO


--DROP PROCEDURE sp_GetDish





CREATE PROCEDURE sp_UpdateIngredient
@id int,
@name nvarchar(50),
@price money,
@unit nvarchar(20)
AS
UPDATE Ingredients SET Name_Ingredient = @name, Price_Dish=@price, ID_Unit=(SELECT ID_Unit FROM Unit WHERE Name_Unit = @unit) WHERE ID_Ingredient=@id

GO




