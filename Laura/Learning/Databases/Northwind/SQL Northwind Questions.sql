-----------------------------------------------------------------------------------------------
-- NORTHWIND DATABASE QUESTIONS
-----------------------------------------------------------------------------------------------

-----------------------------------------------------------------------------------------------
-- 1. Get a list of UK Customers ordered by their Surname 
-----------------------------------------------------------------------------------------------

SELECT ContactName
FROM Customers
WHERE (Country = 'UK') 
ORDER BY SUBSTRING(ContactName, CHARINDEX(' ', ContactName, 1), LEN(ContactName))

-----------------------------------------------------------------------------------------------
-- 2. Get a list of all Managers
-----------------------------------------------------------------------------------------------

SELECT DISTINCT
	managers.EmployeeID, 
	managers.firstname, 
	managers.lastname
FROM employees
JOIN employees as managers ON employees.reportsto = managers.employeeID 

-----------------------------------------------------------------------------------------------
-- 3. Get a list of Employees with each Terrority (including the Region name) that they work in
-----------------------------------------------------------------------------------------------

SELECT LastName, FirstName, RegionDescription AS Region, t.TerritoryDescription AS Territory

FROM Employees as e

JOIN EmployeeTerritories as et
	ON et.EmployeeID = e.EmployeeID
JOIN Territories as t
	ON t.TerritoryID = et.TerritoryID
JOIN Region as r
	On r.RegionID = t.RegionID

-----------------------------------------------------------------------------------------------
-- 4. How many Employees work in the Southern region?
-----------------------------------------------------------------------------------------------
SELECT COUNT(*) AS SouthernRegionEmployees
FROM Employees AS e

JOIN EmployeeTerritories as et
	ON et.EmployeeID = e.EmployeeID
JOIN Territories as t
	ON t.TerritoryID = et.TerritoryID
JOIN Region as r
	On r.RegionID = t.RegionID

WHERE RegionDescription = 'Southern'
-----------------------------------------------------------------------------------------------
-- 5. Get a alphabetical list of products that are still sold
-----------------------------------------------------------------------------------------------
SELECT ProductName
FROM Products
WHERE Discontinued = 0
ORDER BY ProductName
-----------------------------------------------------------------------------------------------
-- 6. Get the total product sales (including category) for 1997
-----------------------------------------------------------------------------------------------
SELECT 
	p.ProductID,
	p.ProductName,
	c.CategoryName,
	ROUND
	(
		SUM
		(
			CASE
				WHEN od.Discount = 0 THEN (od.UnitPrice * od.Quantity)
				ELSE ((od.UnitPrice * od.Quantity) * od.Discount)
			END
		), 
		2
	) AS Total
FROM [Order Details] AS od
JOIN [Orders] AS o ON o.OrderID = od.OrderID
JOIN [Products] AS p ON p.ProductID = od.ProductID
JOIN [Categories] AS c ON c.CategoryID = p.CategoryID
WHERE YEAR(o.OrderDate) = 1997
GROUP BY p.ProductID, p.ProductName, c.CategoryName
ORDER BY p.ProductID
-----------------------------------------------------------------------------------------------
-- 7. Get a list of beverages over £15
-----------------------------------------------------------------------------------------------
SELECT 
	p.ProductName,
	p.UnitPrice
FROM Products AS p
JOIN Categories AS c ON c.CategoryID = p.CategoryID
WHERE CategoryName = 'Beverages' AND (UnitPrice > 15)

-----------------------------------------------------------------------------------------------
-- 8. Get a list of contacts 
-- (all customers and suppliers including company name, contact name, city and if they are a customer or supplier)
-----------------------------------------------------------------------------------------------

SELECT s.CompanyName, s.ContactName, s.City, 'Supplier' AS ContactType
FROM Suppliers AS s
UNION ALL
SELECT c.CompanyName, c.ContactName, c.City, 'Customer' AS ContactType 
FROM Customers AS c

-----------------------------------------------------------------------------------------------
-- 9. Get the subtotals for all Orders
-----------------------------------------------------------------------------------------------

SELECT
	CASE
		WHEN Discount = 0 THEN (UnitPrice * Quantity) 
		ELSE ((UnitPrice * Quantity) * Discount)
	END AS OrderAmount, *

FROM [Order Details]

