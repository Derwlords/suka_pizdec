USE LowCostHotel
GO

SELECT * FROM Residences;
SELECT * FROM Users;

--UPDATE Users SET Role='admin' WHERE Id = 2

--UPDATE Residences SET Paided=0 WHERE Id = 2

--DELETE FROM Residences
--DELETE FROM [dbo].[Statistics]
DELETE FROM Users WHERE Id=1