-- //TODO: code is good but not complete, it does the sub total for order items not for the whole order

SELECT
	OrderID,
	SUM
	(
		CASE
			WHEN Discount = 0 THEN (UnitPrice * Quantity) 
			ELSE ((UnitPrice * Quantity) * Discount)
		END
	) AS Subtotal

FROM [Order Details]
GROUP BY OrderID

-----------------------------------------------------------------------------------------------
-- 10. Get a list of Products above the average price
-----------------------------------------------------------------------------------------------
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice > (SELECT AVG(UnitPrice) FROM Products)

-----------------------------------------------------------------------------------------------
-- 11. Get a list of Employees ordered newest to oldest
-----------------------------------------------------------------------------------------------
SELECT FirstName, LastName, HireDate 
FROM Employees

ORDER BY HireDate DESC

-----------------------------------------------------------------------------------------------
-- 12. Get a list of Orders being shipped by Speedy Express
-----------------------------------------------------------------------------------------------
SELECT o.OrderID, o.CustomerID, OrderDate, s.CompanyName
FROM Orders AS o

JOIN Shippers AS s
ON s.ShipperID = o.ShipVia

WHERE CompanyName = 'Speedy Express'

ORDER BY o.OrderID

-----------------------------------------------------------------------------------------------
-- 13. Get a list of Products that are out of stock
-----------------------------------------------------------------------------------------------
SELECT *
FROM Products
WHERE UnitsInStock = 0
-----------------------------------------------------------------------------------------------
-- 14. Get a list of all Orders that were shipped later than they were required
-----------------------------------------------------------------------------------------------
SELECT OrderID, CustomerID, RequiredDate, ShippedDate
FROM Orders
WHERE ShippedDate > RequiredDate

-----------------------------------------------------------------------------------------------
-- 15. Get a list of all companies that use fax
-----------------------------------------------------------------------------------------------
SELECT CompanyName, ContactName, Address, Fax
FROM Suppliers
WHERE Fax IS NOT NULL

-----------------------------------------------------------------------------------------------
-- 16. Get the age of all Employees
-----------------------------------------------------------------------------------------------
SELECT 
	EmployeeID,
	LastName,
	FirstName,
	DATEDIFF(Year, BirthDate, GetDate()) AS Age
FROM Employees
-----------------------------------------------------------------------------------------------
-- 17. Get a list of all products and who they are supplied by, ordered by the supplier
-----------------------------------------------------------------------------------------------
SELECT
	ProductName,
	CompanyName
FROM Products AS p
JOIN Suppliers AS s ON s.SupplierID = p.SupplierID
ORDER BY CompanyName
-----------------------------------------------------------------------------------------------
-- 18. Get a list of total sales figures for each year
-----------------------------------------------------------------------------------------------

 SELECT  	
	ROUND
	(
		SUM
		(
			CASE
				WHEN od.Discount = 0 THEN (od.UnitPrice * od.Quantity) 
				ELSE ((od.UnitPrice * od.Quantity) * od.Discount)
			END 
		),
		2		
	) AS TotalSales,
	YEAR(OrderDate) AS YearOfSales
 FROM [Order Details] AS od
 JOIN [Orders] AS o ON o.OrderID = od.OrderID
 GROUP BY YEAR(OrderDate) 
 ORDER BY YEAR(OrderDate)

-- //TODO: not finished

-----------------------------------------------------------------------------------------------
-- 19. Get total sales for each category for each year
-----------------------------------------------------------------------------------------------
SELECT 
	CategoryName,
	ROUND
	(
		SUM
		(
			CASE
				WHEN od.Discount = 0 THEN (od.UnitPrice * od.Quantity) 
				ELSE ((od.UnitPrice * od.Quantity) * od.Discount)
			END 
		),
		2		
	) AS TotalSales,
	YEAR(o.OrderDate) AS YearOfSales
FROM [Order Details] AS od
JOIN Orders AS o ON o.OrderID = od.OrderID
JOIN Products AS p ON p.ProductID = od.ProductID
JOIN Categories AS c ON c.CategoryID = p.CategoryID
GROUP BY CategoryName, YEAR(o.OrderDate)

-- //TODO: no discount factored in

-----------------------------------------------------------------------------------------------
-- 20. Get detailed information of each sale that could be used for an invoice
-- (Shipping Details, Customer Details, Salesperson, Order details, Product Details)
-----------------------------------------------------------------------------------------------
SELECT 
	od.OrderID,
	c.ContactName AS CustomerName,
	c.Address,
	c.Phone,
	CONVERT(varchar, o.OrderDate, 6) AS OrderDate,
	p.ProductName,
	od.UnitPrice,
	od.Quantity,
	od.Discount,
	CASE
		WHEN od.Discount = 0 THEN (od.UnitPrice * od.Quantity) 
		ELSE ((od.UnitPrice * od.Quantity) * od.Discount)
	END AS Cost,
	s.CompanyName AS ShippingCompany,
	e.FirstName + ' ' + e.LastName AS EmployeeName

FROM [Order Details] AS od

JOIN Orders AS o
ON o.OrderID = od.OrderID

JOIN Customers AS c
ON c.CustomerID = o.CustomerID

JOIN Products as p 
ON p.ProductID = od.ProductID

JOIN Employees as e
ON e.EmployeeID = o.EmployeeID

JOIN Shippers as s
ON s.ShipperID = o.ShipVia
-----------------------------------------------------------------------------------------------
-- 21. Get the number of orders that contain each product
-----------------------------------------------------------------------------------------------
SELECT ProductName, SUM(od.Quantity) AS NumberOrdered
FROM Products AS p

JOIN [Order Details] AS od
ON od.ProductID = p.ProductID

GROUP BY ProductName

-----------------------------------------------------------------------------------------------
-- 22. Get the quantity of each product that is part of a current order
-----------------------------------------------------------------------------------------------

SELECT ProductName, SUM(od.Quantity) AS NumberWithinACurrentOrder
FROM Products AS p

JOIN [Order Details] AS od
ON od.ProductID = p.ProductID

JOIN Orders AS o
ON o.OrderID = od.OrderID

WHERE ShippedDate IS NULL

GROUP BY ProductName
-----------------------------------------------------------------------------------------------
-- 23. Are any employees also customers?
-----------------------------------------------------------------------------------------------

SELECT FirstName + ' ' + LastName AS ContactName FROM [Employees]
INTERSECT
SELECT DISTINCT [ContactName] FROM [Customers]


-----------------------------------------------------------------------------------------------
-- 24. What is the most expensive product?
-----------------------------------------------------------------------------------------------
SELECT TOP (1) ProductName, UnitPrice
FROM Products

ORDER BY UnitPrice DESC


-----------------------------------------------------------------------------------------------
-- 25. What is the largest order?
-----------------------------------------------------------------------------------------------
SELECT 
	od.OrderID,
	CASE
		WHEN od.Discount = 0 THEN (od.UnitPrice * od.Quantity) 
		ELSE ((od.UnitPrice * od.Quantity) * od.Discount)
	END AS OrderAmount

FROM [Order Details] AS od

JOIN Orders as o
ON o.OrderID = od.OrderID

JOIN Customers as c
ON c.CustomerID = o.CustomerID

GROUP BY od.OrderID

-- //TODO: not finished, need to work out how to add the totals for each of the OrderIDs
-----------------------------------------------------------------------------------------------
-- 26. Give the name of all customers who have only bought products with a unit price of less than £15
----------------------------------------------------------------------------------------------

SELECT ContactName, od.OrderID, od.UnitPrice
FROM Customers AS c

JOIN Orders AS o
ON o.CustomerID = c.CustomerID

JOIN [Order Details] AS od
ON od.OrderID = o.OrderID 

WHERE od.UnitPrice < 15

-- //TODO: not finished, need to work out how to make it only products, not single products


-----------------------------------------------------------------------------------------------
-- 27. Get a list of products that need to be reordered
-----------------------------------------------------------------------------------------------
 SELECT *
 FROM Products
 WHERE ReorderLevel >= UnitsInStock
-----------------------------------------------------------------------------------------------
-- 28. Get a list of products ordered by their popularity using quantity
-----------------------------------------------------------------------------------------------
SELECT ProductName, Quantity
FROM [Order Details] AS od

JOIN Products AS p
ON p.ProductID = od.ProductID

ORDER BY Quantity DESC

-- //TODO: misunderstood question

-----------------------------------------------------------------------------------------------
-- 29. Get a list of products ordered by their popularity using percentage of times they are contained within an order
-----------------------------------------------------------------------------------------------
DECLARE @totalQuantity AS int

SELECT 
	ProductName
FROM Products AS p

GROUP BY ProductName 

SELECT 
	@totalQuantity = SUM(od.Quantity)
FROM [Order Details] AS od
	


-- //TODO: not finished

-----------------------------------------------------------------------------------------------
-- 30. Get a list of categories and suppliers for each supplier thats sells products in those categories
-----------------------------------------------------------------------------------------------
SELECT c.CategoryName, s.CompanyName
FROM Suppliers AS s

JOIN Products AS p
ON p.SupplierID = s.SupplierID

JOIN Categories as c
ON c.CategoryID = p.CategoryID

GROUP BY c.CategoryName, s.CompanyName

-----------------------------------------------------------------------------------------------
-- 31. Get a list of how many orders for each customer ordered largest to smallest 
-----------------------------------------------------------------------------------------------
SELECT COUNT(DISTINCT OrderID) AS NumberOfOrders, ContactName
FROM Orders AS o

JOIN Customers AS c
ON c.CustomerID = o.CustomerID

GROUP BY ContactName

ORDER BY NumberOfOrders DESC

-----------------------------------------------------------------------------------------------
-- 32. Get a list of all customers latest order including customers who have not made an order
-----------------------------------------------------------------------------------------------
SELECT *
FROM Customers
LEFT JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
AND OrderID = 
(
	SELECT TOP 1 subOrders.OrderID
	FROM Orders subOrders
	WHERE subOrders.CustomerID = Orders.CustomerID
	ORDER BY subOrders.OrderDate DESC
)
 
-----------------------------------------------------------------------------------------------
-- 33. Add your manager to the employees table
-----------------------------------------------------------------------------------------------
INSERT INTO Employees
VALUES ('Jeeves', 'Phteven', 'Code Monkey Senior', 'Mr', '1993-12-18 00:00:00.000', '2020-05-03 00:00:00.000', '51 Lemonfield Drive', 'Twatford', 'Herts', 'WD0 0oo', 'UK', '118 118', '0000', NULL, 'Too many to write', NULL, NULL);

-----------------------------------------------------------------------------------------------
-- 34. Add yourself to the employees table reporting to your manager
-----------------------------------------------------------------------------------------------
INSERT INTO Employees
VALUES ('Jeeves', 'Laura', 'Code Monkey Junior', 'Mrs', '1992-05-15 00:00:00.000', '2022-06-21 00:00:00.000', '9 High Acres', 'Abbots', 'Herts', 'WD5 0JB', 'UK', '118 118', '0000', NULL, 'Too many to write', 11, NULL);

SELECT *
FROM Employees

-----------------------------------------------------------------------------------------------
-- 35. Create "IGD" as a customer
-----------------------------------------------------------------------------------------------
INSERT INTO Customers
VALUES ('LADYC', 'IDG', 'Lady Coder', 'Mrs', '6 IDG Road', 'Watford', 'Herts', 'WD0 0xx', 'UK', '08800', NULL)

SELECT *
FROM Customers

-----------------------------------------------------------------------------------------------
-- 36. Create "Royal Mail" as a shipper
-----------------------------------------------------------------------------------------------
INSERT INTO Shippers
VALUES ('Royal Mail', '0800 546')

SELECT *
FROM Shippers

-----------------------------------------------------------------------------------------------
-- 37. Create "Supply Me" as a supplier
-----------------------------------------------------------------------------------------------
INSERT INTO Suppliers
VALUES ('Supply Me', 'Blobby', 'Mr', '16 Spotty Street', 'Watford', 'Herts', 'WD0 0xx', 'UK', '08800', NULL, NULL)

SELECT *
FROM Suppliers

-----------------------------------------------------------------------------------------------
-- 38. Create a category "Of This Category"
-----------------------------------------------------------------------------------------------
INSERT INTO Categories
VALUES ('Of This Categor', 'Delicious Yummyummmms', NULL)

SELECT *
FROM Categories

-----------------------------------------------------------------------------------------------
-- 39. Create a product "I Am A Product" with category "Of This Category" that is supplied by "Supply Me" 
-----------------------------------------------------------------------------------------------

INSERT INTO Products
VALUES ('I Am A Product', 30, 10, '10 boxes x 34 bags', 13.50, 340, 0, 100, 0)

SELECT *
FROM Products

-----------------------------------------------------------------------------------------------
-- 40. Create a new order with 
-- 3 different products, quantities and categories - including "I Am A Product"
-- Yourself as the salesperson
-- IGD as the customer
-- Royal Mail as the shipper
-----------------------------------------------------------------------------------------------

BEGIN TRANSACTION

		INSERT INTO Orders
		VALUES ('LADYC', 12, '2022-08-03 00:00:00.000', '2022-09-03 00:00:00.000', NULL, 4, 56.32, 'IDG','9 High Acres', 'Abbots', 'Herts', 'WD5 0JB', 'UK')

		INSERT INTO [Order Details]
		VALUES (11082, 78, 13.50, 12, 0)

		INSERT INTO [Order Details]
		VALUES (11082, 77, 13.00, 1, 0)

		INSERT INTO [Order Details]
		VALUES (11082, 76, 18.00, 15, 0)

ROLLBACK TRANSACTION

-- COMMIT TRANSACTION



SELECT *
FROM [Order Details]
-----------------------------------------------------------------------------------------------
-- 41. Add your product to an order (not the one you created)
-----------------------------------------------------------------------------------------------

BEGIN TRANSACTION 
		
	INSERT INTO [Order Details]
	VALUES (11077, 78, 13.50, 1, 0)

ROLLBACK TRANSACTION
--COMMIT TRANSACTION


SELECT *
FROM [Order Details]


-----------------------------------------------------------------------------------------------
-- 42. Update the price of "I Am A Product" product
-----------------------------------------------------------------------------------------------
UPDATE Products
SET UnitPrice = 15.60
WHERE ProductID = 78;

SELECT * 
FROM Products
-----------------------------------------------------------------------------------------------
-- 43. Update the price of all product by 5%
-----------------------------------------------------------------------------------------------
UPDATE Products
SET UnitPrice = UnitPrice * 1.05

SELECT * 
FROM Products

-----------------------------------------------------------------------------------------------
-- 44. Update the price of Seafood by -10%
-----------------------------------------------------------------------------------------------
UPDATE Products
SET UnitPrice = UnitPrice * 0.9
WHERE CategoryID = 8

SELECT * 
FROM Products

-----------------------------------------------------------------------------------------------
-- 45. Update the quantity of a product in an order
-----------------------------------------------------------------------------------------------
UPDATE [Order Details]
SET Quantity = 10
WHERE OrderID = 10248
AND ProductID = 11

SELECT * 
FROM [Order Details]

-----------------------------------------------------------------------------------------------
-- 46. Update your manager
-----------------------------------------------------------------------------------------------
UPDATE Employees
SET ReportsTo = 7
WHERE EmployeeID = 12

SELECT * 
FROM Employees

-----------------------------------------------------------------------------------------------
-- 47. Thomas Hardy sadly got divorced and is now Thomas Jefferson, please amend the system to reflect this
-----------------------------------------------------------------------------------------------
UPDATE Customers
SET ContactName = 'Thomas Jefferson'
WHERE CustomerID = 'AROUT'

SELECT * 
FROM Customers

-----------------------------------------------------------------------------------------------
-- 48. "I Am A Product" has 20 more units now on order, please amend the system to reflect this
-----------------------------------------------------------------------------------------------
UPDATE Products
SET UnitsOnOrder = UnitsOnOrder + 20
WHERE ProductID = 78

SELECT * 
FROM Products

-----------------------------------------------------------------------------------------------
-- 49. Delete "I Am A Product" from all orders that are not for IGD
-----------------------------------------------------------------------------------------------
SELECT *
FROM Orders AS o

JOIN [Order Details] AS od
ON o.OrderID = od.OrderID

WHERE od.ProductID = 78
AND o.CustomerID != 'LADYC'

DELETE [Order Details] 
WHERE OrderID = 11077 AND ProductID = 78

SELECT *
FROM [Order Details]

-----------------------------------------------------------------------------------------------
-- 50. Why do you think we delete from databases so rarely?
-- If we want to delete from a database table but it is linked how could we get around this?
-----------------------------------------------------------------------------------------------
--In case we need the data again. Using a bit/boolean value, we can 'hide' data from the user so it looks like it has been deleted.
